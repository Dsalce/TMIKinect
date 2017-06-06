using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Paint_Kinect.Herramientas
{
    class Aerografo : Herramienta
    {

        public Aerografo(int tam)
        {
            this.tam = tam/4;
            random = new Random();
        }

        private Random random = new Random();

        public override Canvas doSomething(System.Windows.Point j1P, System.Windows.Media.Brush color)
        {

            Canvas can = new Canvas();

            Random random = new Random();
            double radius = tam;
            for (int i = 0; i < 10; i++)
            {
                double r = random.NextDouble() * radius;
                double theta = random.NextDouble() * (Math.PI * 2);
                double x = j1P.X + Math.Cos(theta) * r;
                double y = (j1P.Y -150) + Math.Sin(theta) * r;
                //Ellipse ellipse = new Ellipse();
                Ellipse ellipse = new Ellipse();
                ellipse.StrokeThickness = tam;
                ellipse.Height = tam;
                ellipse.Width = tam;
                ellipse.SetValue(Canvas.LeftProperty, x);
                ellipse.SetValue(Canvas.TopProperty, y);
                ellipse.Fill = color;
                can.Children.Add(ellipse);


            }
            return can;


        }
    }
}