using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Policy;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Lab1._3
{
    class NewGraph
    {
        Matrix<double> verticesAdjancencyMatrix; //Матрица смежности вершин
        Matrix<double> symmetricVerticesAdjancencyMatrix; // Симметричная матрица смежности вершин
        Matrix<double> unweigthedIncidencyMatrix;
        Matrix<double> astilMatrix; //Матрица описывающая остов
        Matrix<double> kirchoffMatrix;
        Matrix<double> eulerVersion;
        Matrix<double> hamiltonVersion;
        Matrix<double> streamMatrix;
        Matrix<double> priceMatrix;
        Matrix<double> maxStreamMatrix;
        Matrix<double> maxStreamSourceMatrix;
        Matrix<double> minStreamMatrix;
        Matrix<double> extraMatrix;

        int[] pruferCode;
        Point[] pruferDecoded;

        protected int verticesAmount; //Число вершин
        protected int edgesAmount; //Число ребер (дуг)

        public event EventHandler<EventArgString> updateRoutesTB;
        public event EventHandler<EventArgString> updateAstilTB;
        public event EventHandler<EventArgString> updateTSPTB;
        public event EventHandler<EventArgString> updateNetTB;

        /*
         * Содержит средства для обеспечения алгоритмов на различных матрицах
         */
        #region Multimatrix

        public enum matrixes_en
        {
            unoriented,
            oriented,
            astil,
            kirchoff,
            euler,
            hamilton,
            stream,
            price,
            maxStream,
            extra,
            unweigthed,
            maxStreamSource,
            minStream
        }


        private Matrix<double> _getMatrixFromEn(matrixes_en en)
        {
            switch (en)
            {
                case matrixes_en.oriented:
                    return verticesAdjancencyMatrix;
                case matrixes_en.unoriented:
                    return symmetricVerticesAdjancencyMatrix;
                case matrixes_en.astil:
                    return astilMatrix;
                case matrixes_en.kirchoff:
                    return kirchoffMatrix;
                case matrixes_en.euler:
                    return eulerVersion;
                case matrixes_en.hamilton:
                    return hamiltonVersion;
                case matrixes_en.stream:
                    return streamMatrix;
                case matrixes_en.price:
                    return priceMatrix;
                case matrixes_en.maxStream:
                    return maxStreamMatrix;
                case matrixes_en.extra:
                    return extraMatrix;
                case matrixes_en.unweigthed:
                    return unweigthedIncidencyMatrix;
                case matrixes_en.maxStreamSource:
                    return maxStreamSourceMatrix;
                case matrixes_en.minStream:
                    return minStreamMatrix;
                default:
                    return verticesAdjancencyMatrix;
            }
        }

        #endregion

        /*
         * Содержит конструктор класса
         */
        #region Constructors

        /*
        * Выделяет память под граф с заданным числом вершин и ребер (дуг)
        * Input:
        *   verts - число вершин
        *   edges - число ребег (дуг)
        */
        public NewGraph(int verts, int edges)
        {
            verticesAmount = verts;
            edgesAmount = edges;

            verticesAdjancencyMatrix = new Matrix<double>(verts, verts, true);
            symmetricVerticesAdjancencyMatrix = null;
            astilMatrix = null;

            for (int i = 0; i < verts; i++)
                for (int j = i; j < verts; j++)
                    verticesAdjancencyMatrix.Set(i, i, 0);
        }

        #endregion Constructors

        /*
         * Содержит методы для вывода графа
         */
        #region Output functions

        /*
         * Создает окно, в котором заполняет ячейки таблицы значениями выбранной матрицы
         * Input:
         *  maxtrixes_en en - элемент перечисления, используеймый для определения выбранной матрицы
         */
        public void FormTablePrint(matrixes_en en = matrixes_en.oriented)
        {
            Form resultForm = new Form();
            TableLayoutPanel panel = new TableLayoutPanel();
            Matrix<double> matrix = _getMatrixFromEn(en);

            panel.Parent = resultForm;
            resultForm.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            panel.Size = resultForm.Size;
            panel.RowCount = matrix.heigth + 1;
            panel.ColumnCount = matrix.length + 1;

            resultForm.Show();

            for (int i = 0; i < panel.RowCount; i++)
                panel.RowStyles.Add(new RowStyle { SizeType = SizeType.Percent, Height = 100 / (matrix.heigth + 1) });

            for (int i = 0; i < panel.ColumnCount; i++)
                panel.ColumnStyles.Add(new ColumnStyle { SizeType = SizeType.Percent, Width = 100 / (matrix.length + 1) });

            matrix.Print(panel);
        }

        public void PrintSymmetric()
        {
            if (symmetricVerticesAdjancencyMatrix == null)
                GenerateSymmetric();

            FormTablePrint(matrixes_en.unoriented);
        }

        public void PrintAstil()
        {
            if (astilMatrix == null)
                astilMatrix = new Matrix<double>(verticesAmount, verticesAmount);

            FormTablePrint(matrixes_en.astil);
        }

        public void PrintKirchoff()
        {
            if (kirchoffMatrix == null)
                Kirchoff();

            FormTablePrint(matrixes_en.kirchoff);
        }

        public void PrintEuler()
        {
            if(eulerVersion == null)
            {
                if (symmetricVerticesAdjancencyMatrix == null)
                    GenerateSymmetric();

                eulerVersion = symmetricVerticesAdjancencyMatrix.Copy();
            }

            FormTablePrint(matrixes_en.euler);
        }

        public void PrintHamilton()
        {
            if (hamiltonVersion == null)
            {
                if (symmetricVerticesAdjancencyMatrix == null)
                    GenerateSymmetric();

                hamiltonVersion = symmetricVerticesAdjancencyMatrix.Copy();
            }

            FormTablePrint(matrixes_en.hamilton);
        }

        public void PrintStream()
        {
            if (streamMatrix == null)
                GenerateNet(25, 10);

            FormTablePrint(matrixes_en.stream);
        }

        public void PrintPrice()
        {
            if (priceMatrix == null)
                GenerateNet(25, 10);

            FormTablePrint(matrixes_en.price);
        }

        public void PrintMaxStream()
        {
            if (maxStreamMatrix == null)
                FordFalkerston(0, 1, out double s);

            FormTablePrint(matrixes_en.maxStream);
        }

        #endregion Output functions

        /*
         * Свойства
         */
        #region Properties

        public Matrix<double> matrix
        {
            get
            {
                return verticesAdjancencyMatrix;
            }
        }

        public int matrixWidth
        {
            get
            {
                return verticesAdjancencyMatrix.length;
            }
        }

        public int matrixHeigth
        {
            get
            {
                return verticesAdjancencyMatrix.heigth;
            }
        }

        public int vertices
        {
            get
            {
                return verticesAmount;
            }
        }

        public int edges
        {
            get
            {
                return edgesAmount;
            }
        }

        public int[] prufer
        {
            get
            {
                return prufer;
            }
        }

        public List<List<int>> TSPRoutes
        {
            get
            {
                return tspRoutes;
            }
        }

        public List<double> TSPRoutesLengths
        {
            get
            {
                return tspRoutesLengths;
            }
        }

        public int ShortesTSPRouteNumber
        {
            get
            {
                return minNumber;
            }
        }

        public double ShortesTSPRouteLength
        {
            get
            {
                return minLength;
            }
        }

        #endregion Properties

        /*
         * Содержит поля и методы, используемые для генераци случайного графа
         */
        #region Random generation

        //double scale = 100;
        private Random r = new Random();
        public delegate double fDelegate(double x);

        public void GenerateSymmetric()
        {
            symmetricVerticesAdjancencyMatrix = new Matrix<double>(verticesAmount, verticesAmount);

            for (int i = 0; i < verticesAmount; i++)
                for (int j = i; j < verticesAmount; j++)
                {
                    symmetricVerticesAdjancencyMatrix.Set(i, j, verticesAdjancencyMatrix.At(i, j));
                    symmetricVerticesAdjancencyMatrix.Set(j, i, verticesAdjancencyMatrix.At(i, j));
                }
        }

        /*
         * Возвращает случайное число, согласно распределнию F
         */
        private double _rand(fDelegate F)
        {
            return F(1 - r.NextDouble());
        }

        /*
         * Создает случайный граф, заданный матрицей смежности вершин
         * Input:
         *  fDelegate F - распределение
         *  Label lbl - тектовое поле для сообщения об ошибке
         *  double minValue - наименьший вес ребра
         *  double maxValue - максимальный вес ребра
         */
        public void Generate(fDelegate F, double minValue, double maxValue)
        {
            int sqrN = matrixWidth * matrixWidth;
            int blankOperations = 0;

            for (int k = 0; k < edgesAmount; k++)
            {
                int N = (int)Math.Floor(sqrN * _rand(F));
                int i = N / matrixWidth;
                int j = N - i * matrixWidth;
                double length = maxValue - Math.Round(_rand(F) * (maxValue - minValue) * 100) / 100;// _getLength(minValue, maxValue, F);
                if (length == 0)
                    length = 0.001;

                //lbl.Text = blankOperations.ToString();

                if (blankOperations >= 5 * vertices)
                {
                    return;
                }

                if ((i < j) && (verticesAdjancencyMatrix.At(i, j) == 0))
                {
                    Connect(i, j, length);
                    //lbl.Text += "New: " + i + " " + j + " " + length + "\n";
                    blankOperations = 0;
                }
                else
                {
                    if ((i > j) && (verticesAdjancencyMatrix.At(j, i) == 0))
                    {
                        Connect(j, i, length);
                        //lbl.Text += "New: " + i + " " + j + " " + length + "\n";
                        blankOperations = 0;
                    }
                    else
                    {
                        k--;
                        blankOperations++;
                    }
                }
            }
        }
        //*/

        public void CheckConnections()
        {
            List<int> disconnectedVerts = new List<int>();

            for (int i = 1; i < verticesAmount; i++)
                if (!RouteExists(0, i, matrixes_en.oriented))
                {
                    disconnectedVerts.Add(i);
                }

            while (disconnectedVerts.Count != 0)
            {
                int nextLostVert = disconnectedVerts.ElementAt(0);
                disconnectedVerts.RemoveAt(0);

                for (int i = 0; i < verticesAmount; i++)
                    for (int j = 0; j < verticesAmount; j++)
                        if (routeLength(i, j, matrixes_en.oriented) != 0)
                        {
                            double temp = routeLength(i, j, matrixes_en.oriented);
                            Disconnect(i, j, matrixes_en.oriented);
                            if (RouteExists(i, j, matrixes_en.oriented))
                            {
                                Connect(0, nextLostVert, temp, matrixes_en.oriented);
                                i = verticesAmount;
                                j = verticesAmount;
                            }
                            else
                                Connect(i, j, temp, matrixes_en.oriented);
                        }
            }
        }

        #endregion Random generation

        public double RouteLength(int i, int j)
        {
            return matrix.At(i, j);
        }

        #region Routes

        #region Shimbell

        private Matrix<double> _shimbellMultiplication(Matrix<double> first, matrixes_en en = matrixes_en.oriented)
        {
            Matrix<double> second;

            second = _getMatrixFromEn(en);

            Matrix<double> res = new Matrix<double>(first.length, second.heigth);

            for (int i = 0; i < first.length; i++)
                for (int j = 0; j < first.length; j++)
                {
                    double value = 0;

                    for (int k = 0; k < first.length; k++)
                    {
                        double temp = first.At(i, k) * second.At(k, j) == 0 ? 0 : first.At(i, k) + second.At(k, j);
                        if (temp != 0)
                            if (value == 0)
                                value = temp;
                            else
                                value = temp > value ? value : temp;
                    }

                    res.Set(i, j, value);
                }

            return res;
        }

        public Matrix<double> Shimbell(int edges, matrixes_en en = matrixes_en.oriented)
        {
            Matrix<double> res = matrix.Copy();

            for (int i = 1; i < edges; i++)
                res = _shimbellMultiplication(res, en);

            return res;
        }

        #endregion Shimbell

        public bool RouteExists(int start, int end, matrixes_en en = matrixes_en.oriented)
        {
            Matrix<double> temp = _getMatrixFromEn(en);

            for (int i = 1; (i < verticesAmount) && (temp.At(start, end) == 0); i++)
                temp = _shimbellMultiplication(temp, en);

            return temp.At(start, end) != 0;
        }

        #region Dijkstra

        private int _findNextStart(double[] subroutes, bool[] metVerts, List<int> inUse)
        {
            double min = 0;
            int minI = -1;
            bool minSet = false;

            for (int i = 0; i < verticesAmount; i++)
            {
                if ((inUse.Contains(i)) && (metVerts[i]))
                    if (minSet)
                    {
                        if (min > subroutes[i])
                        {
                            min = subroutes[i];
                            minI = i;
                        }
                    }
                    else
                    {
                        minSet = true;
                        minI = i;
                        min = subroutes[i];
                    }
            }

            return minI;
        }

        public int[] DijkstraRoute(int start, int end, out int iterationsCount, out bool found, out double length, matrixes_en en = matrixes_en.oriented)
        {
            double[] subroutes = new double[verticesAmount];
            bool[] metVerts = new bool[verticesAmount];
            int[] route = new int[verticesAmount];
            List<int> inUse = new List<int>();
            int curIndex;
            int routeCount = 0;
            //int iterationsCount = 0;

            iterationsCount = 0;

            for (int i = 0; i < verticesAmount; i++)
            {
                metVerts[i] = false;
                subroutes[i] = 0;
                inUse.Add(i);
            }

            metVerts[start] = true;
            curIndex = start;

            for (int i = 0; i < verticesAmount; i++)
            {
                if ((i != start) && (routeLength(start, i, en) != 0))
                {
                    subroutes[i] = routeLength(start, i, en);
                    metVerts[i] = true;
                }
            }

            inUse.Remove(start);
            route[routeCount++] = start;

            while (inUse.Count != 0)
            {
                int newStart = _findNextStart(subroutes, metVerts, inUse);

                if (newStart == -1)
                    break;

                //for(int i = 0; i < graph.vertices; i++)
                foreach (int i in inUse)
                {
                    if (routeLength(newStart, i, en) < 0)
                    {
                        found = false;
                        length = 0;
                        return null;
                    }

                    if ((i != newStart) && (inUse.Contains(i)) && (routeLength(newStart, i, en) != 0))
                    {
                        if (metVerts[i])
                        {
                            if (subroutes[i] > (routeLength(newStart, i, en) + subroutes[newStart]))
                            {
                                subroutes[i] = routeLength(newStart, i, en) + subroutes[newStart];
                                route[i] = newStart;
                            }
                        }
                        else
                        {
                            metVerts[i] = true;
                            subroutes[i] = routeLength(newStart, i, en) + subroutes[newStart];
                            route[i] = newStart;
                        }
                    }

                    iterationsCount++;
                }

                inUse.Remove(newStart);


            }

            found = subroutes[end] != 0;
            length = subroutes[end];

            return route;
        }

        #endregion Dijkstra

        #region Bellman-Ford

        public int[] BellmanFordRoute(int start, int end, out int iterationsCount, out bool routeFound, out double length, matrixes_en en = matrixes_en.oriented)
        {
            double[] T = new double[verticesAmount];
            bool[] tReached = new bool[verticesAmount];
            int[] route = new int[verticesAmount];
            bool somethingDone = true;
            
            iterationsCount = 0;

            for (int i = 1; i < verticesAmount; i++)
                tReached[i] = false;

            T[start] = 0;
            tReached[start] = true;

            for (int i = 0; i < verticesAmount; i++)
            {
                if (routeLength(start, i, en) != 0)
                {
                    T[i] = routeLength(start, i, en);
                    tReached[i] = true;
                    route[i] = start;
                }
            }

            for (int k = 2; (k < verticesAmount) && somethingDone; k++)
            {
                somethingDone = false;
                for (int i = 0; i < verticesAmount; i++)
                    for (int j = 0; j < verticesAmount; j++)
                    {
                        if (routeLength(j, i, en) != 0)
                        {
                            if (tReached[j])
                            {
                                double temp;
                                if ((T[i] > (temp = T[j] + routeLength(j, i, en))) || !tReached[i])
                                {
                                    T[i] = temp;
                                    tReached[i] = true;
                                    somethingDone = true;
                                    route[i] = j;
                                }
                            }
                            /*
                            else
                            {
                                T[i] = T[j] + graph.routeLength(j, i);
                                tReached[i] = true;
                            }
                            //*/
                        }
                        iterationsCount++;
                    }
            }

            length = T[end];
            routeFound = tReached[end];

            return route;
        }

        #endregion Bellman-Ford

        #region Floyd-Worshall

        public Matrix<double> FloydWorshallRoute(int start, int end, out int iterations, out bool routeFound, out double length, matrixes_en en = matrixes_en.oriented)
        {
            Matrix<double> E = new Matrix<double>(verticesAmount, verticesAmount);
            Matrix<double> T = new Matrix<double>(verticesAmount, verticesAmount);

            iterations = 0;

            for (int i = 0; i < verticesAmount; i++)
                for (int j = 0; j < verticesAmount; j++)
                {
                    T.Set(i, j, routeLength(i, j, en));
                    if (routeLength(i, j, en) == 0)
                        E.Set(i, j, 0);
                    else
                        E.Set(i, j, j);
                }

            for (int i = 0; i < verticesAmount; i++)
                for (int j = 0; j < verticesAmount; j++)
                    for (int k = 0; k < verticesAmount; k++)
                    {
                        iterations++;
                        if ((i != j) && (T.At(j, i) != 0)
                            && (i != k) && (T.At(i, k) != 0)
                            && ((T.At(j, k) == 0)
                                || (T.At(j, k) > T.At(j, i) + T.At(i, k))))
                        {
                            E.Set(j, k, E.At(j, i));
                            T.Set(j, k, T.At(j, i) + T.At(i, k));
                        }
                    }


            length = T.At(start, end);
            routeFound = T.At(start, end) != 0;

            return E;
        }

        #endregion Floyd-Worshall

        #endregion Routes

        #region Astil

        private struct ExtendedEdge
        {
            public double length;
            public int beginVert;
            public int endVert;
        };

        #region Prim

        public void Prim(out int iterations, out double astilWeigth)
        {
            try
            {
                if (astilMatrix == null)
                    astilMatrix = new Matrix<double>(verticesAmount, verticesAmount);

                if (symmetricVerticesAdjancencyMatrix == null)
                    GenerateSymmetric();

                iterations = 0;
                astilWeigth = 0;

                //List<ExtendedEdge> availableEdges = new List<ExtendedEdge>;
                ExtendedEdge[] availableEdges = new ExtendedEdge[edgesAmount];
                int halfEdges = edgesAmount;
                List<int> availableVerts = new List<int>();
                List<int> usedVerts = new List<int>();

                for (int i = 1; i < verticesAmount; i++)
                    availableVerts.Add(i);
                usedVerts.Add(0);

                bool edgeChosen;


                while (availableVerts.Count != 0)
                {
                    edgeChosen = false;
                    ExtendedEdge choosenEdge = new ExtendedEdge();

                    foreach (var start in usedVerts)
                    {
                        foreach (var end in availableVerts.Where(x => routeLength(start, x, matrixes_en.unoriented) != 0))
                        {
                            double temp;
                            iterations++;

                            if ((temp = routeLength(start, end, matrixes_en.unoriented)) == 0)
                            {
                                continue;
                            }

                            if (edgeChosen)
                            {


                                if (temp < choosenEdge.length)
                                {
                                    choosenEdge.length = temp;
                                    choosenEdge.beginVert = start;
                                    choosenEdge.endVert = end;
                                }
                            }
                            else
                            {
                                edgeChosen = true;
                                choosenEdge.length = routeLength(start, end, matrixes_en.unoriented);
                                choosenEdge.beginVert = start;
                                choosenEdge.endVert = end;
                            }
                        }
                    }
                    if (choosenEdge.length != 0)
                    {

                        Connect(choosenEdge.beginVert, choosenEdge.endVert, choosenEdge.length, matrixes_en.astil);
                        Connect(choosenEdge.endVert, choosenEdge.beginVert, choosenEdge.length, matrixes_en.astil);

                        astilWeigth += choosenEdge.length;

                        usedVerts.Add(choosenEdge.endVert);
                        availableVerts.RemoveAt(availableVerts.IndexOf(choosenEdge.endVert));
                    }

                }
            }
            catch
            {
                iterations = 0;
                astilWeigth = 0;
            }
        }

        #endregion Prim

        #region Kruskal

        private void _qsort(ExtendedEdge[] edges, int start, int end)
        {
            if (start >= end)
                return;

            int anchor = _divide(edges, start, end);
            _qsort(edges, start, anchor - 1);
            _qsort(edges, anchor + 1, end);
        }

        private int _divide(ExtendedEdge[] edges, int start, int end)
        {
            ExtendedEdge temp;
            int marker = start;

            for (int i = start; i < end; i++)
            {
                if (edges[i].length < edges[end].length)
                {
                    temp = edges[marker];
                    edges[marker] = edges[i];
                    edges[i] = temp;
                    marker += 1;
                }
            }
            temp = edges[marker];
            edges[marker] = edges[end];
            edges[end] = temp;
            return marker;
        }

        public void Kruskal(out int iterations, out double weigth)
        {
            weigth = 0;

            if (symmetricVerticesAdjancencyMatrix == null)
                GenerateSymmetric();

            if (astilMatrix == null)
                astilMatrix = new Matrix<double>(verticesAmount, verticesAmount);

            iterations = 0;

            //List<ExtendedEdge> availableEdges = new List<ExtendedEdge>;
            ExtendedEdge[] availableEdges = new ExtendedEdge[edgesAmount];
            int halfEdges = edgesAmount;

            for (int k = 0, i = 0; k < halfEdges; i++)
            {
                for (int j = i; (k < halfEdges) && (j < verticesAmount); j++)
                {
                    double temp;
                    if ((temp = routeLength(i, j, matrixes_en.unoriented)) != 0)
                    {
                        availableEdges[k].length = temp;
                        availableEdges[k].beginVert = i;
                        availableEdges[k].endVert = j;
                        k++;
                    }
                }
            }

            _qsort(availableEdges, 0, edgesAmount - 1);

            for (int marker = 0; marker < halfEdges; marker++)
            {
                iterations++;

                if (!RouteExists(availableEdges[marker].beginVert, availableEdges[marker].endVert, matrixes_en.unoriented))
                {
                    Connect(availableEdges[marker].beginVert, availableEdges[marker].endVert, availableEdges[marker].length, matrixes_en.unoriented);
                    Connect(availableEdges[marker].endVert, availableEdges[marker].beginVert, availableEdges[marker].length, matrixes_en.unoriented);
                }
            }

            for (int i = 0; i < verticesAmount; i++)
                for (int j = i; j < verticesAmount; j++)
                    weigth += astilMatrix.At(i, j);
        }

        #endregion Kruskal

        #region Kirchhoff

        public double _determinant(List<int> oldI, List<int> oldJ)
        {
            if (kirchoffMatrix.length - oldJ.Count == 2)
            {
                int[,] pos = new int[2, 2];
                int[] k = new int[2];
                int[,] eligable = new int[2, 2];

                /* k[0] = 0;
                 k[1] = 0;

                 for (int i = 0; i < kirchoffMatrix.length; i++)
                 {
                     if (oldI.IndexOf(i) == -1)
                     {
                         eligable[0, k[0]] = i;
                         k[0]++;
                     }

                     if (oldJ.IndexOf(i) == -1)
                     {
                         eligable[1, k[1]] = i;
                         k[1]++;
                     }
                 }

                 k[0] = 0;
                 k[1] = 0;

                 for (int i = 0; i < 2; i++)
                 {
                     pos[0, i] = (int)kirchoffMatrix.At(eligable[0, 0], eligable[0, i]);
                     pos[1, i] = (int)kirchoffMatrix.At(eligable[0, 1], eligable[0, i]);
                 }

                 return pos[0, 0] * pos[1, 1] - pos[0, 1] * pos[0, 1];
                 //*/
                //*
                for (int i = 0; i < kirchoffMatrix.length; i++)
                {
                    if (oldI.IndexOf(i) == -1)
                    {
                        pos[0, k[0]] = i;
                        k[0]++;
                    }

                    if (oldJ.IndexOf(i) == -1)
                    {
                        pos[1, k[1]] = i;
                        k[1]++;
                    }
                }

                return kirchoffMatrix.At(pos[0, 0], pos[1, 0]) * kirchoffMatrix.At(pos[0, 1], pos[1, 1]) 
                    - kirchoffMatrix.At(pos[0, 1], pos[1, 0]) * kirchoffMatrix.At(pos[0, 0], pos[1, 1]);
                //*/


            }

            double res = 0;
            int j;
            int i_extra = 0;

            for (j = 0; oldJ.IndexOf(j) != -1; j++)
                ;

            oldJ.Add(j);



            for (int i = 0; i < kirchoffMatrix.length; i++)
            {
                if (oldI.IndexOf(i) == -1)
                {
                    oldI.Add(i);
                    res += _determinant(oldI, oldJ) * ((i_extra) % 2 == 0 ? 1 : -1) * kirchoffMatrix.At(i, j);
                    oldI.RemoveAt(oldI.IndexOf(i));
                    i_extra++;
                }
            }

            oldJ.RemoveAt(oldJ.IndexOf(j));

            return res;
        }

        private double _addition(int i, int j, List<int> oldI, List<int> oldJ)
        {
            oldI.Add(i);
            oldJ.Add(j);

            double temp = _determinant(oldI, oldJ);

            oldI.RemoveAt(oldI.IndexOf(i));
            oldJ.RemoveAt(oldJ.IndexOf(j));

            return ((i + j) % 2 == 0 ? 1 : -1) * temp;
        }

        public Matrix<double> GetIncidenceMatrix()
        {
            if (symmetricVerticesAdjancencyMatrix == null)
                GenerateSymmetric();

            Matrix<double> res = new Matrix<double>(verticesAmount, edgesAmount);
            int k = 0;
            double temp;

            for (int i = 0; (i < vertices) && (k < edges); i++)
                for (int j = i; (j < vertices) && (k < edges); j++)
                {
                    //if( (temp = matrix.At(i, j)) != 0)
                    if (symmetricVerticesAdjancencyMatrix.At(i, j) != 0)
                    {
                        res.Set(i, k, 1);
                        res.Set(j, k, 1);
                        k++;
                    }
                }

            return res;
        }

        public double Kirchoff()
        {
            if (symmetricVerticesAdjancencyMatrix == null)
                GenerateSymmetric();

            if (unweigthedIncidencyMatrix == null)
                unweigthedIncidencyMatrix = GetIncidenceMatrix();

            kirchoffMatrix = Matrix<double>.Multiply(unweigthedIncidencyMatrix, unweigthedIncidencyMatrix.Transponse());
            return _addition(0, 0, new List<int>(), new List<int>());
        }

        #endregion Kirchhoff

        #region Prufer

        private int[] _getRanking(ref int maxRank)
        {
            int[] res = new int[verticesAmount];
            List<int> indexQueue = new List<int>();

            res[0] = 0;
            maxRank = 0;

            for (int i = 1; i < verticesAmount; i++)
                res[i] = -1;

            for (int i = 1; i < verticesAmount; i++)
            {
                if ((res[i] == -1) && (routeLength(0, i, matrixes_en.astil) != 0))
                {
                    res[i] = res[0] + 1;
                    indexQueue.Add(i);
                }
                if (maxRank < res[i])
                    maxRank = res[i];
            }

            while (indexQueue.Count != 0)
            {
                for (int i = 0; i < verticesAmount; i++)
                {
                    if ((res[i] == -1) && (routeLength(indexQueue.ElementAt(0), i, matrixes_en.astil) != 0))
                    {
                        res[i] = res[indexQueue.ElementAt(0)] + 1;
                        indexQueue.Add(i);
                    }
                    if (maxRank < res[i])
                        maxRank = res[i];
                }

                indexQueue.RemoveAt(0);
            }
            return res;
        }

        private bool _isLeaf(int vert, bool[] usedVerts, int[] ranking, ref int parent)
        {
            bool res = true;

            for (int i = 0; i < verticesAmount; i++)
            {
                if ((!usedVerts[i]) && (i != vert) && (routeLength(vert, i, matrixes_en.astil) != 0))
                {
                    if (ranking[i] > ranking[vert])
                        res = false;
                    else
                        parent = i;
                }

            }

            return res;
        }

        public int[] PruferEncode()
        {
            if (verticesAmount == 2)
            {
                pruferCode = new int[1];

                pruferCode[0] = 1;

                return pruferCode;
            }

            if (verticesAmount == 1)
            {
                pruferCode = null;

                return pruferCode;
            }

            if (astilMatrix == null)
            {
                int tempI;
                double tempD;

                Prim(out tempI, out tempD);
            }

            int maxRank = 0;
            int[] ranking = _getRanking(ref maxRank);
            bool[] usedVerts = new bool[verticesAmount];
            pruferCode = new int[verticesAmount - 1];
            int parent = 0;

            

            for (int i = 0; i < verticesAmount; i++)
            {
                usedVerts[i] = false;
            }

            for (int k = 1; k < verticesAmount; k++)
            {
                int chosenVert = -1;

                for (int i = 0; (i < verticesAmount) && (chosenVert == -1); i++)
                {
                    if ((!usedVerts[i]) && (_isLeaf(i, usedVerts, ranking, ref parent)))
                    {
                        usedVerts[i] = true;
                        chosenVert = i;
                    }
                }
                pruferCode[k - 1] = parent;
            }

            return pruferCode;
        }

        public Point[] DecodePrufer()
        {
            pruferDecoded = new Point[pruferCode.Length];
            List<int> pList = new List<int>();
            bool[] freeVerts = new bool[verticesAmount];
            //int[] reservePrufer = (int[])prufer.Clone();
            int[] availableVerts = new int[verticesAmount];
            int k;

            for (int i = 0; i < pruferCode.Length; i++)
            {
                pList.Add(pruferCode[i]);
                freeVerts[i] = true;
            }

            freeVerts[verticesAmount - 2] = true;
            freeVerts[verticesAmount - 1] = true;

            k = 0;

            while (pList.Count != 0)
            {
                int temp = pList.ElementAt(0);
                int minimal = -1;

                for (int i = 0; i < verticesAmount; i++)
                    if ((pList.IndexOf(i) == -1) && (freeVerts[i]))
                    {
                        minimal = i;
                        freeVerts[i] = false;

                        break;
                    }

                pList.RemoveAt(0);

                pruferDecoded[k] = new Point(temp, minimal);

                k++;
            }

            return pruferDecoded;
        }

        #endregion Prufer

        #endregion Astil

        #region TSP

        #region Euler

        public bool IsEuler()
        {
            if (eulerVersion == null)
            {
                if (symmetricVerticesAdjancencyMatrix == null)
                    GenerateSymmetric();
                eulerVersion = symmetricVerticesAdjancencyMatrix.Copy();
            }

            bool isEuler = true;

            for (int i = 0; i < verticesAmount; i++)
            {
                int deg = 0;

                for (int j = 0; j < verticesAmount; j++)
                {
                    if (eulerVersion.At(i, j) != 0)
                        deg++;
                }

                if (deg % 2 == 1)
                {
                    isEuler = false;
                    break;
                }
            }

            if (!isEuler)
                return isEuler;

            for (int i = 1; (i < verticesAmount) && isEuler; i++)
            {
                if (!RouteExists(0, i, matrixes_en.euler))
                    for (int j = 0; j < verticesAmount; j++)
                        if ((i != j) && (routeLength(i, j, matrixes_en.euler) != 0))
                        {
                            isEuler = false;
                            break;
                        }
            }

            return isEuler;
        }

        public void ModifyToEuler()
        {
            if (IsEuler())
                return;

            List<int> badVerts = new List<int>();
            List<int> overloadedVerts = new List<int>();

            for (int i = 0; i < verticesAmount; i++)
            {
                int deg = 0;

                for (int j = 0; j < verticesAmount; j++)
                    if (routeLength(i, j, matrixes_en.euler) != 0)
                        deg++;

                if ((deg % 2) == 1)
                {
                    if (deg == (verticesAmount - 1))
                        overloadedVerts.Add(i);
                    else
                        badVerts.Add(i);
                }
            }

            List<int> badBadVerts = new List<int>();

            //*
            while (badVerts.Count != 0)
            {
                int i = badVerts.ElementAt(0);
                int j = -1;

                badVerts.RemoveAt(0);

                for (int t = 0; t < badVerts.Count; t++)
                    if (routeLength(i, badVerts.ElementAt(t), matrixes_en.euler) == 0)
                    {
                        j = badVerts.ElementAt(t);
                        badVerts.RemoveAt(t);
                        break;
                    }

                if (j == -1)
                {
                    badBadVerts.Add(i);
                }
                else
                {
                    Connect(i, j, 1, matrixes_en.euler);
                    Connect(j, i, 1, matrixes_en.euler);
                }



            }
            //*/
            while (badBadVerts.Count != 0)
            {
                int i = badBadVerts.ElementAt(0);
                int j = -1;

                badBadVerts.RemoveAt(0);

                for (int t = 0; t < badBadVerts.Count; t++)
                    if (routeLength(i, badBadVerts.ElementAt(t), matrixes_en.euler) != 0)
                    {
                        j = badBadVerts.ElementAt(t);
                        badBadVerts.RemoveAt(t);
                        break;
                    }

                double temp = routeLength(i, j, matrixes_en.euler);
                Disconnect(i, j, matrixes_en.euler);
                Disconnect(j, i, matrixes_en.euler);

                if (!RouteExists(i, j, matrixes_en.euler))
                {
                    //eulerGraph.Connect(i, j, temp);
                    //eulerGraph.Connect(j, i, temp);

                    bool connected = false;

                    for (int t = 0; (t < verticesAmount) && (!connected); t++)
                    {
                        if ((routeLength(i, t, matrixes_en.euler) == 0) &&
                            (routeLength(j, t, matrixes_en.euler) == 0))
                        {
                            Connect(i, t, temp / 2, matrixes_en.euler);
                            Connect(t, i, temp / 2, matrixes_en.euler);
                            Connect(j, t, temp / 2, matrixes_en.euler);
                            Connect(t, j, temp / 2, matrixes_en.euler);
                            connected = true;
                        }
                    }

                    if (!connected)
                    {
                        bool found = false;

                        for (int i1 = 0; (i1 < verticesAmount) && (!found); i1++)
                            if (routeLength(i, i1, matrixes_en.euler) == 0)
                                for (int i2 = 0; (i2 < verticesAmount) && (!found); i2++)
                                    if ((routeLength(j, i2, matrixes_en.euler) == 0) & (routeLength(i1, i2, matrixes_en.euler) == 0))
                                    {
                                        Connect(i1, i2, temp, matrixes_en.euler);
                                        Connect(i2, i1, temp, matrixes_en.euler);

                                        Connect(i1, i, temp, matrixes_en.euler);
                                        Connect(i, i1, temp, matrixes_en.euler);

                                        Connect(j, i2, temp, matrixes_en.euler);
                                        Connect(i2, j, temp, matrixes_en.euler);

                                        found = true;
                                    }

                    }
                }
            }
        }

        #endregion Euler

        #region Hamilton

        private bool _checkHamiltonConnect()
        {
            for (int i = 0; i < verticesAmount; i++)
                for (int j = 0; j < verticesAmount; j++)
                    if (!RouteExists(i, j, matrixes_en.hamilton))
                        return false;

            return true;
        }

        public bool IsHamilton()
        {
            if(hamiltonVersion == null)
            {
                if (symmetricVerticesAdjancencyMatrix == null)
                    GenerateSymmetric();
                hamiltonVersion = symmetricVerticesAdjancencyMatrix.Copy();
            }

            if (!_checkHamiltonConnect())
                return false;

            double minDegree = verticesAmount - 1;

            for (int i = 0; i < verticesAmount; i++)
            {
                double degree = 0;

                for (int j = 0; j < verticesAmount; j++)
                    if (routeLength(i, j, matrixes_en.hamilton) != 0)
                        degree++;

                if (degree == 0)
                    return false;

                if (degree < minDegree)
                    minDegree = degree;


            }

            return minDegree > verticesAmount / 2;
        }

        public void ModifyToHamilton()
        {
            if (IsHamilton())
                return;

            List<Point> softVerts = new List<Point>();
            Point temp;

            for (int i = 0; i < verticesAmount; i++)
            {
                int deg = 0;

                for (int j = 0; j < verticesAmount; j++)
                {
                    if ((i != j) && (routeLength(i, j, matrixes_en.hamilton) != 0))
                        deg++;
                }

                if (deg < ((verticesAmount + 1) / 2))
                    softVerts.Add(new Point(i, (verticesAmount + 1) / 2 - deg));
            }

            List<Point> badSoftVerts = new List<Point>();

            while (softVerts.Count > 1)
            {
                Point p = softVerts.ElementAt(0);
                softVerts.RemoveAt(0);

                for (int i = 0; (i < softVerts.Count) && (p.Y != 0); i++)
                {
                    temp = softVerts.ElementAt(i);

                    if ((temp.X != p.X) && (routeLength(p.X, temp.X, matrixes_en.hamilton) == 0))
                    {
                        temp.Y--;
                        p.Y--;

                        Connect(p.X, temp.X, 1, matrixes_en.hamilton);
                        Connect(temp.X, p.X, 1, matrixes_en.hamilton);
                    }

                    if (temp.Y == 0)
                    {
                        softVerts.RemoveAt(i);
                        i--;
                    }
                }

                if (p.Y != 0)
                    badSoftVerts.Add(p);
            }

            if (softVerts.Count == 0)
                return;

            badSoftVerts.Add(softVerts.ElementAt(0));
            softVerts.RemoveAt(0);
            //*
            while (badSoftVerts.Count != 0)
            {
                temp = badSoftVerts.ElementAt(0);
                badSoftVerts.RemoveAt(0);

                for (int i = 0; (i < verticesAmount) && (temp.Y != 0); i++)
                {
                    if ((temp.X != i) && (routeLength(temp.X, i, matrixes_en.hamilton) == 0))
                    {
                        Connect(temp.X, i, 1, matrixes_en.hamilton);
                        Connect(i, temp.X, 1, matrixes_en.hamilton);

                        temp.Y--;
                    }
                }
            }
        }

        #endregion Hamilton

        #region Euler route

        public List<int> EulerRoute()
        {
            if (!IsEuler())
                ModifyToEuler();

            List<int>[] adjancetyList = new List<int>[verticesAmount];
            Stack<int> rStack = new Stack<int>();
            List<int> res = new List<int>();
            int vert;

            for (int i = 0; i < verticesAmount; i++)
                adjancetyList[i] = new List<int>();

            for (int i = 0; i < verticesAmount; i++)
                for (int j = 0; j < verticesAmount; j++)
                    if ((i != j) && (routeLength(i, j, matrixes_en.euler) != 0))
                    {
                        adjancetyList[i].Add(j);
                        //adjancetyList[j].Add(i);
                    }

            rStack.Push(1);

            while (rStack.Count != 0)
            {
                vert = rStack.Peek();

                if (adjancetyList[vert].Count == 0)
                {
                    rStack.Pop();
                    res.Add(vert);
                }
                else
                {
                    int temp;

                    temp = adjancetyList[vert].ElementAt(0);
                    rStack.Push(temp);
                    adjancetyList[vert].RemoveAt(0);
                    adjancetyList[temp].RemoveAt(adjancetyList[temp].IndexOf(vert));
                }
            }

            return res;
        }

        #endregion Euler route

        #region TSP solving

        private List<List<int>> tspRoutes;
        private List<double> tspRoutesLengths;
        int minNumber;
        double minLength;


        public void FindTSPRoutes()
        {
            if (!IsHamilton())
                ModifyToHamilton();

            Queue<List<int>> routes = new Queue<List<int>>();
            tspRoutes = new List<List<int>>();

            const int start = 0;

            List<int> temp = new List<int>();
            temp.Add(start);

            routes.Enqueue(temp);

            while (routes.Count != 0)
            {
                temp = routes.Dequeue();

                for (int i = 0; i < verticesAmount; i++)
                {
                    if (routeLength(i, temp.ElementAt(temp.Count - 1), matrixes_en.hamilton) != 0)
                        if (!temp.Contains(i))
                        {
                            temp.Add(i);
                            routes.Enqueue(new List<int>(temp));
                            temp.RemoveAt(temp.IndexOf(i));
                        }
                        else
                            if ((temp.Count == verticesAmount) && (i == start))
                        {
                            temp.Add(start);
                            tspRoutes.Add(new List<int>(temp));
                        }

                }
            }
        }

        public void GetTSPRouteLengths()
        {
            bool minSet = false;

            tspRoutesLengths = new List<double>();
            minLength = 0;
            minNumber = 0;

            for (int i = 0; i < TSPRoutes.Count; i++)
            {
                double length = 0;

                for (int j = 0; j < verticesAmount; j++)
                    length += routeLength(TSPRoutes.ElementAt(i).ElementAt(j), TSPRoutes.ElementAt(i).ElementAt(j + 1), matrixes_en.hamilton);

                if (!minSet)
                {
                    minLength = length;
                    minNumber = i;
                    minSet = true;
                }
                else
                    if (minLength > length)
                {
                    minLength = length;
                    minNumber = i;
                }

                tspRoutesLengths.Add(length);
            }
        }

        #endregion TSP solving

        #endregion TSP

        #region Net

        public void GenerateNet(double maxStream, double maxPrice)
        {
            streamMatrix = new Matrix<double>(verticesAmount, verticesAmount);
            priceMatrix = new Matrix<double>(verticesAmount, verticesAmount);

            for (int i = 0; i < verticesAmount; i++)
                for (int j = i + 1; j < verticesAmount; j++)
                {
                    if (verticesAdjancencyMatrix.At(i, j) != 0)
                    {
                        streamMatrix.Set(i, j, Math.Round((1 - r.NextDouble()) * maxStream));
                        priceMatrix.Set(i, j, Math.Round((1 - r.NextDouble()) * maxPrice));
                    }
                }
        }

        private bool[] visitedVerts;

        public void FordFalkerston(int source, int sink, out double stream)
        {
            extraMatrix = new Matrix<double>(verticesAmount, verticesAmount);
            maxStreamMatrix = new Matrix<double>(verticesAmount, verticesAmount);
            maxStreamSourceMatrix = streamMatrix.Copy();    

            visitedVerts = new bool[verticesAmount];

            bool routeExists;
            int[] route;
            int iterations;
            double length;
            int pos;
            int routeVerts;
            double minWeigth;

            extraMatrix = streamMatrix.Copy();

            for (int i = 0; i < verticesAmount; i++)
            {
                if (RouteExists(i, source, matrixes_en.maxStreamSource))
                    Disconnect(i, source, matrixes_en.maxStreamSource);
                if (RouteExists(sink, i, matrixes_en.maxStreamSource))
                    Disconnect(sink, i, matrixes_en.maxStreamSource);
            }

            while(RouteExists(source, sink, matrixes_en.maxStreamSource))
            {
                route = DijkstraRoute(source, sink, out iterations, out routeExists, out length, matrixes_en.maxStreamSource);

                pos = sink;
                minWeigth = -1;

                while (pos != source)
                {
                    if ((minWeigth == -1) || (routeLength(route[pos], pos, matrixes_en.maxStreamSource) < minWeigth))
                        minWeigth = routeLength(route[pos], pos, matrixes_en.maxStreamSource);
                    pos = route[pos];
                }

                pos = sink;

                while (pos != source)
                {
                    maxStreamSourceMatrix.Set(route[pos], pos, maxStreamSourceMatrix.At(route[pos], pos) - minWeigth);
                    maxStreamMatrix.Set(route[pos], pos, maxStreamMatrix.At(route[pos], pos) + minWeigth);
                    pos = route[pos];
                }

            }

            stream = 0;

            for(int i = 0; i < verticesAmount; i++)
            {
                stream += maxStreamMatrix.At(source, i);
            }
        }
        /*
        public int[] MinimalPriceStream(int source, int sink, out double price)
        {
            int[] route;
            int pos;
            extraMatrix = new Matrix<double>(verticesAmount, verticesAmount);

            for(int i = 0; i < verticesAmount; i++)
                for(int j = i + 1; j < verticesAmount; j++)
                {
                    extraMatrix.Set(i, j, priceMatrix.At(i, j) * 2 / 3 * maxStreamMatrix.At(i, j));
                }

            route = DijkstraRoute(source, sink, out int iterations, out bool found, out double length, matrixes_en.extra);

            pos = sink;
            price = 0;

            while (pos != source)
            {
                price += routeLength(route[pos], pos, matrixes_en.extra);
                pos = route[pos];
            }

            return route;
        }
        //*/

        public void MinimalPriceStream(int source, int sink, out double price, int maxStream)
        {
            int[] route;
            int stream = 0;
            Matrix<double> temp1 = priceMatrix.Copy();
            Matrix<double> maxStreamReserve = maxStreamMatrix.Copy();
            bool streamBuilt = false;
            bool subRouteFound = false;
            int pos;
            int minStream;

            price = 0;
            minStreamMatrix = new Matrix<double>(verticesAmount, verticesAmount);

            for(int i = 0; i < verticesAmount; i++)
            {
                stream += (int)maxStreamMatrix.At(source, i);

                for(int j = 0; j < verticesAmount; j++)
                {
                    if ((temp1.At(i, j) != 0) && (maxStreamMatrix.At(i, j) == 0))
                        temp1.Set(i, j, 0);
                }
            }

            stream = stream * 2 / 3;
            extraMatrix = temp1.Copy();

            while(!streamBuilt)
            {
                route = DijkstraRoute(source, sink, out int i1, out subRouteFound, out double d1, matrixes_en.extra);

                if (!subRouteFound)
                    break;

                pos = sink;
                minStream = 0;

                while (pos != source)
                {
                    if (minStream == 0)
                        minStream = (int)maxStreamReserve.At(route[pos], pos);

                    if (minStream > (int)maxStreamReserve.At(route[pos], pos))
                        minStream = (int)maxStreamReserve.At(route[pos], pos);

                    pos = route[pos];
                }

                if(minStream > stream)
                {
                    streamBuilt = true;
                    minStream = stream;
                }

                stream -= minStream;

                pos = sink;

                while (pos != source)
                {
                    double t = (int)priceMatrix.At(route[pos], pos) * minStream;
                    price += t;

                    minStreamMatrix.Set(route[pos], pos, minStreamMatrix.At(route[pos], pos) + t);
                    maxStreamReserve.Set(route[pos], pos, maxStreamReserve.At(route[pos], pos) - minStream);

                    if (maxStreamReserve.At(route[pos], pos) == 0)
                        extraMatrix.Set(route[pos], pos, 0);

                    pos = route[pos];
                }
            }
        }

        public void PrintMinStream()
        {
            _getMatrixFromEn(matrixes_en.minStream).Print();
        }

        #endregion Net

        public void Connect(int first, int second, double length, matrixes_en en = matrixes_en.oriented)
        {
            Matrix<double> matrix = _getMatrixFromEn(en);

            matrix.Set(first, second, length);
            //edgesAmount += inc;
            //verticesAdjancencyMatrix.Set(second, first, length);
        }

        public void Disconnect(int first, int second, matrixes_en en = matrixes_en.oriented)
        {
            Matrix<double> matrix = _getMatrixFromEn(en);

            matrix.Set(first, second, 0);
            //edgesAmount -= inc;
            //verticesAdjancencyMatrix.Set(second, first, length);
        }

        public double routeLength(int x, int y, matrixes_en en = matrixes_en.oriented)
        {
            Matrix<double> matr = _getMatrixFromEn(en);
            return matr.At(x, y);
        }

    }
}
