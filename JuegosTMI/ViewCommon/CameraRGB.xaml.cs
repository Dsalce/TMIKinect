using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Kinect;
using System.IO;

namespace ViewCommon
{
    /// <summary>
    ///ControlUser to Record the user  
    /// </summary>
    public partial class CameraRGB : UserControl
    {
        KinectSensor miKinect;
        /// <summary>
        /// CameraRGB constructor
        /// </summary>
        public CameraRGB()
        {
            InitializeComponent();
        }

      
        /// <summary>
        /// Start the record of the kinect
        /// </summary>
        /// <param name="sensor"></param>
        public void Start(KinectSensor sensor){
            try
            {
                //sensor kinect
                miKinect = sensor;
                miKinect.ColorStream.Enable(ColorImageFormat.YuvResolution640x480Fps15);

                miKinect.ColorFrameReady += miKinect_ColorFrameReady;
            }catch(Exception ){
              
            }
           
        }
        /// <summary>
        /// Stop the record of the kinect
        /// </summary>
        public void Stop()
        {
            miKinect.Stop();
        }
        /// <summary>
        /// This event capture the kinect recorded image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       public void miKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame framesImagen = e.OpenColorImageFrame())
            {

                if (framesImagen == null)
                    return;

                byte[] datosColor = new byte[framesImagen.PixelDataLength];

                framesImagen.CopyPixelDataTo(datosColor);


                //The bitmap 
                colorStream.Source = BitmapSource.Create(
                       framesImagen.Width, framesImagen.Height,
                        96,
                        96,
                        PixelFormats.Bgr32,
                        null,
                        datosColor,
                        framesImagen.Width * framesImagen.BytesPerPixel
                        );

            }
        }

     
    }
}
