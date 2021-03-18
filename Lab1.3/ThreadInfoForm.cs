using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._3
{
    public partial class ThreadInfoForm : Form
    {
        public ThreadInfoForm()
        {
            InitializeComponent();

            timer1.Interval = 0;
            timer1.Start();
        }

        public ThreadInfoForm(string name)
        {
            InitializeComponent();

            infoTB.Text = "Запущен поток. Задача потока - " + name;
            timer1.Interval = 1;
            timer1.Start();

        }

        public void End()
        {
            infoTB.Text += "Работа потока завершена";
            timer1.Stop();
            timerLabel.Text = "Работа потока завершена после " + timer1.Interval / 1000 + " секунд выполнения";
            closeButton.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = "Поток запущен " + timer1.Interval / 1000 + " секунд назад";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
