using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities;

namespace Hanoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HanoiMain : Window
    {

        private KinectChooser sensorChooser;
        private KinectSensor miKinect;
        private Pieza piece = null;
        private int contTake = 0;
        private int contLeave = 0;
        private Boolean take = false;
        private ColorImagePoint j1P_ant;
        private Thickness mar;
        private Boolean isGrip;
        private InterfaceConnect choose;

        public HanoiMain(InterfaceConnect choose)
        {
            this.choose = choose;
            InitializeComponent();

            peana.addPiece(this.VerySmall);
            peana.addPiece(this.Small);
            peana.addPiece(this.midSmall);
            peana.addPiece(this.midBig);
            peana.addPiece(this.Big);


        }
        /**
         * Evento que se genera al cargar la mainwindow
         */
        private void loadWindow(object sender, RoutedEventArgs e)
        {
            this.isGrip = false;
            


            this.miKinect = KinectSensor.KinectSensors[0]; //this.sensorChooser.sensor.Kinect;// 
            miKinect.SkeletonStream.Enable();
            miKinect.ColorStream.Enable();
            this.miKinect.Start();
            miKinect.ElevationAngle = 15;
            this.miKinect.Stop();
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);


           
            miKinect.SkeletonFrameReady += miKinect_SkeletonFrameReady;
            Task t1 = Task.Run(() => KinectRegion.AddQueryInteractionStatusHandler(this.kinectRegion, OnQuery));


        }

        private void OnQuery(object sender, QueryInteractionStatusEventArgs handPointerEventArgs)
        {
            //If a grip detected change the cursor image to grip
            if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.Grip)
            {
                this.isGrip = true;
                handPointerEventArgs.IsInGripInteraction = true;

            }
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.GripRelease)
            {
                this.isGrip = false;
                handPointerEventArgs.IsInGripInteraction = false;
            }
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.None)
            {
                handPointerEventArgs.IsInGripInteraction = this.isGrip;
            }


            handPointerEventArgs.Handled = true;

        }

        /**
         * Evento que controla el movimiento de las piezas
         * 
         */
        void miKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {


            canvasEsqueleto.Children.Clear();
            Skeleton[] esqueletos = null;

            using (SkeletonFrame frameEsqueleto = e.OpenSkeletonFrame())
            {
                if (frameEsqueleto != null)
                {
                    esqueletos = new Skeleton[frameEsqueleto.SkeletonArrayLength];
                    frameEsqueleto.CopySkeletonDataTo(esqueletos);
                }
            }

            if (esqueletos == null) return;

            foreach (Skeleton esqueleto in esqueletos)
            {
                if (esqueleto.TrackingState == SkeletonTrackingState.Tracked)
                {
                    Joint HandLeft = esqueleto.Joints[JointType.HandLeft];

                    ColorImagePoint j1P = miKinect.CoordinateMapper.MapSkeletonPointToColorPoint(HandLeft.Position, ColorImageFormat.RgbResolution1280x960Fps12);
                    //cursor actualizado
                    this.Cursor.Margin = new Thickness(j1P.X, j1P.Y, 0.0, 0.0);
                    ItemCollection it = this.container.Items;
                    //Comprueba que la pieza que se puede coger sea la primera
                    if (piece == null || piece.Equals(peana.firstPiece()) || piece.Equals(peana1.firstPiece()) || piece.Equals(peana2.firstPiece()))
                    {
                        //Por el if si no tiene una pieza en el cursor si la tiene por el else
                        if (take == false)
                        {
                            piece = this.isTaken(it, j1P);

                        }
                        else
                        {//carga la imagen de mano
                            this.loadPicture("/imagenes/take.jpg");
                            //actualiza cursor
                            this.Cursor.Margin = new Thickness(j1P.X, j1P.Y, 0.0, 0.0);
                            //actualiza posicion de la pieza
                            piece.Margin = new Thickness(j1P.X, j1P.Y, 0.0, 0.0);

                            //Comprueba que la pieza que  la posicion anterior sea la misma que la actual
                            if (j1P.X == this.j1P_ant.X && j1P.Y == this.j1P_ant.Y)
                            {

                                contLeave++;
                                //Cuando llega a 30 suelta la pieza
                                if (this.contLeave == 30)
                                {
                                    this.loadPicture("/Imagenes/arrow.png");
                                    //Mira si la pieza esta correctmente colocada
                                    this.isOkPosition(piece);

                                    piece = null;
                                    contLeave = 0;
                                    take = false;

                                }


                            }
                            j1P_ant = j1P;

                        }
                    }
                    else
                    {
                        piece = null;
                        contLeave = 0;
                        take = false;
                    }
                }



            }
        }
        /**
         * Verifica que la posicion de la pieza es correcta sino vuelve al lugar inicial de donde fue cogida
         */
        private void isOkPosition(Pieza piece)
        {
            //Posicion de la pieza en la primera peana
            if (piece.Margin.Left >= this.peana.Margin.Left && (piece.Margin.Left + piece.Width) <= (this.peana.Margin.Left + this.peana.Width)
               && piece.Margin.Top >= this.peana.Margin.Top && (piece.Margin.Top + piece.Height) <= (this.peana.Margin.Top + this.peana.palo.Height))
            {
                //Si la pieza colocada en la pena es mayor se coloca la nueva pieza
                if (piece.Size < peana.firstPiece().Size)
                {
                    this.peana.remove(piece);
                    this.peana1.remove(piece);
                    this.peana2.remove(piece);
                    //Colocala pieza bien colocada en la peana
                    double alto = this.peana.Margin.Top + this.peana.palo.Height - this.piece.Height - (this.peana.count() * (piece.Height - 10));
                    double dis = peana.Margin.Left + ((peana.Width - piece.Width) / 2);
                    piece.Margin = new Thickness(dis, alto + 30, 0, 0);
                    peana.addPiece(piece);
                }
                else
                {
                    //vuelve al inicio
                    piece.Margin = mar;
                }

            }
            //posicion de la pieza en la segunda peana
            else if (piece.Margin.Left >= this.peana1.Margin.Left && (piece.Margin.Left + piece.Width) <= (this.peana1.Margin.Left + this.peana1.Width)
               && piece.Margin.Top >= this.peana1.Margin.Top && (piece.Margin.Top + piece.Height) <= (this.peana1.Margin.Top + this.peana1.palo.Height))
            {
                //Si la pieza colocada en la pena es mayor se coloca la nueva pieza
                if (piece.Size < peana1.firstPiece().Size)
                {
                    this.peana.remove(piece);
                    this.peana1.remove(piece);
                    this.peana2.remove(piece);
                    //Colocala pieza bien colocada en la peana
                    double alto = this.peana1.Margin.Top + this.peana1.palo.Height - this.piece.Height - (this.peana1.count() * (piece.Height - 10));
                    double dis = peana1.Margin.Left + ((peana1.Width - piece.Width) / 2);
                    piece.Margin = new Thickness(dis, alto + 30, 0, 0);
                    peana1.addPiece(piece);
                }
                else
                {
                    //vuelve al inicio
                    piece.Margin = mar;
                }
            }
            //posicion de la pieza en la tercera peana
            else if (piece.Margin.Left >= this.peana2.Margin.Left && (piece.Margin.Left + piece.Width) <= (this.peana2.Margin.Left + this.peana2.Width)
              && piece.Margin.Top >= this.peana2.Margin.Top && (piece.Margin.Top + piece.Height) <= (this.peana2.Margin.Top + this.peana2.palo.Height))
            {
                //Si la pieza colocada en la pena es mayor se coloca la nueva pieza
                if (piece.Size < peana2.firstPiece().Size)
                {
                    this.peana.remove(piece);
                    this.peana1.remove(piece);
                    this.peana2.remove(piece);
                    //Colocala pieza bien colocada en la peana
                    double alto = this.peana2.Margin.Top + this.peana2.palo.Height - this.piece.Height - (this.peana2.count() * (piece.Height - 10));
                    double dis = peana2.Margin.Left + ((peana2.Width - piece.Width) / 2);
                    piece.Margin = new Thickness(dis, alto + 30, 0, 0);
                    peana2.addPiece(piece);
                }
                else
                {
                    //vuelve al inicio
                    piece.Margin = mar;
                }
            }
            else
            {
                //vuelve al inicio
                piece.Margin = mar;




            }




        }
        /**
         * 
         * Coge la pieza de la peana donde este puesta
         * 
         * 
         */
        private Pieza isTaken(ItemCollection it, ColorImagePoint j1P)
        {
            Pieza c = null;
            Pieza pieceF = null;
            int i = 0;
            while (i < it.Count && !take)
            {

                c = (Pieza)it.GetItemAt(i);

                //Posicion de la pieza
                if (j1P.X >= c.Margin.Left && j1P.X <= (c.Margin.Left + c.Width) && j1P.Y >= c.Margin.Top && j1P.Y <= (c.Margin.Top + c.Height))
                {
                    contTake++;

                    if (contTake == 30)
                    {


                        //Guarda la posicion inicial de la pieza
                        mar = new Thickness(c.Margin.Left, c.Margin.Top, 0, 0);
                        //Marca que se ha cogido una pieza
                        take = true;
                        contTake = 0;
                        pieceF = c;
                    }



                }


                i++;

            }
            return pieceF;
        }



        /**
         * Carga las imagenes
         */
        private void loadPicture(String path)
        {

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(path, UriKind.Relative);
            bi3.EndInit();
            this.flecha.Stretch = Stretch.Fill;
            this.flecha.Source = bi3;
        }
        /**
         * Evento para salir de la app
         */
        private void exitButton(object sender, RoutedEventArgs e)
        {


            this.sensorChooser.Stop();
            this.choose.returnWindow();
            this.Hide();


        }


        private void exitEvent(object sender, EventArgs e)
        {
            this.sensorChooser.Stop();
            System.Windows.Application.Current.Shutdown(0);
        }




        /**
         * Reinicia el juego
         */
        private void iniEvent(object sender, RoutedEventArgs e)
        {
            //reset a toda la app

            HanoiMain mw = new HanoiMain(this.choose);
            // mw.Owner = this;
            this.Close();
            mw.ShowDialog();

        }




        /**
         * Evento para actualizar la posicion del cursor
         * 
         */
        void miKinect_Cursor(object sender, SkeletonFrameReadyEventArgs e)
        {


            canvasEsqueleto.Children.Clear();
            Skeleton[] esqueletos = null;

            using (SkeletonFrame frameEsqueleto = e.OpenSkeletonFrame())
            {
                if (frameEsqueleto != null)
                {
                    esqueletos = new Skeleton[frameEsqueleto.SkeletonArrayLength];
                    frameEsqueleto.CopySkeletonDataTo(esqueletos);
                }
            }

            if (esqueletos == null) return;

            foreach (Skeleton esqueleto in esqueletos)
            {
                if (esqueleto.TrackingState == SkeletonTrackingState.Tracked)
                {

                    Joint HandLeft = esqueleto.Joints[JointType.HandLeft];

                    ColorImagePoint j1P = miKinect.CoordinateMapper.MapSkeletonPointToColorPoint(HandLeft.Position, ColorImageFormat.RgbResolution1280x960Fps12);
                    this.Cursor.Margin = new Thickness(j1P.X, j1P.Y, 0.0, 0.0);




                }
            }
        }




    }   
}
