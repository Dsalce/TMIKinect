using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KinectToolsBox;
using System.IO;

using System.ComponentModel;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System.Windows.Forms;
using Microsoft.Speech;

using System.Drawing.Drawing2D;
using Paint_Kinect.Herramientas;
using Paint_Kinect.View;
using Utilities;


namespace Paint_Kinect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Paint : Window
    {
        private InterfaceConnect choose;
        private KinectChooser sensorChooser;
        private KinectSensor _sensor;
        private Colors col;
        private Boolean isGrip;
        private Pencils pen;
      
        private Controlador ctl;
        private SizePaint size;
        private int ang;


        public Paint(InterfaceConnect choose)
        {
            this.choose = choose;
            this.InitializeComponent();
            



        }
        private void load_window(object sender, RoutedEventArgs e)
        {
            //Esto es opcional pero ayuda a colocar el dispositivo Kinect a un cierto angulo de inclinacion, desde -27 a 27
            this._sensor = KinectSensor.KinectSensors[0];
            this._sensor.Start();
            this.ang = 0;
            _sensor.ElevationAngle = 15;
            this._sensor.Stop();
           
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);


           
            pen = new Pencils(this);
            col = new Colors(this);
            size = new SizePaint(this);
            
            this.ctl = new Controlador();
           KinectRegion.AddHandPointerMoveHandler(this.paint, OnHandMove);
            KinectRegion.AddQueryInteractionStatusHandler(this.paint, OnQuery);
            
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


           handPointerEventArgs.Handled= true;

        }

        
        /**
      * Evento para salir de la app
      */
        /// <summary>
        /// Exit the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.choose.returnWindow();
            this.Hide();
        }

        /**
         * Reinicia el juego
         */
        private void iniEvent(object sender, RoutedEventArgs e)
        {
            this.paint.Children.Clear();
          

        }

     


        public void mainWindowReturn()
        {

               this.pincelImg.Source= pen.getPencil().Source;
               this.ctl.useHerramienta(pen.getPencil().Tag.ToString(), Int32.Parse(size.getSize().Tag.ToString()));

            
           
                this.colorSelec.Background = col.getColor();
            
            this.sensorChooser.Start();
        }

      
        private void OnHandMove(object source, HandPointerEventArgs args)
        {


            //Double.Parse(this.rowCanvas.Height.Value.ToString())
            HandPointer ptr = args.HandPointer;
            if (this.isGrip)
            {
                Point j1P = kinectRegion.PointToScreen(ptr.GetPosition(kinectRegion));

                if (j1P.X >= this.paint.Margin.Left && j1P.X <= Screen.PrimaryScreen.Bounds.Width  && j1P.Y >=this.paint.Margin.Top && j1P.Y <= Screen.PrimaryScreen.Bounds.Height)
                {
                  
                 // ptr.IsInGripInteraction = true;

                 this.paint.Children.Add(this.ctl.paintCanvas(j1P, this.colorSelec.Background));

                }
                
            }
        }

        private void gomaEvent(object sender, RoutedEventArgs e)
        {
            this.ctl.useHerramienta("goma", Int32.Parse(size.getSize().Tag.ToString()));
        }

       
       
        private void saveEvent(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 96d, 96d, PixelFormats.Pbgra32);
            // needed otherwise the image output is black
            this.paint.Measure(new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            this.paint.Arrange(new Rect(new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)));

            renderBitmap.Render(this.paint);

            
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            using (FileStream file = File.Create("../Imagen"+DateTime.Now.ToString("d_MMM_yyyy_HH_mm_ss")+".jpg"))
            {
                encoder.Save(file);
                
            }
            this.WindowState = System.Windows.WindowState.Normal;
            this.WindowState = System.Windows.WindowState.Maximized;
            
        }

        private void colorSelected(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            col = new Colors(this);
           
            col.ShowDialog();
          
        }

        private void changeSize(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            size = new SizePaint(this);
     
            size.ShowDialog();
           
        }
        private void changePencil(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
             pen = new Pencils(this);
          
            pen.ShowDialog();
          
        }
        
        private void menosEvent(object sender, RoutedEventArgs e)
        {


            if (this.ang > -20)
            {
                this.ang = this.ang - 10;
                this._sensor = KinectSensor.KinectSensors[0];
                this._sensor.Start();
                //Esto es opcional pero ayuda a colocar el dispositivo Kinect a un cierto angulo de inclinacion, desde -27 a 27
                _sensor.ElevationAngle = this.ang;
           
            }
         
        }

        private void masEvent(object sender, RoutedEventArgs e)
        {

            if (this.ang < 20)
            {
                this.ang = this.ang + 10;
                this._sensor = KinectSensor.KinectSensors[0];
                this._sensor.Start();
                //Esto es opcional pero ayuda a colocar el dispositivo Kinect a un cierto angulo de inclinacion, desde -27 a 27
                _sensor.ElevationAngle = this.ang;
          
            }
        }

        private void exitEvent(object sender, EventArgs e)
        {
            this.sensorChooser.Stop();
            System.Windows.Application.Current.Shutdown(0);
        }

        private void leave(object sender, TouchEventArgs e)
        {
            this.isGrip = false;
        }

        private void enter(object sender, TouchEventArgs e)
        {
            this.isGrip = false;
        }

        private void formasEvent(object sender, RoutedEventArgs e)
        {
            //this.ctl.useHerramienta("lupa", Int32.Parse(size.getSize().Tag.ToString()));
            
        
        }

      

        
      

        

    

        
       
    }
}