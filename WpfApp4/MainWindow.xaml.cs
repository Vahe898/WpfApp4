using PiceInfo;
using PiceInfo.PiceClasses;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool gameStart;
        Board board = new Board();
        BackEnd back = new BackEnd();
        Pice SelectedPice;
        Position SelectedPosition = new Position();
        
        
        public MainWindow()
        {
            InitializeComponent();            
            DrawChessboard();
        }

       

        public class PictureAndText
        {
            public string ImagePath { get; set; }
            public string Text { get; set; }
        }

        private void ChoosColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItemContent = ((ComboBoxItem)ChoosColor.SelectedItem).Content.ToString();

            switch (selectedItemContent)
            {
                case "White":
                    
                    ChooseFigur.Items.Clear();
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/BishopW.png", Text = "Bishop" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/RookW.png", Text = "Rook" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/QueenW.png", Text = "Queen" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/KingW.png", Text = "King" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/KnightW.png", Text = "Knight" });
                    break;
                case "Black":
                    ChooseFigur.Items.Clear();
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/BishopB.png", Text = "Bishop" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/RookB.png", Text = "Rook" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/QueenB.png", Text = "Queen" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/KingB.png", Text = "King" });
                    ChooseFigur.Items.Add(new PictureAndText() { ImagePath = "FigurImage/KnightB.png", Text = "Knight" });
                    break;
                case "Selecting":
                    ChooseFigur.Items.Clear();
                    
                    break;
                default:
                    break;
            }

        }
        
        private void ChessBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;
            Point mousePosition = e.GetPosition(ChessBoard);

            // Calculate the row and column indices
            int row = (int)(mousePosition.Y / ChessBoard.ActualHeight * ChessBoard.RowDefinitions.Count);
            int column = (int)(mousePosition.X / ChessBoard.ActualWidth * ChessBoard.ColumnDefinitions.Count);

            Position pos = new Position(row, column);
            if (!gameStart)
            {
                string selectedItemContentOfFigur;
                string selectedItemContentOfColor;
                if (ChooseFigur.SelectedItem != null)
                {
                    PictureAndText selectedFigur = (PictureAndText)ChooseFigur.SelectedItem;
                    selectedItemContentOfFigur = selectedFigur.Text;
                    // Do something with itemText, like display it or use it in further processing
                    if (ChoosColor.SelectedItem != null)
                    {
                        selectedItemContentOfColor = ((ComboBoxItem)ChoosColor.SelectedItem).Content.ToString();
                        // Do something with selectedItem, like display it or use it in further processing
                        if (selectedItemContentOfFigur != null && selectedItemContentOfColor != null)
                        {
                            switch (selectedItemContentOfColor)
                            {
                                case "White":
                                    switch (selectedItemContentOfFigur)
                                    {
                                        case "King":
                                            King KingW = new King(pos, PiceColor.White);
                                            board.Add(KingW,pos);
                                            back.Addd(KingW);
                                            break;
                                        case"Queen":
                                            Queen QueenW = new Queen(pos, PiceColor.White);
                                            board.Add(QueenW,pos);
                                            back.Addd(QueenW);
                                            break;

                                    }
                                    break;
                                case "Black":
                                    switch (selectedItemContentOfFigur)
                                    {
                                        case "King":
                                            King KingB = new King(pos, PiceColor.Black);
                                            board.Add(KingB, pos);
                                            back.Addd(KingB);
                                            break;
                                        case "Queen":
                                            Queen QueenB = new Queen(pos, PiceColor.Black);
                                            board.Add(QueenB, pos);
                                            back.Addd(QueenB);
                                            break;
                                    }


                                    break;
                            }
                        }
                    }
                }

            }
            else if (gameStart)
            {
                SelectedPice = board.Selected(pos);
                SelectedPosition = pos;
            }
            DrawChessboard();
        }
        //private void DrawChessboard()
        //{

        //    int numRows = 8;
        //    int numCols = 8;

        //    // Calculate the size of each square
        //    double squareSize = 50;

        //    // Loop to create the squares
        //    for (int row = 0; row < numRows; row++)
        //    {
        //        for (int col = 0; col < numCols; col++)
        //        {
        //            Rectangle square = new Rectangle();
        //            square.Width = squareSize;
        //            square.Height = squareSize;

        //            // Set alternating colors based on row and column
        //            if (board.Valid(row, col))
        //            {
        //                Image image = new Image();
        //                string a =board.GettingImagePath(row, col);
        //                BitmapImage bitmapImage = new BitmapImage(new Uri(board.GettingImagePath(row, col)));
        //                image.Source = bitmapImage;
        //                Grid.SetRow(image, row);
        //                Grid.SetColumn(image, col);
        //                // Replace the clicked rectangle with the image                
        //                ChessBoard.Children.Add(image);
        //            }
        //            else if ((row + col) % 2 == 0)
        //            {
        //                square.Fill = Brushes.LightGoldenrodYellow; // Light color
        //            }
        //            else if ((row + col) % 2 != 0)
        //            {
        //                square.Fill = Brushes.SaddleBrown; // Dark color
        //            }



        //            // Add the square to the Grid
        //            ChessBoard.Children.Add(square);

        //            // Position the square in the Grid
        //            Grid.SetRow(square, row);
        //            Grid.SetColumn(square, col);
        //        }
        //    }
        //}
        private void DrawChessboard()
        {
            

            double squareSize = 50;

            // Loop to create the squares
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    
                    if (board.Valid(row, col))
                    {
                        // Create an Image and set its source
                        Image image = new Image();
                        BitmapImage bitmapImage = new BitmapImage(new Uri(board.GettingImagePath(row, col)));
                        image.Source = bitmapImage;

                        // Set the size of the image (assuming square size)
                        image.Width = squareSize;
                        image.Height = squareSize;

                        // Position the image in the Grid
                        Grid.SetRow(image, row);
                        Grid.SetColumn(image, col);

                        // Add the image to the ChessBoard grid
                        ChessBoard.Children.Add(image);
                    }
                    
                    else
                    {
                        // Create a Rectangle for the square
                        Rectangle square = new Rectangle();
                        square.Width = squareSize;
                        square.Height = squareSize;

                        // Set alternating colors based on row and column
                        
                        if ((row + col) % 2 == 0)
                        {
                            square.Fill = Brushes.LightGoldenrodYellow; // Light color
                        }
                        else
                        {
                            square.Fill = Brushes.SaddleBrown; // Dark color
                        }
                        if (gameStart)
                        {
                            //if (SelectedPice.Moves[row, col] != 0 && back.MatrixVal(row,col)!=0)
                            //{

                            //    square.Fill = Brushes.Green;
                            //}
                            if (back.PiceCanMove(SelectedPice)[row,col] != 0)
                            {
                                square.Fill = Brushes.Green;
                                if ()
                                {


                                }
                            }

                        }


                        // Position the square in the Grid
                        Grid.SetRow(square, row);
                        Grid.SetColumn(square, col);

                        // Add the square to the ChessBoard grid
                        ChessBoard.Children.Add(square);
                    }
                }
            }
           
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            gameStart = true;
        }
    }
}