

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
using ViewCommon;


namespace puzzle.View
{
    /// <summary>
    /// Interaction logic for SelecGame.xaml
    /// </summary>
    public partial class SelecGame : Window,InterfaceConnect

    {
        private InterfaceConnect choose;
        private KinectChooser sensorChooser;
        public SelecGame(String user, InterfaceConnect choose)
        {
            InitializeComponent();
            this.nameUser.Content = user;
            this.choose = choose;
        }
   
        
     
        public void returnWindow(){
          
            this.sensorChooser.Start();
            this.Show();
        }
        private void selectPuzzle(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            int aux = Int32.Parse(((KinectTileButton)sender).Tag.ToString());
            PuzzleGame mw = new PuzzleGame(aux, this);
            mw.Show();
        }
     
           

      

        private void exitButton(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.choose.returnWindow();
            this.Close();
        }

        private void helpButton(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            HelpWindow hw = new HelpWindow(this);
            hw.Show();
        }

        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion,this.sensorChooserUi);
        }

        }
    
}
