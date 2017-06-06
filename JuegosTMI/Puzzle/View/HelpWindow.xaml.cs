

using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
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
using System.Windows.Shapes;

namespace Hanoi.View
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        private KinectChooser sensorChooser;
        private SelecGame sG;
        public HelpWindow(SelecGame sG)
        {
            InitializeComponent();
            this.sG = sG;


        }

        /// <summary>
        /// Play the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtPlayClick(object sender, RoutedEventArgs e)
        {


            videoControl.Visibility = Visibility.Visible;
            videoControl.Play();
        }
        /// <summary>
        /// Stop the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtStopClick(object sender, RoutedEventArgs e)
        {


            videoControl.Visibility = Visibility.Visible;
            videoControl.Stop();
        }
        /// <summary>
        /// Pause the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtPauseClick(object sender, RoutedEventArgs e)
        {


            videoControl.Visibility = Visibility.Visible;
            videoControl.Pause();
        }
        /// <summary>
        /// Exit the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton(object sender, RoutedEventArgs e)
        {
            videoControl.Stop();
            this.sensorChooser.Stop();
            this.sG.returnWindow();
            this.Hide();
        }
        /// <summary>
        /// Load the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);

            // this.videoControl.Source = new Uri(@"VideoHelp/helpKinect.mp4", UriKind.Relative);
            videoControl.Visibility = Visibility.Visible;
            videoControl.Play();
        }


        /// <summary>
        /// Maximize the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
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
