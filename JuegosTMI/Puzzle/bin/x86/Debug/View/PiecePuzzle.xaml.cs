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

namespace puzzle.View
{
    /// <summary>
    /// Interaction logic for PiecePuzzle.xaml
    /// </summary>
    public partial class PiecePuzzle : UserControl
    {
        private Boolean marcada;
        public Boolean mark
        {
            get
            {
                return this.marcada;

            }
            set
            {

                marcada = value;
            }
        }

        private int num;

        public int Num
        {
            get
            {
                return this.num;
            }
            set
            {
                num = value;
            }
        }

        

        /**
         * Marca o desmarca la pieza y le pone un grado de opacidad cuando esta marcada
         */
        private PuzzleType puz;
        public PuzzleType Puzzle
        {
            set
            {
                puz = value;
            }
        }
        
        public PiecePuzzle()
        {
            InitializeComponent();
           
        }
      
        public void marked()
        {
            if (this.marcada)
            {
                this.marcada = false;

                this.Opacity = 100.0;

            }
            else
            {
                this.marcada = true;
                this.Opacity = 0.5;
            }
        }

        private void markEvent(object sender, RoutedEventArgs e)
        {
            this.marked();
            this.puz.selecImage(this);
        }
    }
}
