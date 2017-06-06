
using Microsoft.Kinect.Toolkit.Controls;
using Puzzle.Controller;
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
using ViewCommon;
using System.Threading;
using System.ComponentModel;

namespace Hanoi.View
{
    /// <summary>
    /// This class contains the layout of the different types  of puzzle
    /// Interaction logic for puzzleType.xaml
    /// </summary>
    public partial class PuzzleType : UserControl
    {
        
         
       
        private Crono time;
        private PuzzleGame mw;
        private int n;
        /// <summary>
        /// get-set num
        /// </summary>
        public int num
        {
            set 
            {
                n = value;
            }
        }
        private ControllerPuzzle conPuz;
        private String sourceImg="";
        /// <summary>
        /// PuzzleType constructor
        /// </summary>
        public PuzzleType()
        {
            
            InitializeComponent();

            this.conPuz = new ControllerPuzzle(this);
     
        }
        /// <summary>
        /// Create the grid the grid depends of the puzzle  4,9,16 pieces
        /// </summary>
        /// <param name="mw"></param>
        public void createGrid(PuzzleGame mw)
        {
            this.mw = mw;
           int numPiece=1;
            for(int i=0;i<n;i++){
                ColumnDefinition gridCol1 = new ColumnDefinition();
                RowDefinition gridRow1 = new RowDefinition();  
                this.gridMatriz.ColumnDefinitions.Add(gridCol1);
                this.gridMatriz.RowDefinitions.Add(gridRow1);
            }
            for(int i=0;i<this.gridMatriz.RowDefinitions.Count;i++){
                for(int j=0;j<this.gridMatriz.ColumnDefinitions.Count;j++){
                
                    PiecePuzzle piece = new PiecePuzzle();
                    piece.Control = this.conPuz;
                    piece.Num = numPiece;
                    numPiece++;
                    
                    Grid.SetRow(piece, i);
                    Grid.SetColumn(piece, j);
                    this.gridMatriz.Children.Add(piece);
                  
                }
                
        }
            this.sourceImage();
}
     
     /// <summary>
     /// Set all to prepare the start of the game
     /// </summary>
     /// <param name="t"></param>
     /// <param name="record"></param>
        public void initGame(Crono t){
        
            this.time = t;
            this.startGame();
            fotoOK.Visibility = Visibility.Hidden;
            this.mw.nameUser.Content = "Video";
         
        }
      
        /// <summary>
        /// Set the image of the puzzle 
        /// This image is used to help the user
        /// </summary>
        private void sourceImage(){
           BitmapImage img = new BitmapImage();
           img.BeginInit();
             if (n == 2)
            {
                img.UriSource = new Uri(@"imagenes/Comida/comida.jpg", UriKind.Relative);
                
                img.EndInit();
                mw.foto.Source = img;
                this.fotoOK.Source=img;
                sourceImg = @"imagenes/Comida/"; 
            }else if(n == 3){
                img.UriSource = new Uri(@"imagenes/Gatos/gate.jpg", UriKind.Relative);
               
                img.EndInit();
                mw.foto.Source = img;
                this.fotoOK.Source = img;
                sourceImg = @"imagenes/Gatos/";
                
            }
            else if (n == 4)
            {
                img.UriSource = new Uri(@"imagenes/Paisaje/paisaje.jpg", UriKind.Relative);

                img.EndInit();
                mw.foto.Source = img;
                this.fotoOK.Source = img;
                sourceImg = @"imagenes/Paisaje/";
               
            }
       }
     
        /// <summary>
        /// Start the game
        /// </summary>
        private void startGame()
        {
           
          
            //obtain the disorder list
            ArrayList list = this.conPuz.puzzleGenerate(n);
            //get images
            var pics = this.gridMatriz.Children.OfType<PiecePuzzle>();
            int count = 0;
            //put the images in the grid
            foreach (PiecePuzzle i in pics)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(sourceImg + list[count] + ".jpg", UriKind.Relative);
                img.EndInit();
                 i.Num = Int32.Parse(list[count].ToString());
                 i.img.Source = img;
                 
                count++;
            }
        }
      

      

       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        public void finish()
         {
            
             if (this.conPuz.finishPuzzle())
             {
                  fotoOK.Visibility = Visibility.Visible;
                  this.mw.btnPlay.IsEnabled = false;
                  this.mw.fotoShow.IsEnabled = false;
                  time.stopCrono();
                  this.mw.finishPuzzle();
             }
         }

      
     
       
    }
}
