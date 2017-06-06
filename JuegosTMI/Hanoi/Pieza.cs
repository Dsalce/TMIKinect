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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hanoi
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Hanoi"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Hanoi;assembly=Hanoi"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class Pieza : Image
    {
        static Pieza()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Pieza), new FrameworkPropertyMetadata(typeof(Pieza)));
        }
        
        private int size;
        public int Size{
            get
            {
                return this.size;
            }
            set
            {
               
                this.size = value;
            }
        }
       

        
        


        public Pieza()
        {

        }
    }
}
/**
<Window x:Class="Hanoi.HanoiMain"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:k="http://schemas.microsoft.com/kinect/2013"
        Title="Hanoi"  WindowState="Maximized" Closed="exitEvent"
       xmlns:han="clr-namespace:Hanoi"
        xmlns:cron="clr-namespace:ViewCommon;assembly=ViewCommon" 
        Height="652" Width="969" Loaded="loadWindow" >

    <Grid Name="grid" Background="Beige" >
        <k:KinectRegion x:Name="kinectRegion"  >

            <Grid Name="gridGame">
                <Grid.RowDefinitions>
                    <RowDefinition Height="85*" />
                    <RowDefinition Height="487*"/>
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="315*" />
                    <ColumnDefinition Width="315*"/>
                    <ColumnDefinition Width="331*"/>

                </Grid.ColumnDefinitions>
                <k:KinectSensorChooserUI Name="sensorChooserUi" Grid.Row="0" Grid.Column="1" HorizontalAlignment="Center" VerticalAlignment="Center" />
                <cron:Crono x:Name="time" Grid.Column="0" Margin="10,2,0,0" HorizontalAlignment="Left" VerticalAlignment="Top" Height="85" Width="165" />
                <k:KinectTileButton   Grid.Column="2" Grid.Row="0"   Background="Beige" Click="exitButton"  Margin="0,0,10,0" HorizontalAlignment="Right" VerticalAlignment="Top" Height="87" Width="159" >
                    <Image Height="Auto" Width="Auto" Stretch="Fill" Source="Images/exit.png"  />
                </k:KinectTileButton>

                <han:Peanas x:Name="peana"  Grid.Column="0"  Grid.Row="1" Height="Auto" />

                <han:Peanas  x:Name="peana1" Grid.Column="1" Grid.Row="1" Height="Auto"/>

                <han:Peanas  x:Name="peana2" Grid.Column="2" Grid.Row="1" Height="Auto"  />

                <han:Pieza  x:Name="Big"   Margin="27,525,35,-481" Size="5"  Source="Images/fig5.png" Stretch="Fill"  />
                <han:Pieza x:Name="midBig"   Margin="60,490,70,-448"  Size="4" Source="Images/fig4.png" Stretch="Fill"  />
                <han:Pieza x:Name="midSmall"  Margin="82,457,85,-413" Size="3" Source="Images/fig3.png"  Stretch="Fill"/>
                <han:Pieza x:Name="Small"  Margin="105,420,100,-378"    Size="2" Source="Images/fig2.png" Stretch="Fill" />
                <han:Pieza x:Name="VerySmall"    Margin="123,382,120,-338"  Size="1" Source="Images/fig1.png"  Stretch="Fill"/>
                
                <k:KinectTileButton Margin="85,88,10,221" Click="press"/>



            </Grid>
        </k:KinectRegion>
    </Grid>
</Window>

*/