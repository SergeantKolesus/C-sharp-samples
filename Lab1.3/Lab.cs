using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.CodeDom;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Diagnostics.Tracing;

namespace Lab1._3
{
    public partial class s : Form
    {
        public s()
        {
            InitializeComponent();
        }

        NewGraph graph; //Граф
        Thread graphThread; //Дополнительный поток, для запуска алгоритмов на графе

        /*
         * Содержит поля и методы, связанные с генерацией случайного графа
         */
        #region Generation

        double a = 1;
        double c = 3;
        private double F(double x)
        {
            return 1 - Math.Exp(-Math.Pow(x / a, c));

        }

        private void _generateGraph(double min, double max)
        {
            int nodes;
            int edges;
            ThreadInfoForm tif = new ThreadInfoForm("генерация графа");
            tif.Show();

            try
            {
                nodes = int.Parse(nodesAmountTB.Text);
                edges = int.Parse(edgesAmountTB.Text);
            }
            catch
            {
                nodes = 10;
                edges = 13;
                new Form().ShowDialog();
            }
            graph = new NewGraph(nodes, edges);

            NewGraph.fDelegate f = new NewGraph.fDelegate(F);
            graph.Generate(f, min, max);
            graph.CheckConnections();

            tif.End();

            graph.updateRoutesTB += new EventHandler<EventArgString>(UpdateRoutesTextBox);
            graph.updateAstilTB += new EventHandler<EventArgString>(UpdateAstilTextBox);
            graph.updateTSPTB += new EventHandler<EventArgString>(UpdateRoutesTextBox);
            graph.updateNetTB += new EventHandler<EventArgString>(UpdateNetTextBox);

            ///sinkTB.Text = graph.vertices.ToString();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if ((graphThread != null) && (graphThread.IsAlive))
                return;

            double min;
            double max;
            //*
            try
            {
                min = double.Parse(minWeightTB.Text);
                max = double.Parse(maxWeightTB.Text);
            }
            catch
            {
                errorLogTB.Text += "Ошибка получения веса ребер, установлены значения по умолчанию." + Environment.NewLine;
                minWeightTB.Text = "0";
                maxWeightTB.Text = "50";

                min = 0;
                max = 50;
            }

            graphThread = new Thread(() => _generateGraph(min, max));
            graphThread.Start();

            /*
            assistingThread = new Thread(() => _generateGraph(min, max));
            //new ParameterizedThreadStart(_generateGraph)) ;

            assistingThread.Start();

            threadsInfoLabel = new Label();
            threadsInfoLabel.Location = threadsInfoLabelLocation;
            threadsInfoLabel.Text = "In use";

            isEulerLabel.Text = "Unchecked";
            isHamiltonLabel.Text = "Unchecked";
            //*/
        }


        #endregion Generation

        /*
         * Содержит методы, обеспечивающие вывод данных
         */
        #region Representation

        private void showNodesAdjButton_Click(object sender, EventArgs e)
        {
            graph.FormTablePrint(NewGraph.matrixes_en.oriented);
        }

        private void showSymmetricButton_Click(object sender, EventArgs e)
        {
            graph.PrintSymmetric();
        }

        private void astilButton_Click(object sender, EventArgs e)
        {
            graph.PrintAstil();
        }

        private void showKirchoffButton_Click(object sender, EventArgs e)
        {
            graph.PrintKirchoff();
        }

        private void showEulerButton_Click(object sender, EventArgs e)
        {
            graph.PrintEuler();
        }

        private void showHamiltonButton_Click(object sender, EventArgs e)
        {
            graph.PrintHamilton();
        }

        private void printStreamButton_Click(object sender, EventArgs e)
        {
            graph.PrintStream();
        }

        private void printPriceButton_Click(object sender, EventArgs e)
        {
            graph.PrintPrice();
        }

        private void maxStreamMatrix_Click(object sender, EventArgs e)
        {
            graph.PrintMaxStream();
        }

        private void incidencyButton_Click(object sender, EventArgs e)
        {
            graph.GetIncidenceMatrix().Print();
        }

