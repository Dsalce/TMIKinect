


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
using ViewCommon;
using System.ComponentModel;
using Utilities;

namespace Hanoi.View
{
    /// <summary>
    /// Mainwindow of the puzzle game
    /// Interaction logic for PuzzleGame.xaml
    /// </summary>
    public partial class PuzzleGame : Window
    {

      
        private KinectChooser sensorChooser;
        private SelecGame sG;
        private AcceptWindow accept;
 /// <summary>
        /// PuzzleGame constructor
 /// </summary>
 /// <param name="n"></param>
 /// <param name="sG"></param>
        public PuzzleGame(int n, SelecGame sG)
        {
           
            InitializeComponent();
            this.gridMatriz.num = n;
            this.sG = sG;
            this.gridMatriz.createGrid(this);
            this.nameUser.Content = this.sG.nameUser.Content;
        }

       
       


      


       
     /// <summary>
     /// Start the game
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

            this.time.startCrono();
            this.gridMatriz.initGame(this.time);
            
            this.fotoShow.IsEnabled = true;
            this.btnPlay.IsEnabled = false;
        }
       


        
        /// <summary>
        /// Show the image of help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Exit the puzzle game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton(object sender, RoutedEventArgs e)
        {
         
            this.sensorChooser.Stop();
           
            this.sG.returnWindow();
        
          
            this.Hide();
           
        }
        /// <summary>
        /// Load components of the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);

           
            accept = new AcceptWindow(this.sG);
         
            
        }
        /// <summary>
        /// Close the view
        /// </summary>
        public void close()
        {
            this.Hide();
        }
      
     
        /// <summary>
        /// This method is called when the puzzle is finish
        /// </summary>
        public void finishPuzzle()
        {

            this.sensorChooser.Stop();
            this.Hide();
            this.accept.Show();
           
        }



        /// <summary> 
        /// This event raise when the application is going to shutdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitEvent(object sender, EventArgs e)
        {
            Application.Current.Shutdown(0);

        }


        }

        


      
}
