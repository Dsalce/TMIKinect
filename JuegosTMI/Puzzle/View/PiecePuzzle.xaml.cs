using Puzzle.Controller;
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

namespace Hanoi.View
{
    /// <summary>
    /// This class represent a piece of the puzzle
    /// Interaction logic for PiecePuzzle.xaml
    /// </summary>
    public partial class PiecePuzzle : UserControl
    {
        private Boolean marcada;
        /// <summary>
        /// get-set mark
        /// </summary>
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
        /// <summary>
        /// get-set Num
        /// </summary>
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



        private ControllerPuzzle conPuz;
        public ControllerPuzzle Control
        {
            get
            {
                return this.conPuz;

            }
            set
            {
                conPuz = value;
            }
        }

  
        /// <summary>
        /// PiecePuzzle constructor
        /// </summary>
        public PiecePuzzle()
        {
            InitializeComponent();
           
        }
      /// <summary>
      /// Change the state of the piece
      /// </summary>
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
        /// <summary>
        /// This event is raise when a piece is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void markEvent(object sender, RoutedEventArgs e)
        {
            this.marked();
            this.conPuz.exchangePieces(this);
        }
    }
}