        private void printTSPButton_Click(object sender, EventArgs e)
        {
            int count = graph.TSPRoutes.Count;

            TSPTB.Text += "Кратчайший путь:" + Environment.NewLine;

            for (int i = 0; i <= graph.vertices; i++)
                TSPTB.Text += ((graph.TSPRoutes.ElementAt(graph.ShortesTSPRouteNumber)).ElementAt(i) + 1) + " ";

            TSPTB.Text += Environment.NewLine + "Длина пути: " + graph.ShortesTSPRouteLength + Environment.NewLine;

            if (count > 16)
            {
                TSPTB.Text += "Слишком большое число путей(" + count + " ). Вывод производится в файл" + Environment.NewLine;
                printTSPToFileButton_Click(null, null);
                return;
            }

            TSPTB.Text += "Дина кратчайшего пути: " + graph.ShortesTSPRouteLength + Environment.NewLine +
                    "Всего путей: " + graph.TSPRoutes.Count + Environment.NewLine;

            for (int i = 0; i < count; i++)
            {
                
                for (int j = 0; j <= graph.vertices; j++)
                    TSPTB.Text += ((graph.TSPRoutes.ElementAt(i)).ElementAt(j) + 1) + " ";
                TSPTB.Text += "| " + graph.TSPRoutesLengths.ElementAt(i) + Environment.NewLine;
            }
        }

        private void printTSPToFileButton_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Res.txt");

            sw.Write("Кратчайший путь: ");

            for (int j = 0; j <= graph.vertices; j++)
                sw.Write(((graph.TSPRoutes.ElementAt(graph.ShortesTSPRouteNumber)).ElementAt(j) + 1) + " ");

            sw.WriteLine();

            sw.WriteLine("Его длина " + graph.ShortesTSPRouteLength);
            sw.WriteLine("Всего гамильтоновых путей: " + graph.TSPRoutes.Count);

            for (int i = 0; i < graph.TSPRoutes.Count; i++)
            {
                for (int j = 0; j <= graph.vertices; j++)
                    sw.Write(((graph.TSPRoutes.ElementAt(i)).ElementAt(j) + 1) + " ");
                sw.WriteLine("| " + graph.TSPRoutesLengths.ElementAt(i));
            }

            sw.Close();
        }

        #endregion Representation

        #region Routes

        private void _getRoutePoint(out int start, out int end)
        {
            try
            {
                start = int.Parse(routeStartTB.Text);
                end = int.Parse(routeEndTB.Text);
            }
            catch
            {
                errorLogTB.Text += "Ошибка получения вершин для поиска пути. Установлены значения по умолчанию." + Environment.NewLine;
                routeStartTB.Text = "1";
                routeEndTB.Text = "2";

                start = 1;
                end = 2;
            }
        }

        private void shimbellButton_Click(object sender, EventArgs e)
        {
            int edges;
            try
            {
                edges = int.Parse(shimbellEdgesTB.Text);
            }
            catch
            {
                errorLogTB.Text += "Ошибка получения числа ребер для алгоритма Шимбелла. Установлено значение по умолчанию." + Environment.NewLine;
                shimbellEdgesTB.Text = "2";
                edges = 2;
            }

            if (edges == 0)
            {
                errorLogTB.Text += "Ошибка. Некорректное число ребер." + Environment.NewLine;
                return;
            }

            if (graph == null)
            {
                errorLogTB.Text += "Ошибка. Граф не найден." + Environment.NewLine;
                return;
            }

            graph.Shimbell(edges).Print();
        }

        private void routeExistanceButton_Click(object sender, EventArgs e)
        {
            int start;
            int end;

            try
            {
                start = int.Parse(routeStartTB.Text);
                end = int.Parse(routeEndTB.Text);
            }
            catch
            {
                errorLogTB.Text += "Ошибка получения вершин для поиска пути. Установлены значения по умолчанию." + Environment.NewLine;
                routeStartTB.Text = "1";
                routeEndTB.Text = "2";

                start = 1;
                end = 2;
            }

            _getRoutePoint(out start, out end);

            if(graph.RouteExists(start - 1, end - 1))
            {
                routeInfoTB.Text += "Путь из вершины " + start + " в вершину " + end + " существует" + Environment.NewLine;
            }
            else
            {
                routeInfoTB.Text += "Путь из вершины " + start + " в вершину " + end + " не существует" + Environment.NewLine;
            }
        }

        private void UpdateRoutesTextBox(object sender, EventArgString e)
        {
            routeInfoTB.Text += e.text;
        }

        #region Dijkstra

