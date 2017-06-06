using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Kinect
{
  public  abstract class Herramienta 
    {
      
        protected int  tam;
    
        public Herramienta()
        {
            this.tam = 0;
        }

        public abstract Canvas doSomething(Point j1P, Brush color);

    }
}
