namespace CellularAutomation
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
            this.automationPB = new System.Windows.Forms.PictureBox();
            this.consoleTB = new System.Windows.Forms.TextBox();
            this.codeTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monocelllularCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.screenWidthTB = new System.Windows.Forms.TextBox();
            this.userWidthTB = new System.Windows.Forms.TextBox();
            this.userWidthRB = new System.Windows.Forms.RadioButton();
            this.screenWidthRB = new System.Windows.Forms.RadioButton();
            this.startConditions = new System.Windows.Forms.GroupBox();
            this.randomGB = new System.Windows.Forms.GroupBox();
            this.maxWidthTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxWidthCB = new System.Windows.Forms.CheckBox();
            this.minWidthCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minWidthTB = new System.Windows.Forms.TextBox();
            this.randomInputRB = new System.Windows.Forms.RadioButton();
            this.customRowTB = new System.Windows.Forms.TextBox();
            this.customInputRowRB = new System.Windows.Forms.RadioButton();
            this.soloOneRB = new System.Windows.Forms.RadioButton();
            this.zeroRowRB = new System.Windows.Forms.RadioButton();
            this.inverseCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.automationPB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.startConditions.SuspendLayout();
            this.randomGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // automationPB
            // 
            this.automationPB.Location = new System.Drawing.Point(1389, 444);
            this.automationPB.Name = "automationPB";
            this.automationPB.Size = new System.Drawing.Size(163, 206);
            this.automationPB.TabIndex = 0;
            this.automationPB.TabStop = false;
            // 
            // consoleTB
            // 
            this.consoleTB.Location = new System.Drawing.Point(15, 133);
            this.consoleTB.Multiline = true;
            this.consoleTB.Name = "consoleTB";
            this.consoleTB.ReadOnly = true;
            this.consoleTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleTB.Size = new System.Drawing.Size(278, 517);
            this.consoleTB.TabIndex = 1;
            // 
            // codeTB
            // 
            this.codeTB.Location = new System.Drawing.Point(110, 12);
            this.codeTB.Name = "codeTB";
            this.codeTB.Size = new System.Drawing.Size(183, 20);
            this.codeTB.TabIndex = 2;
            this.codeTB.Text = "160";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер автомата";
            // 
            // monocelllularCreate
            // 
            this.monocelllularCreate.Location = new System.Drawing.Point(308, 12);
            this.monocelllularCreate.Name = "monocelllularCreate";
            this.monocelllularCreate.Size = new System.Drawing.Size(109, 52);
            this.monocelllularCreate.TabIndex = 4;
            this.monocelllularCreate.Text = "Одноклеточный автомат";
            this.monocelllularCreate.UseVisualStyleBackColor = true;
            this.monocelllularCreate.Click += new System.EventHandler(this.monocelllularCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.screenWidthTB);
            this.groupBox1.Controls.Add(this.userWidthTB);
            this.groupBox1.Controls.Add(this.userWidthRB);
            this.groupBox1.Controls.Add(this.screenWidthRB);
            this.groupBox1.Location = new System.Drawing.Point(15, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ширина поля";
            // 
            // screenWidthTB
            // 
            this.screenWidthTB.Location = new System.Drawing.Point(134, 18);
            this.screenWidthTB.Name = "screenWidthTB";
            this.screenWidthTB.ReadOnly = true;
            this.screenWidthTB.Size = new System.Drawing.Size(138, 20);
            this.screenWidthTB.TabIndex = 6;
            // 
            // userWidthTB
            // 
            this.userWidthTB.Location = new System.Drawing.Point(134, 42);
            this.userWidthTB.Name = "userWidthTB";
            this.userWidthTB.Size = new System.Drawing.Size(138, 20);
            this.userWidthTB.TabIndex = 2;
            this.userWidthTB.Text = "1024";
            // 
            // userWidthRB
            // 
            this.userWidthRB.AutoSize = true;
            this.userWidthRB.Location = new System.Drawing.Point(6, 42);
            this.userWidthRB.Name = "userWidthRB";
            this.userWidthRB.Size = new System.Drawing.Size(122, 17);
            this.userWidthRB.TabIndex = 1;
            this.userWidthRB.Text = "Пользовательская";
            this.userWidthRB.UseVisualStyleBackColor = true;
            // 
            // screenWidthRB
            // 
            this.screenWidthRB.AutoSize = true;
            this.screenWidthRB.Checked = true;
            this.screenWidthRB.Location = new System.Drawing.Point(6, 19);
            this.screenWidthRB.Name = "screenWidthRB";
            this.screenWidthRB.Size = new System.Drawing.Size(119, 17);
            this.screenWidthRB.TabIndex = 0;
            this.screenWidthRB.TabStop = true;
            this.screenWidthRB.Text = "По ширине экрана";
            this.screenWidthRB.UseVisualStyleBackColor = true;
            // 
            // startConditions
            // 
            this.startConditions.Controls.Add(this.randomGB);
            this.startConditions.Controls.Add(this.randomInputRB);
            this.startConditions.Controls.Add(this.customRowTB);
            this.startConditions.Controls.Add(this.customInputRowRB);
            this.startConditions.Controls.Add(this.soloOneRB);
            this.startConditions.Controls.Add(this.zeroRowRB);
            this.startConditions.Location = new System.Drawing.Point(308, 70);
            this.startConditions.Name = "startConditions";
            this.startConditions.Size = new System.Drawing.Size(277, 580);
            this.startConditions.TabIndex = 6;
            this.startConditions.TabStop = false;
            this.startConditions.Text = "Начальные условия";
            // 
            // randomGB
            // 
            this.randomGB.Controls.Add(this.maxWidthTB);
            this.randomGB.Controls.Add(this.label3);
            this.randomGB.Controls.Add(this.maxWidthCB);
            this.randomGB.Controls.Add(this.minWidthCB);
            this.randomGB.Controls.Add(this.label2);
            this.randomGB.Controls.Add(this.minWidthTB);
            this.randomGB.Enabled = false;
            this.randomGB.Location = new System.Drawing.Point(6, 137);
            this.randomGB.Name = "randomGB";
            this.randomGB.Size = new System.Drawing.Size(194, 211);
            this.randomGB.TabIndex = 6;
            this.randomGB.TabStop = false;
            this.randomGB.Text = "Параметры случайной генерации";
            // 
            // maxWidthTB
            // 
            this.maxWidthTB.Location = new System.Drawing.Point(82, 82);
            this.maxWidthTB.Name = "maxWidthTB";
            this.maxWidthTB.Size = new System.Drawing.Size(106, 20);
            this.maxWidthTB.TabIndex = 5;
            this.maxWidthTB.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ширина ряда";
            // 
            // maxWidthCB
            // 
            this.maxWidthCB.AutoSize = true;
            this.maxWidthCB.Checked = true;
            this.maxWidthCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maxWidthCB.Location = new System.Drawing.Point(6, 62);
            this.maxWidthCB.Name = "maxWidthCB";
            this.maxWidthCB.Size = new System.Drawing.Size(144, 17);
            this.maxWidthCB.TabIndex = 3;
            this.maxWidthCB.Text = "Максимальная ширина";
            this.maxWidthCB.UseVisualStyleBackColor = true;
            this.maxWidthCB.CheckedChanged += new System.EventHandler(this.maxWidthCB_CheckedChanged);
            // 
            // minWidthCB
            // 
            this.minWidthCB.AutoSize = true;
            this.minWidthCB.Checked = true;
            this.minWidthCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minWidthCB.Location = new System.Drawing.Point(6, 19);
            this.minWidthCB.Name = "minWidthCB";
            this.minWidthCB.Size = new System.Drawing.Size(138, 17);
            this.minWidthCB.TabIndex = 2;
            this.minWidthCB.Text = "Минимальная ширина";
            this.minWidthCB.UseVisualStyleBackColor = true;
            this.minWidthCB.CheckedChanged += new System.EventHandler(this.minWidthCB_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ширина ряда";
            // 
            // minWidthTB
            // 
            this.minWidthTB.Location = new System.Drawing.Point(82, 36);
            this.minWidthTB.Name = "minWidthTB";
            this.minWidthTB.Size = new System.Drawing.Size(106, 20);
            this.minWidthTB.TabIndex = 0;
            this.minWidthTB.Text = "1";
            // 
            // randomInputRB
            // 
            this.randomInputRB.AutoSize = true;
            this.randomInputRB.Location = new System.Drawing.Point(6, 114);
            this.randomInputRB.Name = "randomInputRB";
            this.randomInputRB.Size = new System.Drawing.Size(124, 17);
            this.randomInputRB.TabIndex = 5;
            this.randomInputRB.TabStop = true;
            this.randomInputRB.Text = "Случайные условия";
            this.randomInputRB.UseVisualStyleBackColor = true;
            this.randomInputRB.CheckedChanged += new System.EventHandler(this.randomInputRB_CheckedChanged);
            // 
            // customRowTB
            // 
            this.customRowTB.Enabled = false;
            this.customRowTB.Location = new System.Drawing.Point(6, 88);
            this.customRowTB.Name = "customRowTB";
            this.customRowTB.Size = new System.Drawing.Size(194, 20);
            this.customRowTB.TabIndex = 4;
            this.customRowTB.Text = "1";
            // 
            // customInputRowRB
            // 
            this.customInputRowRB.AutoSize = true;
            this.customInputRowRB.Location = new System.Drawing.Point(6, 65);
            this.customInputRowRB.Name = "customInputRowRB";
            this.customInputRowRB.Size = new System.Drawing.Size(97, 17);
            this.customInputRowRB.TabIndex = 2;
            this.customInputRowRB.Text = "Заданный ряд";
            this.customInputRowRB.UseVisualStyleBackColor = true;
            this.customInputRowRB.CheckedChanged += new System.EventHandler(this.customInputRowRB_CheckedChanged);
            // 
            // soloOneRB
            // 
            this.soloOneRB.AutoSize = true;
            this.soloOneRB.Checked = true;
            this.soloOneRB.Location = new System.Drawing.Point(6, 42);
            this.soloOneRB.Name = "soloOneRB";
            this.soloOneRB.Size = new System.Drawing.Size(68, 17);
            this.soloOneRB.TabIndex = 1;
            this.soloOneRB.TabStop = true;
            this.soloOneRB.Text = "Единица";
            this.soloOneRB.UseVisualStyleBackColor = true;
            // 
            // zeroRowRB
            // 
            this.zeroRowRB.AutoSize = true;
            this.zeroRowRB.Location = new System.Drawing.Point(6, 19);
            this.zeroRowRB.Name = "zeroRowRB";
            this.zeroRowRB.Size = new System.Drawing.Size(51, 17);
            this.zeroRowRB.TabIndex = 0;
            this.zeroRowRB.Text = "Ноль";
            this.zeroRowRB.UseVisualStyleBackColor = true;
            this.zeroRowRB.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // inverseCB
            // 
            this.inverseCB.AutoSize = true;
            this.inverseCB.Location = new System.Drawing.Point(422, 12);
            this.inverseCB.Name = "inverseCB";
            this.inverseCB.Size = new System.Drawing.Size(108, 17);
            this.inverseCB.TabIndex = 7;
            this.inverseCB.Text = "Инверсия цвета";
            this.inverseCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 662);
            this.Controls.Add(this.inverseCB);
            this.Controls.Add(this.startConditions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.monocelllularCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeTB);
            this.Controls.Add(this.consoleTB);
            this.Controls.Add(this.automationPB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.automationPB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.startConditions.ResumeLayout(false);
            this.startConditions.PerformLayout();
            this.randomGB.ResumeLayout(false);
            this.randomGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox automationPB;
        private System.Windows.Forms.TextBox consoleTB;
        private System.Windows.Forms.TextBox codeTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button monocelllularCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton userWidthRB;
        private System.Windows.Forms.RadioButton screenWidthRB;
        private System.Windows.Forms.TextBox screenWidthTB;
        private System.Windows.Forms.TextBox userWidthTB;
        private System.Windows.Forms.GroupBox startConditions;
        private System.Windows.Forms.RadioButton customInputRowRB;
        private System.Windows.Forms.RadioButton soloOneRB;
        private System.Windows.Forms.RadioButton zeroRowRB;
        private System.Windows.Forms.TextBox customRowTB;
        private System.Windows.Forms.RadioButton randomInputRB;
        private System.Windows.Forms.GroupBox randomGB;
        private System.Windows.Forms.TextBox maxWidthTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox maxWidthCB;
        private System.Windows.Forms.CheckBox minWidthCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox minWidthTB;
        private System.Windows.Forms.CheckBox inverseCB;
    }
}

