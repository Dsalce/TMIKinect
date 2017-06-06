using Paint_Kinect.Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint_Kinect
{
    class Controlador
    {
        private Herramienta herramienta;


        public Controlador()
        {
            herramienta = new Pencil(10);

        }

        public  void useHerramienta(String her,int tam){

             if (her.Equals("pen"))
                {
                    this.herramienta = new Pencil(tam);
                }else if(her.Equals("aero")){
                    this.herramienta = new Aerografo(tam);
                } else if (her.Equals("broc"))
                   {
                    this.herramienta = new Brocha(tam);
                }else if(her.Equals("goma")){
                    this.herramienta = new Goma(tam);
                }
        }

        public Canvas paintCanvas(Point j1P, Brush color)
        {
           
             return this.herramienta.doSomething(j1P,color);

            
        }



    }
}
