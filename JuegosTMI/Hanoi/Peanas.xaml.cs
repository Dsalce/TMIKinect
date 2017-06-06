using Hanoi;
using System;
using System.Collections;
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
    /// Interaction logic for Peanas.xaml
    /// </summary>
    public partial class Peanas : UserControl
    {
        
         private Hashtable piezas;

      
        public Peanas()
        {
            InitializeComponent();
            this.piezas = new Hashtable();
        }

        public void addPiece(Pieza p){
            
                this.piezas.Add(p.Size,p);
            
        }
        

        public void remove(Pieza p)
        {

            this.piezas.Remove(p.Size);

        }
        public Boolean empty()
        {
            return this.piezas.Count == 0;
        }
        public int count()
        {
            return this.piezas.Count;
        }
        /**
         * Devuelve la primera pieza
         */
        public Pieza firstPiece()
        {

            
            ArrayList aKeys = new ArrayList(piezas.Keys);
            aKeys.Sort();
        
           
            if (piezas.Count == 0){
            
              Pieza  aux=new Pieza();
               aux.Size=100;
                return aux;
            }
            else
            {
                return (Pieza)piezas[(int)aKeys[0]];
            }
            
          
        }
    }
}
    