        private int[] _launchDijkstra(int start, int end, out int iterations, out double length)
        {
            bool rootFound;
            int[] route = graph.DijkstraRoute(start - 1, end - 1, out iterations, out rootFound, out length);

            if (route == null)
                UpdateRoutesTextBox(null, new EventArgString("Алгоритм неприменим к данному графу. Вес ребер не может быть отрицательным." + Environment.NewLine));
                //routeInfoTB.Text += "Алгоритм неприменим к данному графу. Вес ребер не может быть отрицательным." + Environment.NewLine;

            if (!rootFound)
                return null;

            return route;
        }

        private void _showDijkstraResult(int[] route, int start, int end, int iterations, double length)
        {
            int pos;
            string routeVerts = "";
            string res;

            if (route == null)
            {
                UpdateRoutesTextBox(null, new EventArgString(Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " не найден" + Environment.NewLine));
                //routeInfoTB.Text += Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " не найден" + Environment.NewLine;
                return;
            }

            res = Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " найден." + Environment.NewLine + "Порядок прохождения вершин: ";
            //routeInfoTB.Text += Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + "найден." + Environment.NewLine + "Порядок прохождения вершин: ";

            pos = --end;
            start--;

            while (pos != start)
            {
                routeVerts = (pos + 1).ToString() + " " + routeVerts;
                pos = route[pos];
            }

            routeVerts = (pos + 1).ToString() + " " + routeVerts;

            res += routeVerts + Environment.NewLine + "Число итераций: " + iterations + Environment.NewLine + "Длина пути: " + length + Environment.NewLine + Environment.NewLine;

            UpdateRoutesTextBox(null, new EventArgString(res));

            //routeInfoTB.Text += routeVerts + Environment.NewLine + "Число итераций, потребовавшихся алгоритму: " + iterations + Environment.NewLine + "Длина пути: " + length + Environment.NewLine + Environment.NewLine;
        }

        private void dijkstraButton_Click(object sender, EventArgs e)
        {
            int start;
            int end;
            int iterations = 0;
            double length = 0;
            int[] result = null;
            
            _getRoutePoint(out start, out end);

            ThreadStart threadStart = () => result = _launchDijkstra(start, end, out iterations, out length);
            threadStart += () => { _showDijkstraResult(result, start, end, iterations, length); };

            graphThread = new Thread( threadStart);
            graphThread.Start();
        }





        #endregion Dijkstra

        #region Bellman-Ford

        private void _showBellmanFordResult(int[] route, int start, int end, int iterations, double length)
        {
            int pos;
            string routeVerts = "";
            string res;

            if (route == null)
            {
                UpdateRoutesTextBox(null, new EventArgString(Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " не найден" + Environment.NewLine));
                //routeInfoTB.Text += Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " не найден" + Environment.NewLine;
                return;
            }

            res = Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " найден." + Environment.NewLine + "Порядок прохождения вершин: ";
            //routeInfoTB.Text += Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + "найден." + Environment.NewLine + "Порядок прохождения вершин: ";

            pos = --end;
            start--;

            while (pos != start)
            {
                routeVerts = (pos + 1).ToString() + " " + routeVerts;
                pos = route[pos];
            }

            routeVerts = (pos + 1).ToString() + " " + routeVerts;

            res += routeVerts + Environment.NewLine + "Число итераций: " + iterations + Environment.NewLine + "Длина пути: " + length + Environment.NewLine + Environment.NewLine;

            UpdateRoutesTextBox(null, new EventArgString(res));
        }

        private int[] _launchBellmanFord(int start, int end, out int iterations, out double length)
        {
            bool rootFound;
            int[] route = graph.BellmanFordRoute(start - 1, end - 1, out iterations, out rootFound, out length);

            //if (route == null)
               // UpdateRoutesTextBox(null, new EventArgString("Алгоритм неприменим к данному графу. Вес ребер не может быть отрицательным." + Environment.NewLine));
            //routeInfoTB.Text += "Алгоритм неприменим к данному графу. Вес ребер не может быть отрицательным." + Environment.NewLine;

            if (!rootFound)
                return null;

            return route;
        }

