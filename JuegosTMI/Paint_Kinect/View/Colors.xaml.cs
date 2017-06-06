using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Paint_Kinect
{
    /// <summary>
    /// Interaction logic for Colors.xaml
    /// </summary>
    public partial class Colors : Window
    {
        private KinectChooser sensorChooser;

        private Paint mW;
        public Colors(Paint mW)
        {
            InitializeComponent();
            this.mW = mW;
            this.colorSelec.Background = Brushes.Black;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.mW.sensorChooserUi);

        }

       
      
        private void colorSelected(object sender, RoutedEventArgs e)
        {
            
            this.colorSelec.Background = ((KinectTileButton)sender).Background;
        }
       public Brush getColor(){
           return this.colorSelec.Background;
           
        }

       private void exitEvent(object sender, RoutedEventArgs e)

       {
           this.sensorChooser.Stop();
           this.mW.mainWindowReturn();
           this.Hide();
           

       }

    }
}
