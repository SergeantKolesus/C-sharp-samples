using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    class Matrix<T>
    {
        private T[ , ] matrix;
        private bool initiated;
        private bool symmetric;

        #region Constructors

        public Matrix()
        {
            initiated = false;
        }
        
        public Matrix(int rows, int columns, bool setSymmetric = false)
        {
            initiated = true;
            matrix = new T[rows, columns];
            symmetric = setSymmetric;
        }

        ~Matrix()
        {

        }

        #endregion Constructors

        #region Output functions

        public void Print()
        {
            Form resultForm = new Form();
            TableLayoutPanel panel = new TableLayoutPanel();

            panel.Parent = resultForm;
            resultForm.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            panel.Size = resultForm.Size;
            panel.RowCount = heigth + 1;
            panel.ColumnCount = length + 1;

            resultForm.Show();

            for (int i = 0; i < panel.RowCount; i++)
                panel.RowStyles.Add(new RowStyle { SizeType = SizeType.Percent, Height = 100 / (heigth + 1) });

            for (int i = 0; i < panel.ColumnCount; i++)
                panel.ColumnStyles.Add(new ColumnStyle { SizeType = SizeType.Percent, Width = 100 / (length + 1) });

            Print(panel);
        }

        public void Print(TableLayoutPanel panel)
        {
            int[] size = { matrix.GetLength(0), matrix.GetLength(1) };

            panel.RowCount = size[0] + 1;
            panel.ColumnCount = size[1] + 1;

            for (int i = 0; i < panel.ColumnCount; i++)
                panel.Controls.Add(new Label() { Text = i.ToString() }, i, 0);

            for (int i = 1; i < panel.RowCount; i++)
            {
                panel.Controls.Add(new Label() { Text = i.ToString() }, 0, i);
                for (int j = 1; j < panel.ColumnCount; j++)
                {
                    panel.Controls.Add(new Label() { Text = matrix[i - 1, j - 1].ToString() }, j, i);
                }
            }
        }

        #endregion Output functions

        #region Service

        private void _swap(int i1, int j1, int i2, int j2)
        {
            T temp = matrix[i1, j1];
            matrix[i1, j1] = matrix[i2, j2];
            matrix[i2, j2] = temp;
        }

        public Matrix<T> Transponse()
        {
            Matrix<T> res = new Matrix<T>(heigth, length);

            for(int i = 0; i < length; i++)
                for(int j = 0; j < heigth; j++)
                    res.Set(j, i, matrix[i, j]);

            return res;
        }

        #endregion Service

        static public Matrix<double> Multiply (Matrix<double> first, Matrix<double> second)
        {
            Matrix<double> res = new Matrix<double>(first.length, second.heigth);

            for (int i = 0; i < first.length; i++)
                for (int j = 0; j < second.heigth; j++)
                {
                    res.Set(i, j, 0);
                    for (int k = 0; k < first.heigth; k++)
                    {
                        res.Set(i, j, res.At(i, j) + first.At(i, k) * second.At(k, j));
                    }

                    /*
                    if (i != j)
                        res.Set(i, j, -1 * res.At(i, j));
                        //*/
                        
                }

            return res;
        }

        public Matrix<T> Copy()
        {
            Matrix<T> res = new Matrix<T>(length, heigth);

            for (int i = 0; i < heigth; i++)
                for (int j = 0; j < length; j++)
                    res.Set(i, j, At(i, j));

            return res;
        }

        

        #region Properties

        public T At(int x, int y)
        {
            return matrix[x, y];
        }

        public void Set(int x, int y, T value)
        {
            matrix[x, y] = value;
        }

        public bool isSymmetric
        {
            get
            {
                return symmetric;
            }
        }

        public int length
        {
            get
            {
                return matrix.GetLength(0);
            }
        }

        public int heigth
        {
            get
            {
                return matrix.GetLength(1);
            }
        }

        #endregion Properties

    }
}
