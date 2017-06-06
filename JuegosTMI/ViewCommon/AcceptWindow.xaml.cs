using KinectToolsBox;

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Utilities;

namespace ViewCommon
{
    /// <summary>
    /// This class is use when the game is over
    /// Interaction logic for AcceptWindow.xaml
    /// </summary>
    public partial class AcceptWindow : Window
    {
        private InterfaceConnect interSelect;
        private KinectChooser sensorChooser;

      
        /// <summary>
        /// AcceptWindow constructor
        /// </summary>
        /// <param name="interSelect"></param>
        /// <param name="interGame"></param>
        /// <param name="record"></param>
        public AcceptWindow(InterfaceConnect interSelect)
        {
       
            InitializeComponent();
            this.interSelect = interSelect;

        }

        /// <summary>
        /// This event raise when the view is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
          private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion,this.sensorChooserUi);
        
        }

        /// <summary>
        /// When the user click accept
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptEvent(object sender, RoutedEventArgs e)
        {

            
           
            this.sensorChooser.Stop();
         
            //This time is needed to save all data in database
            //Thread.Sleep(3000);
            this.Hide();
            
            //return to the window  where you the user select the type of game
            interSelect.returnWindow();
      
           
        }

     
      
       
    }
}
