namespace FoxRabbit
{
    partial class ShowGraphsForm
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
            this.zgc = new ZedGraph.ZedGraphControl();
            this.cmbCoordinateName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grb0 = new System.Windows.Forms.GroupBox();
            this.grb1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grb2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grb3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grb4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVariance4 = new FoxRabbit.LabelTextBox();
            this.txtAverage4 = new FoxRabbit.LabelTextBox();
            this.txtVariance3 = new FoxRabbit.LabelTextBox();
            this.txtAverage3 = new FoxRabbit.LabelTextBox();
            this.txtVariance2 = new FoxRabbit.LabelTextBox();
            this.txtAverage2 = new FoxRabbit.LabelTextBox();
            this.txtVariance1 = new FoxRabbit.LabelTextBox();
            this.txtAverage1 = new FoxRabbit.LabelTextBox();
            this.txtVariance0 = new FoxRabbit.LabelTextBox();
            this.txtAverage0 = new FoxRabbit.LabelTextBox();
            this.grb0.SuspendLayout();
            this.grb1.SuspendLayout();
            this.grb2.SuspendLayout();
            this.grb3.SuspendLayout();
            this.grb4.SuspendLayout();
            this.SuspendLayout();
            // 
            // zgc
            // 
            this.zgc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zgc.IsAntiAlias = true;
            this.zgc.IsAutoScrollRange = true;
            this.zgc.IsShowPointValues = true;
            this.zgc.Location = new System.Drawing.Point(12, 280);
            this.zgc.Name = "zgc";
            this.zgc.ScrollGrace = 0;
            this.zgc.ScrollMaxX = 0;
            this.zgc.ScrollMaxY = 0;
            this.zgc.ScrollMaxY2 = 0;
            this.zgc.ScrollMinX = 0;
            this.zgc.ScrollMinY = 0;
            this.zgc.ScrollMinY2 = 0;
            this.zgc.Size = new System.Drawing.Size(680, 395);
            this.zgc.TabIndex = 6;
            // 
            // cmbCoordinateName
            // 
            this.cmbCoordinateName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCoordinateName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCoordinateName.CausesValidation = false;
            this.cmbCoordinateName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCoordinateName.FormattingEnabled = true;
            this.cmbCoordinateName.Items.AddRange(new object[] {
            "DX (Distance of the fox from rabbit on X axis) Input data",
            "DY (Distance of the fox from rabbit on Y axis) Input data",
            "DXF (Amount of the fox displacement distances on the X axis)",
            "DYF (Amount of the fox displacement distances on the Y axis)"});
            this.cmbCoordinateName.Location = new System.Drawing.Point(329, 8);
            this.cmbCoordinateName.Name = "cmbCoordinateName";
            this.cmbCoordinateName.Size = new System.Drawing.Size(323, 21);
            this.cmbCoordinateName.TabIndex = 0;
            this.cmbCoordinateName.TabStop = false;
            this.cmbCoordinateName.Text = "DX (Distance of the fox from rabbit on X axis) Input data";
            this.cmbCoordinateName.SelectedIndexChanged += new System.EventHandler(this.cmbCoordinateName_SelectedIndexChanged);
            this.cmbCoordinateName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCoordinateName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Coordinate of comboBox to show or change:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(71, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Average :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(385, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Variance σ :";
            // 
            // grb0
            // 
            this.grb0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grb0.Controls.Add(this.txtVariance0);
            this.grb0.Controls.Add(this.label2);
            this.grb0.Controls.Add(this.txtAverage0);
            this.grb0.Controls.Add(this.label3);
            this.grb0.ForeColor = System.Drawing.Color.Red;
            this.grb0.Location = new System.Drawing.Point(12, 35);
            this.grb0.Name = "grb0";
            this.grb0.Size = new System.Drawing.Size(680, 43);
            this.grb0.TabIndex = 1;
            this.grb0.TabStop = false;
            this.grb0.Text = "Very Right";
            // 
            // grb1
            // 
            this.grb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grb1.Controls.Add(this.txtVariance1);
            this.grb1.Controls.Add(this.label4);
            this.grb1.Controls.Add(this.txtAverage1);
            this.grb1.Controls.Add(this.label5);
            this.grb1.ForeColor = System.Drawing.Color.DarkOrange;
            this.grb1.Location = new System.Drawing.Point(12, 84);
            this.grb1.Name = "grb1";
            this.grb1.Size = new System.Drawing.Size(680, 43);
            this.grb1.TabIndex = 2;
            this.grb1.TabStop = false;
            this.grb1.Text = "Right";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.Location = new System.Drawing.Point(71, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Average :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.Location = new System.Drawing.Point(385, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Variance σ :";
            // 
            // grb2
            // 
            this.grb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grb2.Controls.Add(this.txtVariance2);
            this.grb2.Controls.Add(this.label6);
            this.grb2.Controls.Add(this.txtAverage2);
            this.grb2.Controls.Add(this.label7);
            this.grb2.ForeColor = System.Drawing.Color.LimeGreen;
            this.grb2.Location = new System.Drawing.Point(12, 133);
            this.grb2.Name = "grb2";
            this.grb2.Size = new System.Drawing.Size(680, 43);
            this.grb2.TabIndex = 3;
            this.grb2.TabStop = false;
            this.grb2.Text = "Equal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label6.Location = new System.Drawing.Point(71, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Average :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label7.Location = new System.Drawing.Point(385, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Variance σ :";
            // 
            // grb3
            // 
            this.grb3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grb3.Controls.Add(this.txtVariance3);
            this.grb3.Controls.Add(this.label8);
            this.grb3.Controls.Add(this.txtAverage3);
            this.grb3.Controls.Add(this.label9);
            this.grb3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grb3.Location = new System.Drawing.Point(12, 182);
            this.grb3.Name = "grb3";
            this.grb3.Size = new System.Drawing.Size(680, 43);
            this.grb3.TabIndex = 4;
            this.grb3.TabStop = false;
            this.grb3.Text = "Left";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label8.Location = new System.Drawing.Point(71, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Average :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label9.Location = new System.Drawing.Point(385, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Variance σ :";
            // 
            // grb4
            // 
            this.grb4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grb4.Controls.Add(this.txtVariance4);
            this.grb4.Controls.Add(this.label10);
            this.grb4.Controls.Add(this.txtAverage4);
            this.grb4.Controls.Add(this.label11);
            this.grb4.ForeColor = System.Drawing.Color.Magenta;
            this.grb4.Location = new System.Drawing.Point(12, 231);
            this.grb4.Name = "grb4";
            this.grb4.Size = new System.Drawing.Size(680, 43);
            this.grb4.TabIndex = 5;
            this.grb4.TabStop = false;
            this.grb4.Text = "Very Left";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label10.Location = new System.Drawing.Point(71, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Average :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label11.Location = new System.Drawing.Point(385, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Variance σ :";
            // 
            // txtVariance4
            // 
            this.txtVariance4.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtVariance4.ForeColor = System.Drawing.Color.DarkGray;
            this.txtVariance4.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtVariance4.LabelColor = System.Drawing.Color.DarkGray;
            this.txtVariance4.LabelText = "واریانس";
            this.txtVariance4.Location = new System.Drawing.Point(470, 15);
            this.txtVariance4.Name = "txtVariance4";
            this.txtVariance4.Size = new System.Drawing.Size(100, 20);
            this.txtVariance4.TabIndex = 1;
            this.txtVariance4.Text = "واریانس";
            this.txtVariance4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVariance4.TextColor = System.Drawing.Color.Black;
            // 
            // txtAverage4
            // 
            this.txtAverage4.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtAverage4.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAverage4.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtAverage4.LabelColor = System.Drawing.Color.DarkGray;
            this.txtAverage4.LabelText = "میانگین";
            this.txtAverage4.Location = new System.Drawing.Point(143, 15);
            this.txtAverage4.Name = "txtAverage4";
            this.txtAverage4.Size = new System.Drawing.Size(100, 20);
            this.txtAverage4.TabIndex = 0;
            this.txtAverage4.Text = "میانگین";
            this.txtAverage4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAverage4.TextColor = System.Drawing.Color.Black;
            // 
            // txtVariance3
            // 
            this.txtVariance3.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtVariance3.ForeColor = System.Drawing.Color.DarkGray;
            this.txtVariance3.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtVariance3.LabelColor = System.Drawing.Color.DarkGray;
            this.txtVariance3.LabelText = "واریانس";
            this.txtVariance3.Location = new System.Drawing.Point(470, 15);
            this.txtVariance3.Name = "txtVariance3";
            this.txtVariance3.Size = new System.Drawing.Size(100, 20);
            this.txtVariance3.TabIndex = 1;
            this.txtVariance3.Text = "واریانس";
            this.txtVariance3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVariance3.TextColor = System.Drawing.Color.Black;
            // 
            // txtAverage3
            // 
            this.txtAverage3.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtAverage3.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAverage3.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtAverage3.LabelColor = System.Drawing.Color.DarkGray;
            this.txtAverage3.LabelText = "میانگین";
            this.txtAverage3.Location = new System.Drawing.Point(143, 15);
            this.txtAverage3.Name = "txtAverage3";
            this.txtAverage3.Size = new System.Drawing.Size(100, 20);
            this.txtAverage3.TabIndex = 0;
            this.txtAverage3.Text = "میانگین";
            this.txtAverage3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAverage3.TextColor = System.Drawing.Color.Black;
            // 
            // txtVariance2
            // 
            this.txtVariance2.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtVariance2.ForeColor = System.Drawing.Color.DarkGray;
            this.txtVariance2.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtVariance2.LabelColor = System.Drawing.Color.DarkGray;
            this.txtVariance2.LabelText = "واریانس";
            this.txtVariance2.Location = new System.Drawing.Point(470, 15);
            this.txtVariance2.Name = "txtVariance2";
            this.txtVariance2.Size = new System.Drawing.Size(100, 20);
            this.txtVariance2.TabIndex = 1;
            this.txtVariance2.Text = "واریانس";
            this.txtVariance2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVariance2.TextColor = System.Drawing.Color.Black;
            // 
            // txtAverage2
            // 
            this.txtAverage2.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtAverage2.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAverage2.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtAverage2.LabelColor = System.Drawing.Color.DarkGray;
            this.txtAverage2.LabelText = "میانگین";
            this.txtAverage2.Location = new System.Drawing.Point(143, 15);
            this.txtAverage2.Name = "txtAverage2";
            this.txtAverage2.Size = new System.Drawing.Size(100, 20);
            this.txtAverage2.TabIndex = 0;
            this.txtAverage2.Text = "میانگین";
            this.txtAverage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAverage2.TextColor = System.Drawing.Color.Black;
            // 
            // txtVariance1
            // 
            this.txtVariance1.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtVariance1.ForeColor = System.Drawing.Color.DarkGray;
            this.txtVariance1.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtVariance1.LabelColor = System.Drawing.Color.DarkGray;
            this.txtVariance1.LabelText = "واریانس";
            this.txtVariance1.Location = new System.Drawing.Point(470, 15);
            this.txtVariance1.Name = "txtVariance1";
            this.txtVariance1.Size = new System.Drawing.Size(100, 20);
            this.txtVariance1.TabIndex = 1;
            this.txtVariance1.Text = "واریانس";
            this.txtVariance1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVariance1.TextColor = System.Drawing.Color.Black;
            // 
            // txtAverage1
            // 
            this.txtAverage1.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtAverage1.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAverage1.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtAverage1.LabelColor = System.Drawing.Color.DarkGray;
            this.txtAverage1.LabelText = "میانگین";
            this.txtAverage1.Location = new System.Drawing.Point(143, 15);
            this.txtAverage1.Name = "txtAverage1";
            this.txtAverage1.Size = new System.Drawing.Size(100, 20);
            this.txtAverage1.TabIndex = 0;
            this.txtAverage1.Text = "میانگین";
            this.txtAverage1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAverage1.TextColor = System.Drawing.Color.Black;
            // 
            // txtVariance0
            // 
            this.txtVariance0.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtVariance0.ForeColor = System.Drawing.Color.DarkGray;
            this.txtVariance0.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtVariance0.LabelColor = System.Drawing.Color.DarkGray;
            this.txtVariance0.LabelText = "واریانس";
            this.txtVariance0.Location = new System.Drawing.Point(470, 15);
            this.txtVariance0.Name = "txtVariance0";
            this.txtVariance0.Size = new System.Drawing.Size(100, 20);
            this.txtVariance0.TabIndex = 1;
            this.txtVariance0.Text = "واریانس";
            this.txtVariance0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVariance0.TextColor = System.Drawing.Color.Black;
            // 
            // txtAverage0
            // 
            this.txtAverage0.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.txtAverage0.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAverage0.Format = FoxRabbit.TextBoxFormat.Numeric;
            this.txtAverage0.LabelColor = System.Drawing.Color.DarkGray;
            this.txtAverage0.LabelText = "میانگین";
            this.txtAverage0.Location = new System.Drawing.Point(143, 15);
            this.txtAverage0.Name = "txtAverage0";
            this.txtAverage0.Size = new System.Drawing.Size(100, 20);
            this.txtAverage0.TabIndex = 0;
            this.txtAverage0.Text = "میانگین";
            this.txtAverage0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAverage0.TextColor = System.Drawing.Color.Black;
            // 
            // ShowGraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 687);
            this.Controls.Add(this.grb4);
            this.Controls.Add(this.grb3);
            this.Controls.Add(this.grb2);
            this.Controls.Add(this.grb1);
            this.Controls.Add(this.grb0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCoordinateName);
            this.Controls.Add(this.zgc);
            this.Name = "ShowGraphsForm";
            this.Text = "Fuzzy Logic for Control Fox in Expert System";
            this.Load += new System.EventHandler(this.ShowGraphsForm_Load);
            this.grb0.ResumeLayout(false);
            this.grb0.PerformLayout();
            this.grb1.ResumeLayout(false);
            this.grb1.PerformLayout();
            this.grb2.ResumeLayout(false);
            this.grb2.PerformLayout();
            this.grb3.ResumeLayout(false);
            this.grb3.PerformLayout();
            this.grb4.ResumeLayout(false);
            this.grb4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zgc;
        private System.Windows.Forms.ComboBox cmbCoordinateName;
        private System.Windows.Forms.Label label1;
        private FoxRabbit.LabelTextBox txtAverage0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FoxRabbit.LabelTextBox txtVariance0;
        private System.Windows.Forms.GroupBox grb0;
        private System.Windows.Forms.GroupBox grb1;
        private FoxRabbit.LabelTextBox txtVariance1;
        private System.Windows.Forms.Label label4;
        private FoxRabbit.LabelTextBox txtAverage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grb2;
        private FoxRabbit.LabelTextBox txtVariance2;
        private System.Windows.Forms.Label label6;
        private FoxRabbit.LabelTextBox txtAverage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grb3;
        private FoxRabbit.LabelTextBox txtVariance3;
        private System.Windows.Forms.Label label8;
        private FoxRabbit.LabelTextBox txtAverage3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grb4;
        private FoxRabbit.LabelTextBox txtVariance4;
        private System.Windows.Forms.Label label10;
        private FoxRabbit.LabelTextBox txtAverage4;
        private System.Windows.Forms.Label label11;

    }
}