using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;

namespace Lab6
{
    public partial class Form1 : Form
    {
        Thread assistingThread = null;
        Thread printThread = null;
        ThreadStart assistingThreadStart;
        ThreadStart printThreadStart;
        bool flag = true;

        private RBTree tree = null;

        public Form1()
        {
            InitializeComponent();
        }

        #region Creation

        private void _launchTreeCreation()
        {
            string filename = filenameTB.Text;

            tree = new RBTree();

            try
            {
                StreamReader sr = new StreamReader(filename);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                        if ( (!char.IsLetter(line.ElementAt(i))) && (line.ElementAt(i) != ' ') )
                            line = line.Remove(i--, 1);

                    int spaceLoc;
                    string word;

                    if (line.Length == 0)
                    {
                        //new Form().Show();
                        continue;
                    }

                    while ((spaceLoc = line.IndexOf(' ')) != -1)
                    {
                        word = line.Substring(0, spaceLoc).ToLower();

                        line = line.Remove(0, spaceLoc + 1);

                        tree.AddNode(new RBTreeNode(word));

                        //_launchPrint();
                    }

                    if( (line.Length != 0) && (char.IsLetter(line.ElementAt(0))) )
                        tree.AddNode(new RBTreeNode(line.ToLower()));
                }
            }
            catch (Exception exc)
            {
                ;
            }

            //Form f = new Form();
            //f.ShowDialog();
        }

        private void createTreeButton_Click(object sender, EventArgs e)
        {
            assistingThreadStart = new ThreadStart(_launchTreeCreation);
            assistingThread = new Thread(assistingThreadStart);

            assistingThread.Start();
        }

        #endregion Creation

        #region Printing

        private void _launchPrint()
        {
            Form resultForm = new Form();
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Parent = resultForm;

            /*
            if ( (tree.Root.leftSon == null) && (tree.Root.rigthSon == null) )
            {
                tlp = new TableLayoutPanel();
                tlp.RowCount = 1;
                tlp.ColumnCount = 1;
                tlp.Parent = resultForm;

                tlp.Controls.Add(new TextBox()
                {
                    Text = tree.Root.Value.Word + ":" + tree.Root.Count,
                    Anchor = AnchorStyles.None,
                    BackColor = tree.Root.ColorType == ColorEn.black ? Color.Black : Color.Red,
                    ForeColor = Color.White,
                    //TextAlign = ContentAlignment.MiddleCenter
                },
                        0, 0);

                resultForm.ShowDialog();

                return;
            }
            */

            List<RBTreeNode> nodes;
            RBTreeNode block = new RBTreeNode();
            RBTreeNode nullBlock = new RBTreeNode("  ");
            RBTreeNode temp;
            int deg = 1;
            int count = deg;

            nodes = new List<RBTreeNode>();
            
            List<TableLayoutPanel> panels = new List<TableLayoutPanel>();

            resultForm.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //resultForm.Show();
            //tlp.Size = resultForm.Size;

            bool somethingFound = false;
            bool somethingMissedTwice = false;

            nodes.Add(tree.Root);
            nodes.Add(block);
            count = 0;
            deg = 1;

            tlp = new TableLayoutPanel();
            tlp.RowCount = 1;
            tlp.ColumnCount = 1;
            tlp.Parent = resultForm;

            while (nodes.Count != 0)
            {
                temp = nodes.ElementAt(0);
                nodes.RemoveAt(0);

                if ( (temp != null) && (temp != nullBlock) )
                {
                    tlp.Controls.Add(new TextBox()
                    {
                        BorderStyle = BorderStyle.None,
                        ReadOnly = true,
                        Multiline = true,
                        Text = temp.Value.Word + ":" + temp.Count,
                        Anchor = AnchorStyles.None,
                        BackColor = temp.ColorType == ColorEn.black ? Color.Black : Color.Red,
                        ForeColor = Color.White,
                        //TextAlign = ContentAlignment.MiddleCenter
                    },
                        count, 0);

                    if (temp.leftSon == null)
                        nodes.Add(nullBlock);
                    else
                        nodes.Add(temp.leftSon);

                    if (temp.rigthSon == null)
                        nodes.Add(nullBlock);
                    else
                        nodes.Add(temp.rigthSon);

                    if ((temp.leftSon != null) || (temp.rigthSon != null))
                        somethingFound = true;
                }
                else
                {
                    if (temp == nullBlock)
                        tlp.Controls.Add(new TextBox()
                        {
                            BorderStyle = BorderStyle.None,
                            ReadOnly = true,
                            Multiline = true,
                            Text = "      ",
                            Anchor = AnchorStyles.None,
                            BackColor = Color.Black,
                            ForeColor = Color.White
                        },
                            count, 0);

                    nodes.Add(null);
                    nodes.Add(null);
                }
                count++;

                if (nodes.ElementAt(0) == block)
                {
                    //testPrintTB.Text += Environment.NewLine;
                    nodes.RemoveAt(0);

                    if (somethingFound)
                    {
                        nodes.Add(block);
                        somethingFound = false;
                        deg *= 2;
                        count = 0;

                        panels.Add(tlp);

                        tlp = new TableLayoutPanel();
                        tlp.RowCount = 1;
                        tlp.ColumnCount = deg;
                        tlp.Parent = resultForm;
                    }
                    else
                    {
                        /*
                         * if (!somethingMissedTwice)
                            somethingMissedTwice = true;
                        else
                        //*/
                            break;
                    }
                }
            }

            panels.Add(tlp);

            double heigth = 100 / panels.Count;
            double step = resultForm.Height / panels.Count;
            TableLayoutPanel tempTLP;

            for (int i = 0; i < panels.Count; i++)
            {
                tempTLP = panels.ElementAt(0);
                panels.RemoveAt(0);
                panels.Add(tempTLP);

                tempTLP.Height = (int)step;
                tempTLP.Width = resultForm.Width;

                tempTLP.Location = new Point(0, (int)(step * i));

                tempTLP.RowStyles.Add(new RowStyle { SizeType = SizeType.Percent, Height = 100 });

                double colWidth = resultForm.Width / tempTLP.ColumnCount;

                //*
                for (int j = 0; j < tempTLP.ColumnCount; j++)
                {
                    tempTLP.ColumnStyles.Add(new ColumnStyle { SizeType = SizeType.Absolute, Width = (int)colWidth });
                    //tempTLP.Controls.Add(new Label() { Text = "Check" }, 0, j);
                }
                //*/
            }

            resultForm.ShowDialog();
        }