        private void bellmanFordButton_Click(object sender, EventArgs e)
        {
            int[] result = null;
            int iterations = 0;
            double length = 0;
            int start;
            int end;

            _getRoutePoint(out start, out end);

            ThreadStart threadStart = () => result = _launchBellmanFord(start, end, out iterations, out length);
            threadStart += () => { _showBellmanFordResult(result, start, end, iterations, length); };

            graphThread = new Thread(threadStart);

            graphThread.Start();
        }

        #endregion Bellman-Ford

        #region Floyd-Worshall

        private void _showFloydWorshallResult(Matrix<double> route, int start, int end, int iterations, double length)
        {
            int pos;
            string routeVerts = "";
            string res;

            if (route == null)
            {
                UpdateRoutesTextBox(null, new EventArgString(Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " не найден" + Environment.NewLine));
                //routeInfoTB.Text += Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " не найден" + Environment.NewLine;
                return;
            }

            res = Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + " найден." + Environment.NewLine + "Порядок прохождения вершин: ";
            //routeInfoTB.Text += Environment.NewLine + "Путь из вершины " + start + " в вершину " + end + "найден." + Environment.NewLine + "Порядок прохождения вершин: ";

            pos = --start;
            end--;

            routeVerts = (start + 1).ToString();

            while (pos != end)
            {
                routeVerts += " " + (route.At(pos, end) + 1).ToString();
                pos = (int)route.At(pos, end);
            }

            //routeVerts = (pos + 1).ToString() + " " + routeVerts;

            res += routeVerts + Environment.NewLine + "Число итераций: " + iterations + Environment.NewLine + "Длина пути: " + length + Environment.NewLine + Environment.NewLine;

            UpdateRoutesTextBox(null, new EventArgString(res));
        }

        private Matrix<double> _launchFloydWorshall(int start, int end, out int iterations, out double length)
        {
            bool rootFound;
            Matrix<double> route = graph.FloydWorshallRoute(start - 1, end - 1, out iterations, out rootFound, out length);

            if (!rootFound)
                return null;

            return route;
        }

        private void floydWorshallButton_Click(object sender, EventArgs e)
        {
            Matrix<double> result = null;
            int iterations = 0;
            double length = 0;
            int start;
            int end;

            _getRoutePoint(out start, out end);

            ThreadStart threadStart = () => result = _launchFloydWorshall(start, end, out iterations, out length);
            threadStart += () => { _showFloydWorshallResult(result, start, end, iterations, length); };

            graphThread = new Thread(threadStart);

            graphThread.Start();
        }

        #endregion Floyd-Worshall


        #endregion Routes

        #region Astil

        #region Prim

        private void primButton_Click(object sender, EventArgs e)
        {
            int iterations = 0;
            double weigth = 0;

            ThreadStart threadStart = () => graph.Prim(out iterations, out weigth);
            threadStart += () => { UpdateAstilTextBox(null, new EventArgString("Итерации: " + iterations + Environment.NewLine + "Вес остова: " + weigth + Environment.NewLine)); };

            graphThread = new Thread(threadStart);
            graphThread.Start();
        }

        #endregion Prim

        #region Kruskal

        private void kruskalButton_Click(object sender, EventArgs e)
        {
            int iterations = 0;
            double weigth = 0;

            ThreadStart threadStart = () => graph.Kruskal(out iterations, out weigth);
            threadStart += () => { UpdateAstilTextBox(null, new EventArgString("Итерации: " + iterations + Environment.NewLine + "Вес остова: " + weigth + Environment.NewLine)); };

            graphThread = new Thread(threadStart);
            graphThread.Start();
        }

        #endregion Kruskal

        #region Kirchoff

        private void kirchoffButton_Click(object sender, EventArgs e)
        {
            double res = 0;

            ThreadStart threadStart = () => res = graph.Kirchoff();
            threadStart += () => { UpdateAstilTextBox(null, new EventArgString("Число остовных деревьев: " + res + Environment.NewLine)); };

            graphThread = new Thread(threadStart);
            graphThread.Start();
        }

        private void UpdateAstilTextBox(object sender, EventArgString e)
        {
            astilTB.Text += e.text;
        }

        #endregion Kirchoff

        #region Prufer

        private string _printPrufer(int[] prufer)
        {
            string res = "код прюфера";

            for (int i = 0; i < graph.vertices - 1; i++)
                res += " " + (prufer[i] + 1).ToString();

            return res;
        }

