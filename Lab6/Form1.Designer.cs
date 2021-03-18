namespace Lab6
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.createTreeButton = new System.Windows.Forms.Button();
            this.filenameTB = new System.Windows.Forms.TextBox();
            this.treePrintButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.elementTB = new System.Windows.Forms.TextBox();
            this.foundElementLabel = new System.Windows.Forms.Label();
            this.routeLabel = new System.Windows.Forms.Label();
            this.printNormallyButton = new System.Windows.Forms.Button();
            this.dictionaryTB = new System.Windows.Forms.TextBox();
            this.createEmptyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createTreeButton
            // 
            this.createTreeButton.Location = new System.Drawing.Point(12, 12);
            this.createTreeButton.Name = "createTreeButton";
            this.createTreeButton.Size = new System.Drawing.Size(75, 23);
            this.createTreeButton.TabIndex = 0;
            this.createTreeButton.Text = "Create";
            this.createTreeButton.UseVisualStyleBackColor = true;
            this.createTreeButton.Click += new System.EventHandler(this.createTreeButton_Click);
            // 
            // filenameTB
            // 
            this.filenameTB.Location = new System.Drawing.Point(93, 15);
            this.filenameTB.Name = "filenameTB";
            this.filenameTB.Size = new System.Drawing.Size(155, 20);
            this.filenameTB.TabIndex = 1;
            this.filenameTB.Text = "Test.txt";
            // 
            // treePrintButton
            // 
            this.treePrintButton.Location = new System.Drawing.Point(254, 12);
            this.treePrintButton.Name = "treePrintButton";
            this.treePrintButton.Size = new System.Drawing.Size(75, 23);
            this.treePrintButton.TabIndex = 2;
            this.treePrintButton.Text = "Print as tree";
            this.treePrintButton.UseVisualStyleBackColor = true;
            this.treePrintButton.Click += new System.EventHandler(this.treePrintButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 41);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(12, 70);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 4;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 99);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // elementTB
            // 
            this.elementTB.Location = new System.Drawing.Point(93, 43);
            this.elementTB.Name = "elementTB";
            this.elementTB.Size = new System.Drawing.Size(236, 20);
            this.elementTB.TabIndex = 6;
            // 
            // foundElementLabel
            // 
            this.foundElementLabel.AutoSize = true;
            this.foundElementLabel.Location = new System.Drawing.Point(93, 75);
            this.foundElementLabel.Name = "foundElementLabel";
            this.foundElementLabel.Size = new System.Drawing.Size(0, 13);
            this.foundElementLabel.TabIndex = 7;
            // 
            // routeLabel
            // 
            this.routeLabel.AutoSize = true;
            this.routeLabel.Location = new System.Drawing.Point(93, 104);
            this.routeLabel.Name = "routeLabel";
            this.routeLabel.Size = new System.Drawing.Size(39, 13);
            this.routeLabel.TabIndex = 8;
            this.routeLabel.Text = "Route:";
            // 
            // printNormallyButton
            // 
            this.printNormallyButton.Location = new System.Drawing.Point(13, 129);
            this.printNormallyButton.Name = "printNormallyButton";
            this.printNormallyButton.Size = new System.Drawing.Size(75, 23);
            this.printNormallyButton.TabIndex = 9;
            this.printNormallyButton.Text = "Print";
            this.printNormallyButton.UseVisualStyleBackColor = true;
            this.printNormallyButton.Click += new System.EventHandler(this.printNormallyButton_Click);
            // 
            // dictionaryTB
            // 
            this.dictionaryTB.Location = new System.Drawing.Point(13, 158);
            this.dictionaryTB.Multiline = true;
            this.dictionaryTB.Name = "dictionaryTB";
            this.dictionaryTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dictionaryTB.Size = new System.Drawing.Size(381, 280);
            this.dictionaryTB.TabIndex = 10;
            // 
            // createEmptyButton
            // 
            this.createEmptyButton.Location = new System.Drawing.Point(335, 12);
            this.createEmptyButton.Name = "createEmptyButton";
            this.createEmptyButton.Size = new System.Drawing.Size(87, 23);
            this.createEmptyButton.TabIndex = 11;
            this.createEmptyButton.Text = "Create empty";
            this.createEmptyButton.UseVisualStyleBackColor = true;
            this.createEmptyButton.Click += new System.EventHandler(this.createEmptyButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createEmptyButton);
            this.Controls.Add(this.dictionaryTB);
            this.Controls.Add(this.printNormallyButton);
            this.Controls.Add(this.routeLabel);
            this.Controls.Add(this.foundElementLabel);
            this.Controls.Add(this.elementTB);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.treePrintButton);
            this.Controls.Add(this.filenameTB);
            this.Controls.Add(this.createTreeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createTreeButton;
        private System.Windows.Forms.TextBox filenameTB;
        private System.Windows.Forms.Button treePrintButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox elementTB;
        private System.Windows.Forms.Label foundElementLabel;
        private System.Windows.Forms.Label routeLabel;
        private System.Windows.Forms.Button printNormallyButton;
        private System.Windows.Forms.TextBox dictionaryTB;
        private System.Windows.Forms.Button createEmptyButton;
    }
}

