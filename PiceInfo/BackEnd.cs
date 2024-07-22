using PiceInfo.PiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiceInfo
{
    public class BackEnd
    {

        int[,] All = new int[8, 8];
        private List<Pice> _blackPices = new List<Pice>();
        private List<Pice> _whitePices = new List<Pice>();  
        private int Count = 0;

        private Pice GetPiceInfo(int row,int col)
        {
            
            foreach (var item in _blackPices)
            {
                if(item.position.Row == row && item.position.Column == col)
                {
                    return item;
                }

            }
            foreach (var item in _whitePices)
            {
                if (item.position.Row == row && item.position.Column == col)
                {
                    return item;
                }
            }
            return null;
        }
        public void Addd(Pice pice)
        {
            if (pice.Color == PiceColor.White)
            {
                _whitePices.Add(pice);
            }
            else if(pice.Color == PiceColor.Black)
            {
                _blackPices.Add(pice);
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(i==pice.position.Row && j == pice.position.Column)
                    {
                        All[i, j] = pice.Cost;
                    }
                }
            }
        }
        public int[,] PiceCanMove(Pice pice)
        {
            int[,] arr = Compare(pice);
            return arr;

        }
        //public void Add(int[,] arr)
        //{
        //    if (Count >= 1)
        //    {
        //        int[,] comperaedArr = Compare(arr);
        //        for (int i = 0; i < 8; i++)
        //        {
        //            for (int j = 0; j < 8; j++)
        //            {


        //                if (All[i, j] == 0 && comperaedArr[i, j] != 0)
        //                {
        //                    All[i, j] = comperaedArr[i, j];
        //                }

        //            }
        //        }
        //    }
        //    else if (Count == 0)
        //    {
        //        for (int i = 0; i < 8; i++)
        //        {
        //            for (int j = 0; j < 8; j++)
        //            {

        //                if (Count == 0)
        //                {

        //                    if (All[i, j] == 0 && arr[i, j] != 0)
        //                    {
        //                        All[i, j] = arr[i, j];
        //                    }
        //                    //else if (All[i, j] != 0 && arr[i, j] != 0)
        //                    //{
        //                    //    All[i, j] = 8;
        //                    //}
        //                }
                       
        //            }
        //        }
        //    }
        //    Count++;
        //}
        public int MatrixVal(int row,int column)
        {
            return All[row,column];
        }
        private int[,] Compare(Pice pice)
        {
            
            int[,] comp = (int[,])pice.Moves().Clone();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((comp[i,j]>10 && All[i,j]!=0 && All[i,j]<=10))
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            if (comp[k,j]<10 && comp[k,j] != 0)
                            {
                                /*nerqeva yngnum avelacracy*/
                                if (k > i)
                                {
                                    for (int f = i-1; f >= 0; f--)
                                    {
                                        comp[f, j] = 0;
                                    }
                                    ///*udari taka*/
                                    if (All[i, j] < 10 && GetPiceInfo(i,j).Color != pice.Color )
                                    {
                                        comp[i, j] = comp[i, j] * 10;
                                    }

                                }
                                /*vreva yngnum avelacracy*/
                                else if(k<i)
                                {
                                    for (int f = i + 1; f <8 ; f++)
                                    {
                                        comp[f, j] = 0;
                                    }
                                    ///*udari taka*/
                                    //if (All[i, j] < 10)
                                    //{
                                    //    All[i, j] = All[i, j] * 10;
                                    //}
                                }
                            }
                            else if (comp[i,k]<10 && comp[i,k] != 0)
                            {
                                /*aja yngnum avelacracy*/
                                if (k > j)
                                {
                                    for (int f = j - 1; f >= 0; f--)
                                    {
                                        comp[i, f] = 0;
                                    
                                    }
                                    ///*udari taka*/
                                    //if (All[i, j] < 10)
                                    //{
                                    //    All[i, j] = All[i, j] * 10;
                                    //}
                                }
                                /*caxa yngnum avelacracy*/
                                if (k < j)
                                {
                                    for (int f = j + 1; f < 8; f++)
                                    {
                                        comp[i, f] = 0;
                                    }
                                    ///*udari taka*/
                                    //if (All[i, j] < 10)
                                    //{
                                    //    All[i, j] = All[i, j] * 10;
                                    //}
                                }
                            }
                            else if ((i+k)<8 && (j+k)<8 && comp[i+k,j+k]<10&& comp[i + k, j + k] != 0)
                            {
                                /*orinak taguhi u tagavor tagavory diaganalov cax vereva yngnum*/
                                int f = 1;
                                while (i-f>=0 && j-f>=0)
                                {                                   
                                    comp[i - f, j - f] = 0;
                                    f++;
                                }
                                
                                ///*udari taka*/
                                //if (All[i, j] < 10)
                                //{
                                //    All[i, j] = All[i, j] * 10;
                                //}
                            }
                            else if ((i+k)<8 && (j-k)>=0 && comp[i + k, j - k] < 10 && comp[i + k, j - k] != 0)
                            {
                                /*orinak taguhi u tagavor tagavory diaganalov aj vereva yngnum*/
                                int f = 1;
                                while (i + f < 8 && j - f >= 0)
                                {
                                    comp[i - f, j - f] = 0;
                                    f++;
                                }
                                //for (int f = 0; f >= 0; f--)
                                //{
                                //    comp[i + f, j - f] = 0;
                                //}
                                ///*udari taka*/
                                //if (All[i, j] < 10)
                                //{
                                //    All[i, j] = All[i, j] * 10;
                                //}
                            }
                            else if ((i-k)>=0 && (j-k)>=0 && comp[i - k, j - k] < 10 && comp[i - k, j - k] != 0)
                            {
                                /*orinak taguhi u tagavor tagavory diaganalov aj nerqev yngnum*/
                                int f = 1;
                                while (i + f <8  && j + f < 8)
                                {
                                    comp[i + f, j + f] = 0;
                                    f++;
                                }

                                ///*udari taka*/
                                //if (All[i, j] < 10)
                                //{
                                //    All[i, j] = All[i, j] * 10;
                                //}
                            }
                            else if( (i-k)>=0 && (j+k)<8 && comp[i - k, j + k] < 10 && comp[i - k, j + k] != 0)
                            {
                                int f = 1;
                                while (i + f < 8 && j - f >=0)
                                {
                                    comp[i + f, j - f] = 0;
                                    f++;
                                }

                                ///*udari taka*/
                                //if (All[i, j] < 10)
                                //{
                                //    All[i, j] = All[i, j] * 10;
                                //}
                            }



                        }
                    }
                }
            }
            return comp;
        }
    }
}