        private void treePrintButton_Click(object sender, EventArgs e)
        {
            if (tree == null)
                tree = new RBTree();

            if (tree.Root == null)
            {
                dictionaryTB.Text += "Пустое дерево, нечего выводить" + Environment.NewLine;
                return;
            }

            printThreadStart = new ThreadStart(_launchPrint);
            printThread = new Thread(printThreadStart);

            printThread.Start();
        }

        #endregion Printing

        #region Adding

        private void _launchNodeAdding()
        {
            if (tree == null)
                tree = new RBTree();

            

            tree.AddNode(new RBTreeNode(elementTB.Text));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            assistingThreadStart = new ThreadStart(_launchNodeAdding);
            assistingThread = new Thread(assistingThreadStart);

            assistingThread.Start();
        }

        #endregion Adding


        private void timer1_Tick(object sender, EventArgs e)
        {
            flag = true;

            if ((assistingThread == null) || (!assistingThread.IsAlive))
                treePrintButton.Enabled = true;
            else
                treePrintButton.Enabled = false;
        }

        #region Searching

        private void _launchSearching()
        {
            _search();
        }

        private RBTreeNode _search(bool print = true)
        {
            if(tree == null)
            {
                if(print)
                    foundElementLabel.Text = "Nowhere to search";
                return null;
            }

            RBTreeNode node;
            WordClass word = new WordClass(elementTB.Text);
            Queue<int> route = new Queue<int>();

            node = tree.Root;

            while(node != null)
            {
                if (word < node.Value)
                {
                    node = node.leftSon;
                    route.Enqueue(0);
                    continue;
                }

                if (word > node.Value)
                {
                    node = node.rigthSon;
                    route.Enqueue(1);
                    continue;
                }

                
                    if (word == node.Value)
                    {
                        if (print)
                        {

                            foundElementLabel.Text = "Elemnt color: " + node.Color + ", element count: " + node.Count;

                            routeLabel.Text = "Route: ";

                            while (route.Count != 0)
                                routeLabel.Text += " " + (route.Dequeue() == 0 ? "left" : "rigth");
                        }
                        return node;
                    }
            }

            return null;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            //*
            assistingThreadStart = new ThreadStart(_launchSearching);
            assistingThread = new Thread(assistingThreadStart);

            assistingThread.Start();
            //*/

            //_launchSearching();
        }

        #endregion Searching

        #region Deleting

        private void _launchDeleting()
        {
            RBTreeNode node;

            node = _search(false);

            if (node == null)
            {
                dictionaryTB.Text += "Узел для удаления не найден";
                return;
            }

            tree.DeleteNode(node);

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (tree == null)
            {
                dictionaryTB.Text += "В пустом дереве нет узлов для удаления";
                return;
            }

            assistingThreadStart = new ThreadStart(_launchDeleting);
            assistingThread = new Thread(assistingThreadStart);

            assistingThread.Start();
        }

        #endregion Deleting

        #region Printing

        private void _printNode(RBTreeNode node)
        {
            if(node.leftSon != null)
                _printNode(node.leftSon);

            

            dictionaryTB.Text += node.Value.Word + " : " + node.Count + Environment.NewLine;

            if (node.rigthSon != null)
                _printNode(node.rigthSon);
        }

        private void _launchNormallPrinting()
        {
            dictionaryTB.Text = "";

            if ( (tree != null) && (tree.Root != null) )
                _printNode(tree.Root);
            else
                dictionaryTB.Text = "Empty dictionary";
        }

        private void printNormallyButton_Click(object sender, EventArgs e)
        {
            assistingThreadStart = new ThreadStart(_launchNormallPrinting);
            assistingThread = new Thread(assistingThreadStart);

            assistingThread.Start();
        }

        #endregion Printing

        private void createEmptyButton_Click(object sender, EventArgs e)
        {
            tree = new RBTree();
        }
    }
}