        private void pruferButton_Click(object sender, EventArgs e)
        {
            int[] prufer = null;

            ThreadStart threadStart = () => prufer = graph.PruferEncode();
            threadStart += () => { UpdateAstilTextBox(null, new EventArgString(_printPrufer(prufer))); };

            graphThread = new Thread(threadStart);
            graphThread.Start();
        }

        private string _printPruferDecoded(Point[] decoded)
        {
            string res = "Декодированный код прюфера" + Environment.NewLine;

            for (int i = 0; i < graph.prufer.Length; i++)
                res += decoded[i] + "\n";

            return res;
        }

        private void pruferDecodeButton_Click(object sender, EventArgs e)
        {
            Point[] prufer = null;

            ThreadStart threadStart = () => prufer = graph.DecodePrufer();
            threadStart += () => { UpdateAstilTextBox(null, new EventArgString(_printPruferDecoded(prufer))); };

            graphThread = new Thread(threadStart);
            graphThread.Start();
        }

        #endregion Prufer

        #endregion Astil

        #region TSP

        private void UpdateTSPTextBox(object sender, EventArgString e)
        {
            TSPTB.Text += e.text;
        }

        #region Euler

        private void checkEulerButton_Click(object sender, EventArgs e)
        {
            bool res = false;

            ThreadStart threadStart = () =>  res = graph.IsEuler();
            threadStart += () => { UpdateTSPTextBox(null, new EventArgString((res ? "Граф Эйлеров" : "Граф не Эйлеров") + Environment.NewLine)); };

            graphThread = new Thread(threadStart);

            graphThread.Start();
        }

        private void modifyEulerGraph_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = () => graph.ModifyToEuler();
            threadStart += () => { UpdateTSPTextBox(null, new EventArgString(("Граф достроен до Эйлерова") + Environment.NewLine)); };

            graphThread = new Thread(threadStart);

