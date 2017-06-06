

using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using Utilities;
using ViewCommon;


namespace Hanoi.View
{
    /// <summary>
    /// The user can select the game 
    /// Interaction logic for SelecGame.xaml
    /// </summary>
    public partial class SelecGame : Window,InterfaceConnect

    {
        
        private KinectChooser sensorChooser;
        private InterfaceConnect choose;

        /// <summary>
        /// SelecGameSuper constructor
        /// </summary>
        /// <param name="user"></param>
        /// <param name="inter"></param>
        public SelecGame(InterfaceConnect ch)
        {
            choose = ch;
            InitializeComponent();
          
        }


        /// <summary>
        /// Return to this view
        /// </summary>
        public void returnWindow(){
           
            this.sensorChooser.Start();
            this.Show();
        }
        /// <summary>
        /// The user select the difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectPuzzle(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            int aux = Int32.Parse(((KinectTileButton)sender).Tag.ToString());
             PuzzleGame mw = new PuzzleGame(aux, this);
            mw.Show();
        }




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

        /// <summary>
        /// Call the view helpWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            HelpWindow hw = new HelpWindow(this);
            hw.Show();
        }

        /// <summary>
        /// Load the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion,this.sensorChooserUi);
        }

        /// <summary> 
        /// This event raise when the application is going to shutdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitEvent(object sender, EventArgs e)
        {
            this.sensorChooser.Stop();
            Application.Current.Shutdown(0);
        }

        }
    
}
