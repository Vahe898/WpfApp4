using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PiceInfo.PiceClasses
{
    public class King : Pice
    {
        int[,] moves = new int[8, 8];
        private PiceColor color;       
        private Position pos;
        public override int Cost
        {
            get
            {                
                    return 1;
                              
            }
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


        public override PiceType Type => PiceType.King;

        public override int[,] Moves()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pos.Column == j || pos.Column + 1 == j || pos.Column - 1 == j)
                    {
                        if (pos.Row == i || pos.Row + 1 == i || pos.Row - 1 == i)
                        {
                            if (pos.Column == j && pos.Row == i)
                            {
                                moves[i, j] = Cost;
                            }
                            else
                            {
                                if (Color == PiceColor.White)
                                {
                                    moves[i, j] = 11;
                                }
                                else
                                {
                                    moves[i, j] = 12;
                                }

                            }
                        }
                    }
                }

            }
            return moves;
        }

        public override Position position { get =>  pos; }

        public override string ImagePath()
        {
            if (this.color == PiceColor.Black)
            {
                return "pack://application:,,,/FigurImage/KingB.png";
            }
            else
            {
                return "pack://application:,,,/FigurImage/KingW.png";
            }
        }

        public King(Position pos,PiceColor color)
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
                    
        //           Moves[i, j] = 0;
                            
        //        }

        //    }
        //    return Moves;
        //}
        //public int[,] MatricOfKing()
        //{
        //    ClearMatric();
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (pos.Column == j || pos.Column + 1 ==j || pos.Column - 1 == j)
        //            {
        //                if (pos.Row == i || pos.Row + 1 == i || pos.Row - 1 == i)
        //                {
        //                    if(pos.Column == j && pos.Row == i)
        //                    {
        //                        Moves[i, j] = 1;
        //                    }
        //                    else
        //                    {
        //                        if(Color == PiceColor.White)
        //                        {
        //                            Moves[i, j] = Cost;
        //                        }
        //                        else
        //                        {
        //                            Moves[i, j] = Cost;
        //                        }
                                
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    return Moves;
        //}



    }
}
