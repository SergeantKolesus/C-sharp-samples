namespace Lab1._3
{
    partial class s
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.generateGB = new System.Windows.Forms.GroupBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.maxWeightTB = new System.Windows.Forms.TextBox();
            this.minWeightTB = new System.Windows.Forms.TextBox();
            this.wigthLbl2 = new System.Windows.Forms.Label();
            this.weigthLbl1 = new System.Windows.Forms.Label();
            this.edgesAmountTB = new System.Windows.Forms.TextBox();
            this.nodesAmountTB = new System.Windows.Forms.TextBox();
            this.edgesAmountLbl = new System.Windows.Forms.Label();
            this.vertsAmountLbl = new System.Windows.Forms.Label();
            this.showNodesAdjButton = new System.Windows.Forms.Button();
            this.errorLogTB = new System.Windows.Forms.TextBox();
            this.shimbellGB = new System.Windows.Forms.GroupBox();
            this.shimbellButton = new System.Windows.Forms.Button();
            this.shimbellEdgesTB = new System.Windows.Forms.TextBox();
            this.shimbellEdgesLbl = new System.Windows.Forms.Label();
            this.routesGB = new System.Windows.Forms.GroupBox();
            this.routeInfoTB = new System.Windows.Forms.TextBox();
            this.floydWorshallButton = new System.Windows.Forms.Button();
            this.bellmanFordButton = new System.Windows.Forms.Button();
            this.dijkstraButton = new System.Windows.Forms.Button();
            this.routeExistanceButton = new System.Windows.Forms.Button();
            this.routeEndLbl = new System.Windows.Forms.Label();
            this.routeEndTB = new System.Windows.Forms.TextBox();
            this.routeStartTB = new System.Windows.Forms.TextBox();
            this.routeStartLbl = new System.Windows.Forms.Label();
            this.astilGB = new System.Windows.Forms.GroupBox();
            this.astilTB = new System.Windows.Forms.TextBox();
            this.pruferDecodeButton = new System.Windows.Forms.Button();
            this.pruferButton = new System.Windows.Forms.Button();
            this.kirchoffButton = new System.Windows.Forms.Button();
            this.kruskalButton = new System.Windows.Forms.Button();
            this.primButton = new System.Windows.Forms.Button();
            this.showSymmetricButton = new System.Windows.Forms.Button();
            this.astilButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.showKirchoffButton = new System.Windows.Forms.Button();
            this.TSPGB = new System.Windows.Forms.GroupBox();
            this.TSPTB = new System.Windows.Forms.TextBox();
            this.printTSPToFileButton = new System.Windows.Forms.Button();
            this.printTSPButton = new System.Windows.Forms.Button();
            this.solveTSPButton = new System.Windows.Forms.Button();
            this.eulerRouteButton = new System.Windows.Forms.Button();
            this.modifyHamilton = new System.Windows.Forms.Button();
            this.modifyEulerGraph = new System.Windows.Forms.Button();
            this.checkHamiltonButton = new System.Windows.Forms.Button();
            this.checkEulerButton = new System.Windows.Forms.Button();
            this.showEulerButton = new System.Windows.Forms.Button();
            this.showHamiltonButton = new System.Windows.Forms.Button();
            this.NetGB = new System.Windows.Forms.GroupBox();
            this.minPriceStreamButton = new System.Windows.Forms.Button();
            this.netTB = new System.Windows.Forms.TextBox();
            this.formFulkerstonButton = new System.Windows.Forms.Button();
            this.buildNetButton = new System.Windows.Forms.Button();
            this.sourceTB = new System.Windows.Forms.TextBox();
            this.sinkTB = new System.Windows.Forms.TextBox();
            this.sourceLbl = new System.Windows.Forms.Label();
            this.sinkLbl = new System.Windows.Forms.Label();
            this.maxPriceLbl = new System.Windows.Forms.Label();
            this.maxStreamLbl = new System.Windows.Forms.Label();
            this.maxPriceTB = new System.Windows.Forms.TextBox();
            this.maxStreamTB = new System.Windows.Forms.TextBox();
            this.printStreamButton = new System.Windows.Forms.Button();
            this.printPriceButton = new System.Windows.Forms.Button();
            this.maxStreamMatrix = new System.Windows.Forms.Button();
            this.incidencyButton = new System.Windows.Forms.Button();
            this.minPriceStreamPrintButton = new System.Windows.Forms.Button();
            this.distributionButton = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.PictureBox();
            this.generateGB.SuspendLayout();
            this.shimbellGB.SuspendLayout();
            this.routesGB.SuspendLayout();
            this.astilGB.SuspendLayout();
            this.TSPGB.SuspendLayout();
            this.NetGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // generateGB
            // 
            this.generateGB.Controls.Add(this.generateButton);
            this.generateGB.Controls.Add(this.maxWeightTB);
            this.generateGB.Controls.Add(this.minWeightTB);
            this.generateGB.Controls.Add(this.wigthLbl2);
            this.generateGB.Controls.Add(this.weigthLbl1);
            this.generateGB.Controls.Add(this.edgesAmountTB);
            this.generateGB.Controls.Add(this.nodesAmountTB);
            this.generateGB.Controls.Add(this.edgesAmountLbl);
            this.generateGB.Controls.Add(this.vertsAmountLbl);
            this.generateGB.Location = new System.Drawing.Point(12, 12);
            this.generateGB.Name = "generateGB";
            this.generateGB.Size = new System.Drawing.Size(200, 159);
            this.generateGB.TabIndex = 0;
            this.generateGB.TabStop = false;
            this.generateGB.Text = "Генерация графа";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(9, 129);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(185, 23);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // maxWeightTB
            // 
            this.maxWeightTB.Location = new System.Drawing.Point(144, 93);
            this.maxWeightTB.Name = "maxWeightTB";
            this.maxWeightTB.Size = new System.Drawing.Size(50, 20);
            this.maxWeightTB.TabIndex = 7;
            this.maxWeightTB.Text = "50";
            // 
            // minWeightTB
            // 
            this.minWeightTB.Location = new System.Drawing.Point(79, 93);
            this.minWeightTB.Name = "minWeightTB";
            this.minWeightTB.Size = new System.Drawing.Size(51, 20);
            this.minWeightTB.TabIndex = 6;
            this.minWeightTB.Text = "0";
            // 
            // wigthLbl2
            // 
            this.wigthLbl2.AutoSize = true;
            this.wigthLbl2.Location = new System.Drawing.Point(128, 96);
            this.wigthLbl2.Name = "wigthLbl2";
            this.wigthLbl2.Size = new System.Drawing.Size(19, 13);
            this.wigthLbl2.TabIndex = 5;
            this.wigthLbl2.Text = "до";
            // 
            // weigthLbl1
            // 
            this.weigthLbl1.AutoSize = true;
            this.weigthLbl1.Location = new System.Drawing.Point(6, 96);
            this.weigthLbl1.Name = "weigthLbl1";
            this.weigthLbl1.Size = new System.Drawing.Size(76, 13);
            this.weigthLbl1.TabIndex = 4;
            this.weigthLbl1.Text = "Вес ребер: от";
            // 
            // edgesAmountTB
            // 
            this.edgesAmountTB.Location = new System.Drawing.Point(92, 48);
            this.edgesAmountTB.Name = "edgesAmountTB";
            this.edgesAmountTB.Size = new System.Drawing.Size(102, 20);
            this.edgesAmountTB.TabIndex = 3;
            this.edgesAmountTB.Text = "13";
            // 
            // nodesAmountTB
            // 
            this.nodesAmountTB.Location = new System.Drawing.Point(92, 22);
            this.nodesAmountTB.Name = "nodesAmountTB";
            this.nodesAmountTB.Size = new System.Drawing.Size(102, 20);
            this.nodesAmountTB.TabIndex = 2;
            this.nodesAmountTB.Text = "10";
            // 
            // edgesAmountLbl
            // 
            this.edgesAmountLbl.AutoSize = true;
            this.edgesAmountLbl.Location = new System.Drawing.Point(6, 51);
            this.edgesAmountLbl.Name = "edgesAmountLbl";
            this.edgesAmountLbl.Size = new System.Drawing.Size(72, 13);
            this.edgesAmountLbl.TabIndex = 1;
            this.edgesAmountLbl.Text = "Число ребер";
            // 
            // vertsAmountLbl
            // 
            this.vertsAmountLbl.AutoSize = true;
            this.vertsAmountLbl.Location = new System.Drawing.Point(6, 25);
            this.vertsAmountLbl.Name = "vertsAmountLbl";
            this.vertsAmountLbl.Size = new System.Drawing.Size(80, 13);
            this.vertsAmountLbl.TabIndex = 0;
            this.vertsAmountLbl.Text = "Число вершин";
            // 
            // showNodesAdjButton
            // 
            this.showNodesAdjButton.Location = new System.Drawing.Point(1083, 12);
            this.showNodesAdjButton.Name = "showNodesAdjButton";
            this.showNodesAdjButton.Size = new System.Drawing.Size(174, 23);
            this.showNodesAdjButton.TabIndex = 9;
            this.showNodesAdjButton.Text = "Матрица смежности вершин";
            this.showNodesAdjButton.UseVisualStyleBackColor = true;
            this.showNodesAdjButton.Click += new System.EventHandler(this.showNodesAdjButton_Click);
            // 
            // errorLogTB
            // 
            this.errorLogTB.Location = new System.Drawing.Point(12, 177);
            this.errorLogTB.Multiline = true;
            this.errorLogTB.Name = "errorLogTB";
            this.errorLogTB.ReadOnly = true;
            this.errorLogTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorLogTB.Size = new System.Drawing.Size(200, 148);
            this.errorLogTB.TabIndex = 10;
            // 
            // shimbellGB
            // 
            this.shimbellGB.Controls.Add(this.shimbellButton);
            this.shimbellGB.Controls.Add(this.shimbellEdgesTB);
            this.shimbellGB.Controls.Add(this.shimbellEdgesLbl);
            this.shimbellGB.Location = new System.Drawing.Point(218, 21);
            this.shimbellGB.Name = "shimbellGB";
            this.shimbellGB.Size = new System.Drawing.Size(200, 75);
            this.shimbellGB.TabIndex = 11;
            this.shimbellGB.TabStop = false;
            this.shimbellGB.Text = "Алгоритм Шимбелла";
            // 
            // shimbellButton
            // 
            this.shimbellButton.Location = new System.Drawing.Point(9, 43);
            this.shimbellButton.Name = "shimbellButton";
            this.shimbellButton.Size = new System.Drawing.Size(185, 23);
            this.shimbellButton.TabIndex = 2;
            this.shimbellButton.Text = "Вычислить";
            this.shimbellButton.UseVisualStyleBackColor = true;
            this.shimbellButton.Click += new System.EventHandler(this.shimbellButton_Click);
            // 
            // shimbellEdgesTB
            // 
            this.shimbellEdgesTB.Location = new System.Drawing.Point(84, 17);
            this.shimbellEdgesTB.Name = "shimbellEdgesTB";
            this.shimbellEdgesTB.Size = new System.Drawing.Size(110, 20);
            this.shimbellEdgesTB.TabIndex = 1;
            this.shimbellEdgesTB.Text = "2";
            // 
            // shimbellEdgesLbl
            // 
            this.shimbellEdgesLbl.AutoSize = true;
            this.shimbellEdgesLbl.Location = new System.Drawing.Point(6, 20);
            this.shimbellEdgesLbl.Name = "shimbellEdgesLbl";
            this.shimbellEdgesLbl.Size = new System.Drawing.Size(72, 13);
            this.shimbellEdgesLbl.TabIndex = 0;
            this.shimbellEdgesLbl.Text = "Число ребер";
            // 
            // routesGB
            // 
            this.routesGB.Controls.Add(this.routeInfoTB);
            this.routesGB.Controls.Add(this.floydWorshallButton);
            this.routesGB.Controls.Add(this.bellmanFordButton);
            this.routesGB.Controls.Add(this.dijkstraButton);
            this.routesGB.Controls.Add(this.routeExistanceButton);
            this.routesGB.Controls.Add(this.routeEndLbl);
            this.routesGB.Controls.Add(this.routeEndTB);
            this.routesGB.Controls.Add(this.routeStartTB);
            this.routesGB.Controls.Add(this.routeStartLbl);
            this.routesGB.Location = new System.Drawing.Point(218, 102);
            this.routesGB.Name = "routesGB";
            this.routesGB.Size = new System.Drawing.Size(200, 336);
            this.routesGB.TabIndex = 12;
            this.routesGB.TabStop = false;
            this.routesGB.Text = "Алгоритмы поиска пути";
            // 
            // routeInfoTB
            // 
            this.routeInfoTB.Location = new System.Drawing.Point(6, 187);
            this.routeInfoTB.Multiline = true;
            this.routeInfoTB.Name = "routeInfoTB";
            this.routeInfoTB.ReadOnly = true;
            this.routeInfoTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.routeInfoTB.Size = new System.Drawing.Size(188, 143);
            this.routeInfoTB.TabIndex = 8;
            // 
            // floydWorshallButton
            // 
            this.floydWorshallButton.Location = new System.Drawing.Point(6, 158);
            this.floydWorshallButton.Name = "floydWorshallButton";
            this.floydWorshallButton.Size = new System.Drawing.Size(188, 23);
            this.floydWorshallButton.TabIndex = 7;
            this.floydWorshallButton.Text = "Алгоритм Флойда-Уоршалла";
            this.floydWorshallButton.UseVisualStyleBackColor = true;
            this.floydWorshallButton.Click += new System.EventHandler(this.floydWorshallButton_Click);
            // 
            // bellmanFordButton
            // 
            this.bellmanFordButton.Location = new System.Drawing.Point(6, 129);
            this.bellmanFordButton.Name = "bellmanFordButton";
            this.bellmanFordButton.Size = new System.Drawing.Size(188, 23);
            this.bellmanFordButton.TabIndex = 6;
            this.bellmanFordButton.Text = "Алгоритм Беллмана-Форда";
            this.bellmanFordButton.UseVisualStyleBackColor = true;
            this.bellmanFordButton.Click += new System.EventHandler(this.bellmanFordButton_Click);
            // 
            // dijkstraButton
            // 
            this.dijkstraButton.Location = new System.Drawing.Point(6, 100);
            this.dijkstraButton.Name = "dijkstraButton";
            this.dijkstraButton.Size = new System.Drawing.Size(188, 23);
            this.dijkstraButton.TabIndex = 5;
            this.dijkstraButton.Text = "Алгоритм Дийкстры";
            this.dijkstraButton.UseVisualStyleBackColor = true;
            this.dijkstraButton.Click += new System.EventHandler(this.dijkstraButton_Click);
            // 
            // routeExistanceButton
            // 
            this.routeExistanceButton.Location = new System.Drawing.Point(6, 71);
            this.routeExistanceButton.Name = "routeExistanceButton";
            this.routeExistanceButton.Size = new System.Drawing.Size(188, 23);
            this.routeExistanceButton.TabIndex = 4;
            this.routeExistanceButton.Text = "Проверить существование пути";
            this.routeExistanceButton.UseVisualStyleBackColor = true;
            this.routeExistanceButton.Click += new System.EventHandler(this.routeExistanceButton_Click);
            // 
            // routeEndLbl
            // 
            this.routeEndLbl.AutoSize = true;
            this.routeEndLbl.Location = new System.Drawing.Point(6, 48);
            this.routeEndLbl.Name = "routeEndLbl";
            this.routeEndLbl.Size = new System.Drawing.Size(63, 13);
            this.routeEndLbl.TabIndex = 3;
            this.routeEndLbl.Text = "Конец пути";
            // 
            // routeEndTB
            // 
            this.routeEndTB.Location = new System.Drawing.Point(81, 45);
            this.routeEndTB.Name = "routeEndTB";
            this.routeEndTB.Size = new System.Drawing.Size(113, 20);
            this.routeEndTB.TabIndex = 2;
            this.routeEndTB.Text = "2";
            // 
            // routeStartTB
            // 
            this.routeStartTB.Location = new System.Drawing.Point(81, 19);
            this.routeStartTB.Name = "routeStartTB";
            this.routeStartTB.Size = new System.Drawing.Size(113, 20);
            this.routeStartTB.TabIndex = 1;
            this.routeStartTB.Text = "1";
            // 
            // routeStartLbl
            // 
            this.routeStartLbl.AutoSize = true;
            this.routeStartLbl.Location = new System.Drawing.Point(6, 22);
            this.routeStartLbl.Name = "routeStartLbl";
            this.routeStartLbl.Size = new System.Drawing.Size(69, 13);
            this.routeStartLbl.TabIndex = 0;
            this.routeStartLbl.Text = "Начало пути";
            // 
            // astilGB
            // 
            this.astilGB.Controls.Add(this.astilTB);
            this.astilGB.Controls.Add(this.pruferDecodeButton);
            this.astilGB.Controls.Add(this.pruferButton);
            this.astilGB.Controls.Add(this.kirchoffButton);
            this.astilGB.Controls.Add(this.kruskalButton);
            this.astilGB.Controls.Add(this.primButton);
            this.astilGB.Location = new System.Drawing.Point(424, 21);
            this.astilGB.Name = "astilGB";
            this.astilGB.Size = new System.Drawing.Size(139, 417);
            this.astilGB.TabIndex = 13;
            this.astilGB.TabStop = false;
            this.astilGB.Text = "Остов";
            // 
            // astilTB
            // 
            this.astilTB.Location = new System.Drawing.Point(6, 164);
            this.astilTB.Multiline = true;
            this.astilTB.Name = "astilTB";
            this.astilTB.ReadOnly = true;
            this.astilTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.astilTB.Size = new System.Drawing.Size(124, 247);
            this.astilTB.TabIndex = 5;
            // 
            // pruferDecodeButton
            // 
            this.pruferDecodeButton.Location = new System.Drawing.Point(6, 135);
            this.pruferDecodeButton.Name = "pruferDecodeButton";
            this.pruferDecodeButton.Size = new System.Drawing.Size(124, 23);
            this.pruferDecodeButton.TabIndex = 4;
            this.pruferDecodeButton.Text = "Декодировать";
            this.pruferDecodeButton.UseVisualStyleBackColor = true;
            this.pruferDecodeButton.Click += new System.EventHandler(this.pruferDecodeButton_Click);
            // 
            // pruferButton
            // 
            this.pruferButton.Location = new System.Drawing.Point(6, 106);
            this.pruferButton.Name = "pruferButton";
            this.pruferButton.Size = new System.Drawing.Size(124, 23);
            this.pruferButton.TabIndex = 3;
            this.pruferButton.Text = "Код Прюфера";
            this.pruferButton.UseVisualStyleBackColor = true;
            this.pruferButton.Click += new System.EventHandler(this.pruferButton_Click);
            // 
            // kirchoffButton
            // 
            this.kirchoffButton.Location = new System.Drawing.Point(6, 77);
            this.kirchoffButton.Name = "kirchoffButton";
            this.kirchoffButton.Size = new System.Drawing.Size(124, 23);
            this.kirchoffButton.TabIndex = 2;
            this.kirchoffButton.Text = "Алгоритм Кирхгоффа";
            this.kirchoffButton.UseVisualStyleBackColor = true;
            this.kirchoffButton.Click += new System.EventHandler(this.kirchoffButton_Click);
            // 
            // kruskalButton
            // 
            this.kruskalButton.Location = new System.Drawing.Point(6, 48);
            this.kruskalButton.Name = "kruskalButton";
            this.kruskalButton.Size = new System.Drawing.Size(124, 23);
            this.kruskalButton.TabIndex = 1;
            this.kruskalButton.Text = "Алгоритм Краскала";
            this.kruskalButton.UseVisualStyleBackColor = true;
            this.kruskalButton.Click += new System.EventHandler(this.kruskalButton_Click);
            // 
            // primButton
            // 
            this.primButton.Location = new System.Drawing.Point(6, 19);
            this.primButton.Name = "primButton";
            this.primButton.Size = new System.Drawing.Size(124, 23);
            this.primButton.TabIndex = 0;
            this.primButton.Text = "Алгоритм Прима";
            this.primButton.UseVisualStyleBackColor = true;
            this.primButton.Click += new System.EventHandler(this.primButton_Click);
            // 
            // showSymmetricButton
            // 
            this.showSymmetricButton.Location = new System.Drawing.Point(1083, 41);
            this.showSymmetricButton.Name = "showSymmetricButton";
            this.showSymmetricButton.Size = new System.Drawing.Size(174, 42);
            this.showSymmetricButton.TabIndex = 14;
            this.showSymmetricButton.Text = "Симметричная матрица смежности вершин";
            this.showSymmetricButton.UseVisualStyleBackColor = true;
            this.showSymmetricButton.Click += new System.EventHandler(this.showSymmetricButton_Click);
            // 
            // astilButton
            // 
            this.astilButton.Location = new System.Drawing.Point(1083, 89);
            this.astilButton.Name = "astilButton";
            this.astilButton.Size = new System.Drawing.Size(174, 23);
            this.astilButton.TabIndex = 15;
            this.astilButton.Text = "Остов";
            this.astilButton.UseVisualStyleBackColor = true;
            this.astilButton.Click += new System.EventHandler(this.astilButton_Click);
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(12, 409);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(200, 23);
            this.abortButton.TabIndex = 16;
            this.abortButton.Text = "Отмена";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // showKirchoffButton
            // 
            this.showKirchoffButton.Location = new System.Drawing.Point(1083, 118);
            this.showKirchoffButton.Name = "showKirchoffButton";
            this.showKirchoffButton.Size = new System.Drawing.Size(174, 23);
            this.showKirchoffButton.TabIndex = 17;
            this.showKirchoffButton.Text = "Матрица Кирхгоффа";
            this.showKirchoffButton.UseVisualStyleBackColor = true;
            this.showKirchoffButton.Click += new System.EventHandler(this.showKirchoffButton_Click);
            // 
            // TSPGB
            // 
            this.TSPGB.Controls.Add(this.TSPTB);
            this.TSPGB.Controls.Add(this.printTSPToFileButton);
            this.TSPGB.Controls.Add(this.printTSPButton);
            this.TSPGB.Controls.Add(this.solveTSPButton);
            this.TSPGB.Controls.Add(this.eulerRouteButton);
            this.TSPGB.Controls.Add(this.modifyHamilton);
            this.TSPGB.Controls.Add(this.modifyEulerGraph);
            this.TSPGB.Controls.Add(this.checkHamiltonButton);
            this.TSPGB.Controls.Add(this.checkEulerButton);
            this.TSPGB.Location = new System.Drawing.Point(793, 21);
            this.TSPGB.Name = "TSPGB";
            this.TSPGB.Size = new System.Drawing.Size(284, 417);
            this.TSPGB.TabIndex = 18;
            this.TSPGB.TabStop = false;
            this.TSPGB.Text = "Проблема комивояжера";
            // 
            // TSPTB
            // 
            this.TSPTB.Location = new System.Drawing.Point(6, 164);
            this.TSPTB.Multiline = true;
            this.TSPTB.Name = "TSPTB";
            this.TSPTB.ReadOnly = true;
            this.TSPTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TSPTB.Size = new System.Drawing.Size(272, 247);
            this.TSPTB.TabIndex = 8;
            // 
            // printTSPToFileButton
            // 
            this.printTSPToFileButton.Location = new System.Drawing.Point(131, 135);
            this.printTSPToFileButton.Name = "printTSPToFileButton";
            this.printTSPToFileButton.Size = new System.Drawing.Size(147, 23);
            this.printTSPToFileButton.TabIndex = 7;
            this.printTSPToFileButton.Text = "Вывести в файл";
            this.printTSPToFileButton.UseVisualStyleBackColor = true;
            this.printTSPToFileButton.Click += new System.EventHandler(this.printTSPToFileButton_Click);
            // 
            // printTSPButton
            // 
            this.printTSPButton.Location = new System.Drawing.Point(6, 135);
            this.printTSPButton.Name = "printTSPButton";
            this.printTSPButton.Size = new System.Drawing.Size(119, 23);
            this.printTSPButton.TabIndex = 6;
            this.printTSPButton.Text = "Вывести решение";
            this.printTSPButton.UseVisualStyleBackColor = true;
            this.printTSPButton.Click += new System.EventHandler(this.printTSPButton_Click);
            // 
            // solveTSPButton
            // 
            this.solveTSPButton.Location = new System.Drawing.Point(6, 106);
            this.solveTSPButton.Name = "solveTSPButton";
            this.solveTSPButton.Size = new System.Drawing.Size(272, 23);
            this.solveTSPButton.TabIndex = 5;
            this.solveTSPButton.Text = "Решить проблему комивояжера";
            this.solveTSPButton.UseVisualStyleBackColor = true;
            this.solveTSPButton.Click += new System.EventHandler(this.solveTSPButton_Click);
            // 
            // eulerRouteButton
            // 
            this.eulerRouteButton.Location = new System.Drawing.Point(6, 77);
            this.eulerRouteButton.Name = "eulerRouteButton";
            this.eulerRouteButton.Size = new System.Drawing.Size(119, 23);
            this.eulerRouteButton.TabIndex = 4;
            this.eulerRouteButton.Text = "Эйлеров путь";
            this.eulerRouteButton.UseVisualStyleBackColor = true;
            this.eulerRouteButton.Click += new System.EventHandler(this.eulerRouteButton_Click);
            // 
            // modifyHamilton
            // 
            this.modifyHamilton.Location = new System.Drawing.Point(131, 48);
            this.modifyHamilton.Name = "modifyHamilton";
            this.modifyHamilton.Size = new System.Drawing.Size(147, 23);
            this.modifyHamilton.TabIndex = 3;
            this.modifyHamilton.Text = "Построить Гамильтонов";
            this.modifyHamilton.UseVisualStyleBackColor = true;
            this.modifyHamilton.Click += new System.EventHandler(this.modifyHamilton_Click);
            // 
            // modifyEulerGraph
            // 
            this.modifyEulerGraph.Location = new System.Drawing.Point(6, 48);
            this.modifyEulerGraph.Name = "modifyEulerGraph";
            this.modifyEulerGraph.Size = new System.Drawing.Size(119, 23);
            this.modifyEulerGraph.TabIndex = 2;
            this.modifyEulerGraph.Text = "Построить Эйлеров";
            this.modifyEulerGraph.UseVisualStyleBackColor = true;
            this.modifyEulerGraph.Click += new System.EventHandler(this.modifyEulerGraph_Click);
            // 
            // checkHamiltonButton
            // 
            this.checkHamiltonButton.Location = new System.Drawing.Point(131, 19);
            this.checkHamiltonButton.Name = "checkHamiltonButton";
            this.checkHamiltonButton.Size = new System.Drawing.Size(147, 23);
            this.checkHamiltonButton.TabIndex = 1;
            this.checkHamiltonButton.Text = "Проверить Гамильтонов";
            this.checkHamiltonButton.UseVisualStyleBackColor = true;
            this.checkHamiltonButton.Click += new System.EventHandler(this.checkHamiltonButton_Click);
            // 
            // checkEulerButton
            // 
            this.checkEulerButton.Location = new System.Drawing.Point(6, 19);
            this.checkEulerButton.Name = "checkEulerButton";
            this.checkEulerButton.Size = new System.Drawing.Size(119, 23);
            this.checkEulerButton.TabIndex = 0;
            this.checkEulerButton.Text = "Проверить Эйлеров";
            this.checkEulerButton.UseVisualStyleBackColor = true;
            this.checkEulerButton.Click += new System.EventHandler(this.checkEulerButton_Click);
            // 
            // showEulerButton
            // 
            this.showEulerButton.Location = new System.Drawing.Point(1083, 147);
            this.showEulerButton.Name = "showEulerButton";
            this.showEulerButton.Size = new System.Drawing.Size(174, 23);
            this.showEulerButton.TabIndex = 19;
            this.showEulerButton.Text = "Эйлеров граф";
            this.showEulerButton.UseVisualStyleBackColor = true;
            this.showEulerButton.Click += new System.EventHandler(this.showEulerButton_Click);
            // 
            // showHamiltonButton
            // 
            this.showHamiltonButton.Location = new System.Drawing.Point(1083, 176);
            this.showHamiltonButton.Name = "showHamiltonButton";
            this.showHamiltonButton.Size = new System.Drawing.Size(174, 23);
            this.showHamiltonButton.TabIndex = 20;
            this.showHamiltonButton.Text = "Гамильтонов граф";
            this.showHamiltonButton.UseVisualStyleBackColor = true;
            this.showHamiltonButton.Click += new System.EventHandler(this.showHamiltonButton_Click);
            // 
            // NetGB
            // 
            this.NetGB.Controls.Add(this.minPriceStreamButton);
            this.NetGB.Controls.Add(this.netTB);
            this.NetGB.Controls.Add(this.formFulkerstonButton);
            this.NetGB.Controls.Add(this.buildNetButton);
            this.NetGB.Controls.Add(this.sourceTB);
            this.NetGB.Controls.Add(this.sinkTB);
            this.NetGB.Controls.Add(this.sourceLbl);
            this.NetGB.Controls.Add(this.sinkLbl);
            this.NetGB.Controls.Add(this.maxPriceLbl);
            this.NetGB.Controls.Add(this.maxStreamLbl);
            this.NetGB.Controls.Add(this.maxPriceTB);
            this.NetGB.Controls.Add(this.maxStreamTB);
            this.NetGB.Location = new System.Drawing.Point(569, 21);
            this.NetGB.Name = "NetGB";
            this.NetGB.Size = new System.Drawing.Size(218, 417);
            this.NetGB.TabIndex = 21;
            this.NetGB.TabStop = false;
            this.NetGB.Text = "Сеть";
            // 
            // minPriceStreamButton
            // 
            this.minPriceStreamButton.Location = new System.Drawing.Point(6, 193);
            this.minPriceStreamButton.Name = "minPriceStreamButton";
            this.minPriceStreamButton.Size = new System.Drawing.Size(206, 40);
            this.minPriceStreamButton.TabIndex = 11;
            this.minPriceStreamButton.Text = "Найти поток минимальной стоимости";
            this.minPriceStreamButton.UseVisualStyleBackColor = true;
            this.minPriceStreamButton.Click += new System.EventHandler(this.minPriceStreamButton_Click);
            // 
            // netTB
            // 
            this.netTB.Location = new System.Drawing.Point(6, 239);
            this.netTB.Multiline = true;
            this.netTB.Name = "netTB";
            this.netTB.ReadOnly = true;
            this.netTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.netTB.Size = new System.Drawing.Size(206, 172);
            this.netTB.TabIndex = 10;
            // 
            // formFulkerstonButton
            // 
            this.formFulkerstonButton.Location = new System.Drawing.Point(6, 164);
            this.formFulkerstonButton.Name = "formFulkerstonButton";
            this.formFulkerstonButton.Size = new System.Drawing.Size(206, 23);
            this.formFulkerstonButton.TabIndex = 9;
            this.formFulkerstonButton.Text = "Алгортим Форда-Фалкерстона";
            this.formFulkerstonButton.UseVisualStyleBackColor = true;
            this.formFulkerstonButton.Click += new System.EventHandler(this.formFulkerstonButton_Click);
            // 
            // buildNetButton
            // 
            this.buildNetButton.Location = new System.Drawing.Point(6, 135);
            this.buildNetButton.Name = "buildNetButton";
            this.buildNetButton.Size = new System.Drawing.Size(206, 23);
            this.buildNetButton.TabIndex = 8;
            this.buildNetButton.Text = "Построить сеть";
            this.buildNetButton.UseVisualStyleBackColor = true;
            this.buildNetButton.Click += new System.EventHandler(this.buildNetButton_Click);
            // 
            // sourceTB
            // 
            this.sourceTB.Location = new System.Drawing.Point(50, 108);
            this.sourceTB.Name = "sourceTB";
            this.sourceTB.Size = new System.Drawing.Size(162, 20);
            this.sourceTB.TabIndex = 7;
            this.sourceTB.Text = "1";
            // 
            // sinkTB
            // 
            this.sinkTB.Location = new System.Drawing.Point(50, 79);
            this.sinkTB.Name = "sinkTB";
            this.sinkTB.Size = new System.Drawing.Size(162, 20);
            this.sinkTB.TabIndex = 6;
            this.sinkTB.Text = "2";
            // 
            // sourceLbl
            // 
            this.sourceLbl.AutoSize = true;
            this.sourceLbl.Location = new System.Drawing.Point(6, 111);
            this.sourceLbl.Name = "sourceLbl";
            this.sourceLbl.Size = new System.Drawing.Size(38, 13);
            this.sourceLbl.TabIndex = 5;
            this.sourceLbl.Text = "Исток";
            // 
            // sinkLbl
            // 
            this.sinkLbl.AutoSize = true;
            this.sinkLbl.Location = new System.Drawing.Point(6, 82);
            this.sinkLbl.Name = "sinkLbl";
            this.sinkLbl.Size = new System.Drawing.Size(31, 13);
            this.sinkLbl.TabIndex = 4;
            this.sinkLbl.Text = "Сток";
            // 
            // maxPriceLbl
            // 
            this.maxPriceLbl.AutoSize = true;
            this.maxPriceLbl.Location = new System.Drawing.Point(6, 53);
            this.maxPriceLbl.Name = "maxPriceLbl";
            this.maxPriceLbl.Size = new System.Drawing.Size(141, 13);
            this.maxPriceLbl.TabIndex = 3;
            this.maxPriceLbl.Text = "Максимальцая стоимость";
            // 
            // maxStreamLbl
            // 
            this.maxStreamLbl.AutoSize = true;
            this.maxStreamLbl.Location = new System.Drawing.Point(6, 24);
            this.maxStreamLbl.Name = "maxStreamLbl";
            this.maxStreamLbl.Size = new System.Drawing.Size(118, 13);
            this.maxStreamLbl.TabIndex = 2;
            this.maxStreamLbl.Text = "Максимальный поток";
            // 
            // maxPriceTB
            // 
            this.maxPriceTB.Location = new System.Drawing.Point(153, 50);
            this.maxPriceTB.Name = "maxPriceTB";
            this.maxPriceTB.Size = new System.Drawing.Size(59, 20);
            this.maxPriceTB.TabIndex = 1;
            this.maxPriceTB.Text = "10";
            // 
            // maxStreamTB
            // 
            this.maxStreamTB.Location = new System.Drawing.Point(153, 21);
            this.maxStreamTB.Name = "maxStreamTB";
            this.maxStreamTB.Size = new System.Drawing.Size(59, 20);
            this.maxStreamTB.TabIndex = 0;
            this.maxStreamTB.Text = "25";
            // 
            // printStreamButton
            // 
            this.printStreamButton.Location = new System.Drawing.Point(1083, 205);
            this.printStreamButton.Name = "printStreamButton";
            this.printStreamButton.Size = new System.Drawing.Size(174, 23);
            this.printStreamButton.TabIndex = 22;
            this.printStreamButton.Text = "Матрица потоков";
            this.printStreamButton.UseVisualStyleBackColor = true;
            this.printStreamButton.Click += new System.EventHandler(this.printStreamButton_Click);
            // 
            // printPriceButton
            // 
            this.printPriceButton.Location = new System.Drawing.Point(1083, 234);
            this.printPriceButton.Name = "printPriceButton";
            this.printPriceButton.Size = new System.Drawing.Size(174, 23);
            this.printPriceButton.TabIndex = 23;
            this.printPriceButton.Text = "Матрица стоимостей";
            this.printPriceButton.UseVisualStyleBackColor = true;
            this.printPriceButton.Click += new System.EventHandler(this.printPriceButton_Click);
            // 
            // maxStreamMatrix
            // 
            this.maxStreamMatrix.Location = new System.Drawing.Point(1083, 263);
            this.maxStreamMatrix.Name = "maxStreamMatrix";
            this.maxStreamMatrix.Size = new System.Drawing.Size(174, 37);
            this.maxStreamMatrix.TabIndex = 24;
            this.maxStreamMatrix.Text = "Матрица максимального потока";
            this.maxStreamMatrix.UseVisualStyleBackColor = true;
            this.maxStreamMatrix.Click += new System.EventHandler(this.maxStreamMatrix_Click);
            // 
            // incidencyButton
            // 
            this.incidencyButton.Location = new System.Drawing.Point(1083, 306);
            this.incidencyButton.Name = "incidencyButton";
            this.incidencyButton.Size = new System.Drawing.Size(174, 23);
            this.incidencyButton.TabIndex = 25;
            this.incidencyButton.Text = "Матрица инцидентности";
            this.incidencyButton.UseVisualStyleBackColor = true;
            this.incidencyButton.Click += new System.EventHandler(this.incidencyButton_Click);
            // 
            // minPriceStreamPrintButton
            // 
            this.minPriceStreamPrintButton.Location = new System.Drawing.Point(1083, 335);
            this.minPriceStreamPrintButton.Name = "minPriceStreamPrintButton";
            this.minPriceStreamPrintButton.Size = new System.Drawing.Size(174, 34);
            this.minPriceStreamPrintButton.TabIndex = 26;
            this.minPriceStreamPrintButton.Text = "Поток минимальной стоимости";
            this.minPriceStreamPrintButton.UseVisualStyleBackColor = true;
            this.minPriceStreamPrintButton.Click += new System.EventHandler(this.minPriceStreamPrintButton_Click);
            // 
            // distributionButton
            // 
            this.distributionButton.Location = new System.Drawing.Point(12, 380);
            this.distributionButton.Name = "distributionButton";
            this.distributionButton.Size = new System.Drawing.Size(200, 23);
            this.distributionButton.TabIndex = 27;
            this.distributionButton.Text = "График распределения";
            this.distributionButton.UseVisualStyleBackColor = true;
            this.distributionButton.Click += new System.EventHandler(this.distributionButton_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(12, 438);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(200, 147);
            this.pb.TabIndex = 28;
            this.pb.TabStop = false;
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 597);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.distributionButton);
            this.Controls.Add(this.minPriceStreamPrintButton);
            this.Controls.Add(this.incidencyButton);
            this.Controls.Add(this.maxStreamMatrix);
            this.Controls.Add(this.printPriceButton);
            this.Controls.Add(this.printStreamButton);
            this.Controls.Add(this.NetGB);
            this.Controls.Add(this.showHamiltonButton);
            this.Controls.Add(this.showEulerButton);
            this.Controls.Add(this.TSPGB);
            this.Controls.Add(this.showKirchoffButton);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.astilButton);
            this.Controls.Add(this.showSymmetricButton);
            this.Controls.Add(this.astilGB);
            this.Controls.Add(this.routesGB);
            this.Controls.Add(this.shimbellGB);
            this.Controls.Add(this.errorLogTB);
            this.Controls.Add(this.showNodesAdjButton);
            this.Controls.Add(this.generateGB);
            this.Name = "s";
            this.Text = "Lab";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Lab_FormClosed);
            this.generateGB.ResumeLayout(false);
            this.generateGB.PerformLayout();
            this.shimbellGB.ResumeLayout(false);
            this.shimbellGB.PerformLayout();
            this.routesGB.ResumeLayout(false);
            this.routesGB.PerformLayout();
            this.astilGB.ResumeLayout(false);
            this.astilGB.PerformLayout();
            this.TSPGB.ResumeLayout(false);
            this.TSPGB.PerformLayout();
            this.NetGB.ResumeLayout(false);
            this.NetGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox generateGB;
        private System.Windows.Forms.TextBox edgesAmountTB;
        private System.Windows.Forms.TextBox nodesAmountTB;
        private System.Windows.Forms.Label edgesAmountLbl;
        private System.Windows.Forms.Label vertsAmountLbl;
        private System.Windows.Forms.Label weigthLbl1;
        private System.Windows.Forms.TextBox maxWeightTB;
        private System.Windows.Forms.TextBox minWeightTB;
        private System.Windows.Forms.Label wigthLbl2;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button showNodesAdjButton;
        private System.Windows.Forms.TextBox errorLogTB;
        private System.Windows.Forms.GroupBox shimbellGB;
        private System.Windows.Forms.TextBox shimbellEdgesTB;
        private System.Windows.Forms.Label shimbellEdgesLbl;
        private System.Windows.Forms.Button shimbellButton;
        private System.Windows.Forms.GroupBox routesGB;
        private System.Windows.Forms.Label routeEndLbl;
        private System.Windows.Forms.TextBox routeEndTB;
        private System.Windows.Forms.TextBox routeStartTB;
        private System.Windows.Forms.Label routeStartLbl;
        private System.Windows.Forms.Button floydWorshallButton;
        private System.Windows.Forms.Button bellmanFordButton;
        private System.Windows.Forms.Button dijkstraButton;
        private System.Windows.Forms.Button routeExistanceButton;
        private System.Windows.Forms.TextBox routeInfoTB;
        private System.Windows.Forms.GroupBox astilGB;
        private System.Windows.Forms.Button kirchoffButton;
        private System.Windows.Forms.Button kruskalButton;
        private System.Windows.Forms.Button primButton;
        private System.Windows.Forms.Button showSymmetricButton;
        private System.Windows.Forms.Button astilButton;
        private System.Windows.Forms.TextBox astilTB;
        private System.Windows.Forms.Button pruferDecodeButton;
        private System.Windows.Forms.Button pruferButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Button showKirchoffButton;
        private System.Windows.Forms.TextBox TSPTB;
        private System.Windows.Forms.Button printTSPToFileButton;
        private System.Windows.Forms.Button printTSPButton;
        private System.Windows.Forms.Button solveTSPButton;
        private System.Windows.Forms.Button eulerRouteButton;
        private System.Windows.Forms.Button modifyHamilton;
        private System.Windows.Forms.Button modifyEulerGraph;
        private System.Windows.Forms.Button checkHamiltonButton;
        private System.Windows.Forms.Button checkEulerButton;
        private System.Windows.Forms.Button showEulerButton;
        private System.Windows.Forms.Button showHamiltonButton;
        private System.Windows.Forms.GroupBox TSPGB;
        private System.Windows.Forms.GroupBox NetGB;
        private System.Windows.Forms.Label maxPriceLbl;
        private System.Windows.Forms.Label maxStreamLbl;
        private System.Windows.Forms.TextBox maxPriceTB;
        private System.Windows.Forms.TextBox maxStreamTB;
        private System.Windows.Forms.Button formFulkerstonButton;
        private System.Windows.Forms.Button buildNetButton;
        private System.Windows.Forms.TextBox sourceTB;
        private System.Windows.Forms.TextBox sinkTB;
        private System.Windows.Forms.Label sourceLbl;
        private System.Windows.Forms.Label sinkLbl;
        private System.Windows.Forms.Button printStreamButton;
        private System.Windows.Forms.Button printPriceButton;
        private System.Windows.Forms.Button maxStreamMatrix;
        private System.Windows.Forms.TextBox netTB;
        private System.Windows.Forms.Button minPriceStreamButton;
        private System.Windows.Forms.Button incidencyButton;
        private System.Windows.Forms.Button minPriceStreamPrintButton;
        private System.Windows.Forms.Button distributionButton;
        private System.Windows.Forms.PictureBox pb;
    }
}