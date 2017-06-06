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
    class Pencil :Herramienta
    {
       
        public Pencil(int tam)
        {
            this.tam = tam;   
        }

        public override Canvas doSomething(Point j1P, Brush color)
        {
            System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
            myPath.Stroke = color;
            myPath.Fill = color;
            myPath.StrokeThickness = tam;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point(j1P.X, j1P.Y -150);
            myEllipseGeometry.RadiusX = 20;
            myEllipseGeometry.RadiusY = 20;
            myPath.Data = myEllipseGeometry;
            Canvas can = new Canvas();
            can.Children.Add(myPath);
            return can;
        }
    }
}
