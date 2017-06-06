using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectToolsBox
{
    public class KinectChooser
    {
        private KinectSensorChooser sensorChooser;
        public KinectSensorChooser sensor
        {
            get
            {
                return this.sensorChooser;
            }
           
        }
        private KinectRegion kReg;
        
        public KinectChooser(KinectRegion kReg, KinectSensorChooserUI sensorChooserUi)
        {
            
            this.kReg = kReg;
            sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();
        }




        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {

            if (args.OldSensor == null)
            {
                try
                {

                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (Exception) { }
            }

            if (args.NewSensor == null) { return; }


            try
            {
                args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                args.NewSensor.SkeletonStream.Enable();
                try
                {
                    args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    args.NewSensor.DepthStream.Range = DepthRange.Default;
                    args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;

                }
                catch (InvalidOperationException)
                {
                    args.NewSensor.DepthStream.Range = DepthRange.Default;
                    args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;

                }
            }
            catch (InvalidOperationException) { }

            kReg.KinectSensor = args.NewSensor;

        }

        public void Start()
        {
            this.sensorChooser.Start();
        }
        public void Stop()
        {
            this.sensorChooser.Stop();
        }

      

    }
}