            graphThread.Start();
        }

        #endregion Eueler

        #region Hamilton

        private void checkHamiltonButton_Click(object sender, EventArgs e)
        {
            bool res = false;

            ThreadStart threadStart = () => res = graph.IsHamilton();
            threadStart += () => { UpdateTSPTextBox(null, new EventArgString((res ? "Граф Гамильтонов" : "Граф не Гамильтонов") + Environment.NewLine)); };

            graphThread = new Thread(threadStart);

            graphThread.Start();
        }

        private void modifyHamilton_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = () => graph.ModifyToHamilton();
            threadStart += () => { UpdateTSPTextBox(null, new EventArgString(("Граф достроен до Гамильтонова") + Environment.NewLine)); };

            graphThread = new Thread(threadStart);

            graphThread.Start();
        }

        #endregion Hamilton

        #region Euler route

        private void PrintEulerRoute(List<int> route)
        {
            string res = "Эйлеров путь: ";

            for (; route.Count != 0; route.RemoveAt(0))
            {
                res += (route.ElementAt(0) + 1).ToString() + " ";
            }

            UpdateTSPTextBox(null, new EventArgString(res + Environment.NewLine));
        }

        private void eulerRouteButton_Click(object sender, EventArgs e)
        {
            List<int> route = null;

            ThreadStart threadStart = () => route = graph.EulerRoute();
            threadStart += () => { PrintEulerRoute(route); };

            graphThread = new Thread(threadStart);

            graphThread.Start();
        }

        #endregion Euler route

        #region TSP solving

        private void _solveTSP()
        {
            graph.FindTSPRoutes();
            graph.GetTSPRouteLengths();
        }

        private void solveTSPButton_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = () => _solveTSP();
            threadStart += () => { UpdateTSPTextBox(null, new EventArgString("Решение найдео" + Environment.NewLine)); };

            graphThread = new Thread(threadStart);
            

            graphThread.Start();
        }

        #endregion TSP solving

        #endregion TSP

        #region Net

        private void UpdateNetTextBox(object sender, EventArgString e)
        {
            //netTB.Text += e.text;
        }

        private void buildNetButton_Click(object sender, EventArgs e)
        {
            double maxStream;
            double maxPrice;

            try
            {
                maxStream = double.Parse(maxStreamTB.Text);
                maxPrice = double.Parse(maxPriceTB.Text);
            }
            catch
            {
                netTB.Text += "Ошибка парсинга значений, установлены значения по умолчанию." + Environment.NewLine;
                maxStream = 25;
                maxPrice = 10;
                maxStreamTB.Text = "25";
                maxPriceTB.Text = "10";
            }

            ThreadStart threadStart = () => graph.GenerateNet(maxStream, maxPrice);
            threadStart += () => { UpdateNetTextBox(null, new EventArgString("Сеть построена" + Environment.NewLine)); };

            graphThread = new Thread(threadStart);


            graphThread.Start();

        }

        private void formFulkerstonButton_Click(object sender, EventArgs e)
        {
            int source;
            int sink;
            double stream = 0;

            try
            {
                source = int.Parse(sourceTB.Text) - 1;
                sink = int.Parse(sinkTB.Text) - 1;
            }
            catch
            {
                netTB.Text += "Ошибка парсинга значений, установлены значения по умолчанию." + Environment.NewLine;
                source = 1;
                sink = 2;
                sourceTB.Text = "1";
                sinkTB.Text = "2";
            }

            if( (graph.vertices == 1) || (source < 0) || (source >= graph.vertices) || (sink < 0) || (sink >= graph.vertices) )
            {
                UpdateNetTextBox(null, new EventArgString("Некорректные входные данные"));
                return;
            }

            ThreadStart threadStart = () => graph.FordFalkerston(source, sink, out stream);
            threadStart += () => { UpdateNetTextBox(null, new EventArgString("Матрица максимальных потоков построена" + Environment.NewLine + "Максимальный поток равен " + stream.ToString() + Environment.NewLine)); };

            graphThread = new Thread(threadStart);


            graphThread.Start();
        }

        #region inimal price

        private void _printMinimalPrice(int start, int end, int[] route)
        {

        }

        private void minPriceStreamButton_Click(object sender, EventArgs e)
        {
            int source;
            int sink;
            int[] route = null;
            double price = 0;

            try
            {
                source = int.Parse(sourceTB.Text) - 1;
                sink = int.Parse(sinkTB.Text) - 1;
            }
            catch
            {
                netTB.Text += "Ошибка парсинга значений, установлены значения по умолчанию." + Environment.NewLine;
                source = 1;
                sink = 2;
                sourceTB.Text = "1";
                sinkTB.Text = "2";
            }

            if ((graph.vertices == 1) || (source < 0) || (source >= graph.vertices) || (sink < 0) || (sink >= graph.vertices))
            {
                UpdateNetTextBox(null, new EventArgString("Некорректные входные данные"));
                return;
            }

            ThreadStart threadStart = () => graph.MinimalPriceStream(source, sink, out price, 0);
            threadStart += () => { UpdateNetTextBox(null, new EventArgString("Поток минимальной стоимости имеет цену: " + price)); };

            graphThread = new Thread(threadStart);


            graphThread.Start();
        }

        #endregion Minimal price

        #endregion Net

        private void Lab_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((graphThread != null) && (graphThread.IsAlive))
                graphThread.Abort();
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            if (graphThread != null)
                graphThread.Abort();
        }

        private void minPriceStreamPrintButton_Click(object sender, EventArgs e)
        {
            graph.PrintMinStream();
        }

        private Point _convertAbsToPict(double x, double y, PictureBox pict, Point absoluteScale)
        {
            return new Point((int)(x * pict.Width / absoluteScale.X), pict.Height - (int)(y * pict.Height / absoluteScale.Y));
        }

        double F1(double x)
        {
            double s = 1;
            double mu = 3;

            return 1 / (s * Math.Sqrt(Math.PI * 2)) * Math.Exp(-(x - mu) * (x - mu) / ( 2 * s * s ) ); 
        }

        private void distributionButton_Click(object sender, EventArgs e)
        {
            //Form f = new Form();
            //pb.Parent = f;
            double yOld = F(0);
            double y;
            Graphics g = Graphics.FromHwnd(pb.Handle);
            Pen pen = new Pen(Color.Black);
            double step = 0.02;
            Point scale = new Point(15, 1);
            Point lastPosition = _convertAbsToPict(0, F1(0), pb, scale);

            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pb.Width, pb.Height));

            for (double x = step; x < 6; x += step)
            {
                g.DrawLine(pen, lastPosition, lastPosition = _convertAbsToPict(x, F1(x), pb, scale));
            }

            //pb.Show();
            //f.ShowDialog();
        }
    }
}
