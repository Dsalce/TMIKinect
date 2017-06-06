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
    public  class  Goma:Herramienta
    {

        public Goma(int tam)
        {
            this.tam = tam;
        }


        public override  Canvas doSomething(Point j1P, Brush color)
        {
           
           
             System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
            myPath.Stroke = Brushes.White;
            myPath.Fill = Brushes.White;
            myPath.StrokeThickness = tam;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;
            RectangleGeometry rec = new RectangleGeometry();
            rec.Rect = new Rect(j1P.X, j1P.Y -150,25,25);
            
            myPath.Data = rec;

            Canvas can = new Canvas();
            can.Children.Add(myPath);
            return can;
            
        }

    }
}
