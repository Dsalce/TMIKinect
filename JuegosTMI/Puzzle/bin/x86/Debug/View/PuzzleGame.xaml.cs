

using ScreenRecorder.Recorder;
using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace puzzle.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PuzzleGame : Window
    {

        private RecorderScreen record;
        private KinectChooser sensorChooser;
        private SelecGame sG;


        public PuzzleGame(int n, SelecGame sG)
        {
            InitializeComponent();
            this.gridMatriz.num = n;
            this.sG = sG;
            this.gridMatriz.createGrid(this);
            this.nameUser.Content = this.sG.nameUser.Content;
        }

       
       


      


       
      /*
      * Boton de play
      */ 
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {


            this.gridMatriz.initGame(this.time, record);
            this.time.startCrono();
            this.fotoShow.IsEnabled = true;
        }
       


        

        private void showImage(object sender, RoutedEventArgs e)
        {
            
           if (this.gridMatriz.fotoOK.Visibility == Visibility.Visible)
            {
                this.gridMatriz.fotoOK.Visibility = Visibility.Hidden;
                
            }
            else if (this.gridMatriz.fotoOK.Visibility == Visibility.Hidden)
            {
                this.gridMatriz.fotoOK.Visibility = Visibility.Visible;
               
            }
            
         
          
        }

        private void exitButton(object sender, RoutedEventArgs e)
        {
            //captureRGB.Stop();
            this.sensorChooser.Stop();
            this.record.Stop();
            this.sG.returnWindow();
            RecorderScreen.deleteVideo( Environment.CurrentDirectory.ToString() + "\\" + Environment.UserName.ToUpper() + ".mp4");
            this.Close();
            
           
        }

        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);
            
            record = new RecorderScreen();
            captureRGB.Start(sensorChooser.sensor.Kinect);
        }

        

        


        }

        


      
}
