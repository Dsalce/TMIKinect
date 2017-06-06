

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

namespace puzzle.View
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
      
      
        private void BtPlayClick(object sender, RoutedEventArgs e)
        {
          //  VideoControl.Source = newUri(MediaPathTextBox.Text);

           
            
            VideoControl.Visibility = Visibility.Visible;
            VideoControl.Play();
        }

        private void BtStopClick(object sender, RoutedEventArgs e)
        {
          

            VideoControl.Visibility = Visibility.Visible;
            VideoControl.Stop();
        }

        private void BtPauseClick(object sender, RoutedEventArgs e)
        {
            

            VideoControl.Visibility = Visibility.Visible;
            VideoControl.Pause();
        }

        private void exitButton(object sender, RoutedEventArgs e)
        {
            VideoControl.Stop();
            this.sensorChooser.Stop();
            this.sG.returnWindow();
            this.Close();
        }

        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);
            VideoControl.Visibility = Visibility.Visible;
            VideoControl.Play();
        }

       
      
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
    }
}
