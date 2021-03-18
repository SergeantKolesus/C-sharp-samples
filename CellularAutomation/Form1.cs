using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Policy;

namespace CellularAutomation
{
    public partial class Form1 : Form
    {
        Thread secondThread;

        private void _prepareWindow()
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;


            automationPB.Width = this.Width;
            automationPB.Height = this.Width / 2;
        }

        private void _printMap(Bitmap map, PictureBox pb)
        {
            if (map != null)
                pb.Image = map;
            else
                consoleTB.Text += "Error";
        }

        public Form1()
        {
            InitializeComponent();

            screenWidthTB.Text = Screen.PrimaryScreen.Bounds.Width.ToString();

            /*
            _prepareWindow();
            
            Bitmap map = null;
            CellularAutomation ca = new CellularAutomation(30);

            ThreadStart ts = () => map = ca.PrintLinear(automationPB, consoleTB);
            ts += () => _printMap(map);

            secondThread = new Thread(ts);

            secondThread.Start();
            ***/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( (secondThread != null) && (secondThread.IsAlive))
                secondThread.Abort();
        }

        private void _showForm(Form f)
        {
            f.ShowDialog();
        }

        private void _markCompletion(TextBox tb)
        {
            tb.Text = "Done";
        }

        private bool[] _getStartCond()
        {
            string s = customRowTB.Text;
            bool[] res = new bool[s.Length];
            int j = 0;

            for(int i = 0; i < s.Length; i++)
            {
                switch(s.ElementAt(i))
                {
                    case '0':
                        res[i] = false;
                        break;
                    case '1':
                        res[i] = true;
                        break;
                    default:
                        j++;
                        break;
                }
            }

            if (j == 0)
            {
                Console.WriteLine("Начальные условия корректны" + Environment.NewLine);
                return res;
            }
            else
            {
                Console.WriteLine("Некорректные символы в строке начальных условий. " + j + " символов были прогинорированы" + Environment.NewLine);

                bool[] t = new bool[s.Length - j];

                for (int i = 0; i < s.Length - j; i++)
                    t[i] = res[i];

                return t;
            }
        }

        private bool[] _getRandomStartConditions(int width)
        {
            bool[] res;
            int minWidth;
            int maxWidth;
            Random r = new Random();

            try
            {
                minWidth = minWidthCB.Checked ? int.Parse(minWidthTB.Text) : 1;
            }
            catch
            {
                consoleTB.Text += "Ошибка получения минимальной ширины. Установлено значение по умолчанию равное 1." + Environment.NewLine;
                minWidthTB.Text = "1";
                minWidth = 1;
            }

            try
            {
                maxWidth = maxWidthCB.Checked ? int.Parse(maxWidthTB.Text) : width;
            }
            catch
            {
                consoleTB.Text += "Ошибка получения максимамльной ширины. Установлено значение по умолчанию равное ширине ряда." + Environment.NewLine;
                maxWidthTB.Text = width.ToString();
                maxWidth = width;
            }

            if(maxWidth > width)
            {
                consoleTB.Text += "Максимальная ширина начальных условий была уменьшена до ширины ряда." + Environment.NewLine;
                maxWidthTB.Text = width.ToString();
                maxWidth = width;
            }

            consoleTB.Text += "Случайные начальный " + Environment.NewLine;

            int condWidth = (int)Math.Round(r.NextDouble() * (maxWidth - minWidth) + minWidth);
            res = new bool[condWidth];

            consoleTB.Text += "Ширина случайных начальных условий: " + condWidth + Environment.NewLine + "Начальные условия:";

            for (int i = 0; i < condWidth; i++)
            {
                res[i] = Math.Round(r.NextDouble()) == 0 ? false : true;
                consoleTB.Text += res[i] ? 1 : 0;
            }

            consoleTB.Text += Environment.NewLine;

            return res;
        }

        private void monocelllularCreate_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            PictureBox pb = new PictureBox();
            Bitmap map = null;
            CellularAutomation ca; // = new CellularAutomation(30);
            int code;
            int width;
            int height;

            //pb.Parent = f;
            //t.Parent = f;

            try
            {
                if (screenWidthRB.Checked)
                {
                    width = Screen.PrimaryScreen.Bounds.Width;
                }
                else
                {
                    width = int.Parse(userWidthTB.Text);

                    if(width < 0)
                    {
                        width = -width;
                        consoleTB.Text += "Отрицательная ширина заменена на полижительную" + Environment.NewLine;
                        userWidthTB.Text = width.ToString();
                    }

                    if(width == 0)
                    {
                        consoleTB.Text += "Нулевая ширина недопустима" + Environment.NewLine;
                        return;
                    }
                }
            }
            catch
            {
                width = Screen.PrimaryScreen.Bounds.Width;
            }

            height = width / 2;

            f.Show();

            f.Width = width;
            f.Height = height;

            f.Controls.Add(pb);

            pb.Width = width;
            pb.Height = height;
            //pb.Location = new Point(0, 0);

            try
            {
                code = int.Parse(codeTB.Text);
            }
            catch
            {
                code = 160;
                codeTB.Text = "160";
                consoleTB.Text += "Ошибка обработки кода. Установлено значение по умолчанию равное 160." + Environment.NewLine;
            }

            bool[] startCond = null;

            try
            {


                if (soloOneRB.Checked)
                    startCond = new bool[] { true };

                if (zeroRowRB.Checked)
                    startCond = new bool[] { false };

                if (customInputRowRB.Checked)
                    startCond = _getStartCond();

                if (randomInputRB.Checked)
                    startCond = _getRandomStartConditions(width);
            }
            catch
            {
                startCond = new bool[] { true };

                consoleTB.Text += "Ошибка задания начальных условий. Заданы начальные условия по уммолчанию: единица." + Environment.NewLine;
            }

            Color c1;
            Color c2;

            if(inverseCB.Checked)
            {
                c1 = Color.White;
                c2 = Color.Black;
            }
            else
            {
                c1 = Color.Black;
                c2 = Color.White;
            }

            ca = new CellularAutomation(code);

            if (startCond.Length % 2 != width % 2)
                consoleTB.Text += "Внимание. Ширина начальных условий и поля разной четности." + Environment.NewLine;
            

            ThreadStart ts = () => map = ca.PrintLinear(pb, startCond, c1, c2);
            ts += () => _printMap(map, pb);
            //ts += () => _markCompletion(t);

            secondThread = new Thread(ts);

            secondThread.Start();

            


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void customInputRowRB_CheckedChanged(object sender, EventArgs e)
        {
            customRowTB.Enabled = customInputRowRB.Checked;
        }

        private void randomInputRB_CheckedChanged(object sender, EventArgs e)
        {
            randomGB.Enabled = randomInputRB.Checked;
        }

        private void minWidthCB_CheckedChanged(object sender, EventArgs e)
        {
            minWidthTB.Enabled = minWidthCB.Checked;
        }

        private void maxWidthCB_CheckedChanged(object sender, EventArgs e)
        {
            maxWidthTB.Enabled = maxWidthCB.Checked;
        }

        
    }
}
