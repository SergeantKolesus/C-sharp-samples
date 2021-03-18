using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomation
{
    class CellularAutomation
    {
        int linearCode;

        public CellularAutomation(int lCode)
        {
            linearCode = lCode;
        }

        private bool f(bool prev, bool cur, bool next)
        {
            int t = (next ? 4 : 0) | (cur ? 2 : 0) | (prev ? 1 : 0);

            return ((linearCode >> t) & 1) == 1;
        }


        /*
         public Bitmap PrintLinear(PictureBox pb, TextBox tb)
        {
            try
            {
                StreamWriter sw = new StreamWriter("Log.txt");
            
                bool[] column;
                int width = pb.Width;
                int heigth = pb.Height;
                bool left;
                bool mid;
                bool rigth;
                Bitmap map = new Bitmap(width, heigth);

                column = new bool[width];
                column[width / 2] = true;
                column[width / 2 + 1] = true;
                column[width / 2 - 1] = true;

                for(int i = 0; i < width; i++)
                {
                    if (i == width / 2)
                        sw.WriteLine();

                    sw.Write(column[i] ? 1 : 0);

                    map.SetPixel(i, 1, !column[i] ? Color.Black : Color.White);
                }

                sw.WriteLine();

                for(int i = 2; i < heigth; i++)
                {
                    left = false;
                    mid = column[0];
                    rigth = column[1];
                    column[0] = f(left, mid, rigth);

                    map.SetPixel(1, i, !column[0] ? Color.Black : Color.White);

                    sw.Write((f(left, mid, rigth) ? 1 : 0));

                    for (int j = 2; j < width; j++)
                    {
                        left = mid;
                        mid = rigth;
                        rigth = column[j];
                        column[j - 1] = f(left, mid, rigth);

                        map.SetPixel(j, i, !column[j - 1] ? Color.Black : Color.White);

                        sw.Write((column[j - 1] ? 1 : 0));

                        if (j == width / 2)
                            sw.WriteLine();
                    }

   

                    left = mid;
                    mid = rigth;
                    rigth = false;

                    column[width - 1] = f(left, mid, rigth);

                    sw.WriteLine();
                    //tb.Text += Environment.NewLine;

                    //pb.Image = map;
                }

                //map.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //pb.Image = map;

                sw.Close();

                return map;
            }
            catch (Exception exc)
            {
                tb.Text += exc;

                return null;
            }
        }
        //*/

        //*
        public Bitmap PrintLinear(PictureBox pb, bool[] startConditions, Color c1, Color c2)
        {
            int iTest;

            try
            {
                StreamWriter sw = new StreamWriter("Log.txt");

                bool[] column;
                int width = pb.Width;
                int heigth = pb.Height;
                bool left;
                bool mid;
                bool rigth;
                int middle = (width + 1) / 2;
                Bitmap map = new Bitmap(width, heigth);
                int startWidth;
                int firstMark;
                int secondMark;
                int leftBorder;
                int rigthBorder;
                
                startWidth = startConditions.Length;
                width = pb.Width + startWidth - 1;
                firstMark = pb.Width / 2;
                secondMark = pb.Width / 2 + startWidth;
                leftBorder = startWidth / 2;
                rigthBorder = width - startWidth / 2;

                if (leftBorder == 0)
                    leftBorder = 1;

                column = new bool[width];

                for(int i = firstMark; i < secondMark; i++)
                {
                    column[i] = startConditions[i - firstMark];
                }

                //column[width / 2] = true;
                //column[width / 2 + 1] = true;
                //column[width / 2 - 1] = true;

                for (int i = 0; i < width; i++)
                {
                    if (i == middle)
                        sw.WriteLine();

                    sw.Write(column[i] ? 1 : 0);

                    iTest = i;

                    if ((i >= leftBorder) && (i < rigthBorder))
                        map.SetPixel(i - leftBorder, 1, column[i] ? c1 : c2);
                }

                sw.WriteLine();

                for (int i = 2; i < heigth; i++)
                {
                    left = false;
                    mid = false;
                    rigth = column[firstMark];

                    column[firstMark - 1] = f(left, mid, rigth);

                    map.SetPixel(firstMark, i, column[firstMark] ? c1 : c2);

                    sw.Write((f(left, mid, rigth) ? 1 : 0));

                    for (int j = firstMark + 1; j < secondMark + 1; j++)
                    {
                        left = mid;
                        mid = rigth;
                        rigth = column[j];
                        column[j - 1] = f(left, mid, rigth);

                        if( (j > leftBorder) && (j < rigthBorder) )
                            map.SetPixel(j - leftBorder, i, column[j - 1] ? c1 : c2);

                        sw.Write((column[j - 1] ? 1 : 0));

                        //if (j == middle)
                        //sw.WriteLine();
                    }



                    left = mid;
                    mid = rigth;
                    rigth = false;

                    column[secondMark] = f(left, mid, rigth);

                    firstMark--;
                    secondMark++;

                    sw.WriteLine();
                    //tb.Text += Environment.NewLine;

                    //pb.Image = map;
                }

                //map.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //pb.Image = map;

                sw.Close();

                return map;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        //*/
    }
}
