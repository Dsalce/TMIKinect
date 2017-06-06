

using Hanoi;
using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Win32.SafeHandles;
using Paint_Kinect;
using Hanoi.View;
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

namespace ChooseGame
{
    /// <summary>
    /// This class is relation with the choose of the game puzzle or supermarket
    /// Interaction logic for ChooseGame.xaml
    /// </summary>
    public partial class ChooseGames : Window, InterfaceConnect
    {

        private KinectChooser sensorChooser;
        


        /// <summary>
        /// Constructor ChooseGame
        /// </summary>
        /// <param name="user"></param>
        
        public ChooseGames()
        {
           
            InitializeComponent();
           

        }


        /// <summary>
        /// This method is call when the user return to the window
        /// </summary>
        public void returnWindow()
        {

            this.sensorChooser.Start();
            this.Show();
        }


        /// <summary>
        /// Event raise when the user click  puzzle button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectPuzzle(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            SelecGame selec = new SelecGame( this);
            this.Hide();
            selec.Show();
        }

        


        /// <summary>
        /// Event raise when the user want to exit 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();


            Application.Current.Shutdown(0);
        }

        /// <summary>
        /// Event raise when the window is loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);

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

        private void selectPaint(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            Paint selec = new Paint(this);
            this.Hide();
            selec.Show();
        }

      


    }

}
