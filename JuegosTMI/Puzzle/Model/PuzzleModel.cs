using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.Model
{
    /// <summary>
    /// Model of puzzle
    /// Logic PuzzleModel
    /// </summary>
    public class PuzzleModel
    {
        private ArrayList puzzNum;
       /// <summary>
       /// Constructor Model
       /// </summary>
       public PuzzleModel()
       {
           puzzNum = new ArrayList();
       }
       /// <summary>
       /// Check if the  puzzle is finished
       /// </summary>
       /// <returns></returns>
       public Boolean finishPuzzle() {
           bool ok = true;
           IEnumerator pics = this.puzzNum.GetEnumerator();
           int count = 1;


           while (pics.MoveNext() && ok)
           {
               if ((int)pics.Current != count)
               {
                   ok = false;
               }
               count++;
           }

           return ok;
         }
       /// <summary>
       /// Method used to generate random numbers 
       /// </summary>
       /// <param name="n"></param>
       /// <returns></returns>
       public ArrayList generateGame(int n)
       {

           ArrayList ar = new ArrayList();
           for (int rr = 1; rr <= n * n ; rr++)
               ar.Add(rr);
           puzzNum = new ArrayList();
           Random randNum = new Random();
           while (ar.Count > 0)
           {
               int val = randNum.Next(0, ar.Count - 1);
               puzzNum.Add(ar[val]);
               ar.RemoveAt(val);
           }
           return puzzNum;
       }

        /// <summary>
        /// Exchange the number to relation the view with the model 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="num2"></param>
       public void exchangePieces(int num, int num2)
       {
           int numJ = -1;
           int numI =-1;
           int i=0;
           foreach (int aux in puzzNum)
           {
               if (aux.Equals(num))
               {
                  
                   numI = i;
               }
               if (aux.Equals(num2))
               {
                  
                    numJ = i;
               }
               i++;
           }

           if (numI > -1)
           {
               puzzNum.RemoveAt(numI);
               puzzNum.Insert(numI, num2);
           }
            if(numJ>-1){
                   puzzNum.RemoveAt(numJ);
                   puzzNum.Insert(numJ,num);
             }

           }
          
       
    }
}
