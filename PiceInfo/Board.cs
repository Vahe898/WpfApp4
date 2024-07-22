using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiceInfo
{
    public class Board
    {
        Pice[,] pices = new Pice[8, 8];

        public void Add(Pice pice,Position pos)
        {
            pices[pos.Row,pos.Column] = pice;
        }
        public bool Valid(Position pos)
        {
            if (pices[pos.Row,pos.Column] == null)
            {
                return false;
            }
            return true;
        }
        public bool Valid(int row ,int column)
        {
            if (pices[row, column] == null)
            {
                return false;
            }
            return true;
        }
        public string GettingImagePath(int row, int column)
        {
            
            return pices[row, column].ImagePath();
        }
        public Pice Selected(Position pos)
        {
            return pices[pos.Row, pos.Column];
        }
    }
}
