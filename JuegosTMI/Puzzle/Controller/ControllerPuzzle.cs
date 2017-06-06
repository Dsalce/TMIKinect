using Hanoi.View;

using Puzzle.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.Controller
{
    /// <summary>
    /// This class is used to communicate the view with the model
    /// </summary>
    public class ControllerPuzzle
    {

        private PuzzleType puzView;
     
        private  PuzzleModel puz;
        /// <summary>
        /// ControllerPuzzle constructor
        /// </summary>
        public ControllerPuzzle(PuzzleType puzz)
        {
       
            this.puz = new PuzzleModel();
            this.puzView = puzz;
        }
     

        /// <summary>
        ///The user select one piece, when a second piece is selected, the pieces exchange the position
        /// </summary>
        /// <param name="piece"></param>
        
        private int numPiece;
        private PiecePuzzle ant;
        public void exchangePieces(PiecePuzzle piece)
        {
            if (numPiece == 0)
            {//one piece



                ant = piece;
                numPiece++;
            }
            else if (numPiece == 1)
            {//two pieces

                var p = piece.piece.Content;
                int n = piece.Num;

                piece.piece.Content = ant.piece.Content;
                piece.Num = ant.Num;

                ant.piece.Content = p;
                ant.Num = n;
                this.puz.exchangePieces(ant.Num,piece.Num);
                piece.marked();
                ant.marked();
                numPiece = 0;

                this.puzView.finish();
            }
        }


        /// <summary>
        /// generate the random puzzle
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public ArrayList puzzleGenerate(int n)
        {
            return this.puz.generateGame(n);
        }
        /// <summary>
        /// Check if the puzzle is finish
        /// </summary>
        /// <returns></returns>
        public Boolean finishPuzzle()
        {
            return this.puz.finishPuzzle();
        }
    }
}
