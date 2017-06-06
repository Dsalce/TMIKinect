using ScreenRecorder.Recorder;
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

namespace puzzle.View
{
    /// <summary>
    /// Interaction logic for puzzleType.xaml
    /// </summary>
    public partial class PuzzleType : UserControl
    {

        private RecorderScreen record;
        private Crono time;
        private int numPiece;
        private PiecePuzzle ant;
        private PuzzleGame mw;
        private int n;
        public int num
        {
            set 
            {
                n = value;
            }
        }
        private ControllerPuzzle conPuz;
        private String sourceImg="";

        public PuzzleType()
        {
            
            InitializeComponent();

            this.conPuz = new ControllerPuzzle();
     
        }
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
                    piece.Puzzle = this;
                    piece.Num = numPiece;
                    numPiece++;
                    
                    Grid.SetRow(piece, i);
                    Grid.SetColumn(piece, j);
                    this.gridMatriz.Children.Add(piece);
                  
                }
                
        }
            this.sourceImage();
}
     
        public void initGame(Crono t,RecorderScreen record){
        this.record=record;
            this.time = t;
            this.startGame();
            fotoOK.Visibility = Visibility.Hidden;
       
           this.record.start();
        }
      
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
     
        private void startGame()
        {
           
          
            //obtiene lista desordenada
            ArrayList list = this.conPuz.puzzleGenerate(n);
            //obtiene los Image
            var pics = this.gridMatriz.Children.OfType<PiecePuzzle>();
            int count = 0;
            //coloca imagenes
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
      
    
        public bool isFinish()
        {
            bool ok = true;
            IEnumerator pics = this.gridMatriz.Children.OfType<PiecePuzzle>().GetEnumerator();
            int count = 1;
            //coloca imagenes

            while (pics.MoveNext() && ok)
            {
                PiecePuzzle aux = (PiecePuzzle)pics.Current;
                if (aux.Num != count)
                {
                    ok = false;
                }
                count++;
            }

            return ok;
        }
      
         public void selecImage(PiecePuzzle piece)
        {
          
            if (numPiece == 0)
            {



                ant = piece;
                numPiece++;
            }
            else if (numPiece == 1)
            {

                var p = piece.piece.Content;
                int n = piece.Num;

                piece.piece.Content = ant.piece.Content;
                piece.Num = ant.Num;

                ant.piece.Content = p;
                ant.Num = n;
                
                piece.marked();
                ant.marked();
                numPiece = 0;
               
               
            }

          
        }

       
         private void finish(object sender, MouseEventArgs e)
         {
             if (this.isFinish())
             {
                 this.record.Stop();
                 this.mw.btnPlay.IsEnabled = false;
                 this.mw.fotoShow.IsEnabled = false;
                 fotoOK.Visibility = Visibility.Visible;
                 time.stopCrono();
                 Thread.Sleep(100);
                 this.conPuz.insertTime(DateTime.Now,this.mw.nameUser.Content.ToString(),time.Time,n);
                


             }
         }

     
       
    }
}
