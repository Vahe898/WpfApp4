using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiceInfo.PiceClasses
{
    public class Queen : Pice
    {
        int[,] moves = new int[8, 8];
        private PiceColor color;
        private Position pos;
        public override int Cost
        {
            get
            {
                
                    return 2;
                
            }
        }
        public Position Posit
        {
            get { return pos; }
        }
        public override PiceColor Color
        {
            get { return color; }
            set
            {
                if (value == PiceColor.White)
                {
                    color = PiceColor.White;
                }
                else
                {
                    color = PiceColor.Black;
                }
            }
        }


        public override PiceType Type => PiceType.Queen;

        public override int[,] Moves() /*=> moves;*/
        {
           
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (pos.Row == i && pos.Column != j)
                        {
                            if (Color == PiceColor.White)
                            {
                                moves[i, j] = 21;
                            }
                            else
                            {
                                moves[i, j] = 22;
                            }
                        }
                        /*uxxahayaca etum nuyn cev*/
                        else if (pos.Row != i && pos.Column == j)
                        {
                            if (Color == PiceColor.White)
                            {
                                moves[i, j] = 21;
                            }
                            else
                            {
                                moves[i, j] = 22;
                            }
                        }
                        else if (pos.Row == i && pos.Column == j)
                        {
                            moves[i, j] = Cost;
                        }
                        /*diaganalov*/
                        else if (Math.Abs(pos.Row - i) == Math.Abs(pos.Column - j))
                        {
                            if (Color == PiceColor.White)
                            {
                                moves[i, j] = 21;
                            }
                            else
                            {
                                moves[i, j] = 22;
                            }
                        }

                    }
                }
                return moves;
            
        }

        public override Position position => pos;

        public override string ImagePath()
        {
            if (this.color == PiceColor.Black)
            {
                return "pack://application:,,,/FigurImage/QueenB.png";
            }
            else
            {
                return "pack://application:,,,/FigurImage/QueenW.png";
            }
        }
        public Queen(Position pos, PiceColor color)
        {
            Color = color;
            this.pos = pos;
        }
        //public int[,] ClearMatric()
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {

        //            Moves[i, j] = 0;

        //        }

        //    }
        //    return Moves;
        //}
        //public int[,] MatricOfQueen()
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (pos.Row == i && pos.Column != j)
        //            {
        //                if (Color == PiceColor.White)
        //                {
        //                    Moves[i, j] = Cost;
        //                }
        //                else
        //                {
        //                    Moves[i, j] = Cost;
        //                }
        //            }
        //            /*uxxahayaca etum nuyn cev*/
        //            else if (pos.Row != i && pos.Column == j)
        //            {
        //                if (Color == PiceColor.White)
        //                {
        //                    Moves[i, j] = 21;
        //                }
        //                else
        //                {
        //                    Moves[i, j] = 22;
        //                }
        //            }
        //            else if (pos.Row == i && pos.Column == j)
        //            {
        //                Moves[i, j] = 2;
        //            }
        //            /*diaganalov*/
        //            else if (Math.Abs(pos.Row - i) == Math.Abs(pos.Column - j))
        //            {
        //                if (Color == PiceColor.White)
        //                {
        //                    Moves[i, j] = 21;
        //                }
        //                else
        //                {
        //                    Moves[i, j] = 22;
        //                }
        //            }
                    
        //        }
        //    }
        //    return Moves;
        //}
    }
}
