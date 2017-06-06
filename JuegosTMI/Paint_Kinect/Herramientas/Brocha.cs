using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Kinect.Herramientas
{
    class Brocha :Herramienta
    {

        public Brocha(int tam)
        {
            this.tam = tam;
        }


        public override  Canvas doSomething(Point j1P, Brush color)
        {
           
           System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
            myPath.Stroke = color;
            myPath.Fill =color;
            myPath.StrokeThickness = tam;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;
            RectangleGeometry rec = new RectangleGeometry();
            rec.Rect = new Rect(j1P.X, j1P.Y -150,50,50);
            
            myPath.Data = rec;
            Canvas can = new Canvas();
            can.Children.Add(myPath);
            return can;
            
        }
    }
}
