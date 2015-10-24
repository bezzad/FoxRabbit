namespace FoxRabbit
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Rabbit = new System.Windows.Forms.PictureBox();
            this.Fox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRabbitLoc = new System.Windows.Forms.Label();
            this.chbtnShowMenu = new System.Windows.Forms.CheckBox();
            this.chbtnStartStop = new System.Windows.Forms.CheckBox();
            this.lblFoxLoc = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timerTickCount = new System.Windows.Forms.Timer(this.components);
            this.trkRenderSpeed = new System.Windows.Forms.TrackBar();
            this.lblClientSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Rabbit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkRenderSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // Rabbit
            // 
            this.Rabbit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Rabbit.BackColor = System.Drawing.Color.Transparent;
            this.Rabbit.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Rabbit.Image = global::FoxRabbit.Properties.Resources.rabbit;
            this.Rabbit.Location = new System.Drawing.Point(595, 393);
            this.Rabbit.Name = "Rabbit";
            this.Rabbit.Size = new System.Drawing.Size(70, 70);
            this.Rabbit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Rabbit.TabIndex = 0;
            this.Rabbit.TabStop = false;
            this.Rabbit.LocationChanged += new System.EventHandler(this.Rabbit_LocationChanged);
            this.Rabbit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Rabbit_MouseMove);
            this.Rabbit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Rabbit_MouseDown);
            this.Rabbit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Rabbit_MouseUp);
            // 
            // Fox
            // 
            this.Fox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fox.BackColor = System.Drawing.Color.Transparent;
            this.Fox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Fox.Image = global::FoxRabbit.Properties.Resources.fox;
            this.Fox.Location = new System.Drawing.Point(209, 175);
            this.Fox.Name = "Fox";
            this.Fox.Size = new System.Drawing.Size(70, 70);
            this.Fox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Fox.TabIndex = 0;
            this.Fox.TabStop = false;
            this.Fox.LocationChanged += new System.EventHandler(this.Fox_LocationChanged);
            this.Fox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Fox_MouseMove);
            this.Fox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Fox_MouseDown);
            this.Fox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Fox_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 745);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fox Location:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 745);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rabbit Location:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRabbitLoc
            // 
            this.lblRabbitLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRabbitLoc.AutoSize = true;
            this.lblRabbitLoc.ForeColor = System.Drawing.Color.Maroon;
            this.lblRabbitLoc.Location = new System.Drawing.Point(285, 745);
            this.lblRabbitLoc.Name = "lblRabbitLoc";
            this.lblRabbitLoc.Size = new System.Drawing.Size(48, 13);
            this.lblRabbitLoc.TabIndex = 2;
            this.lblRabbitLoc.Text = "xyRabbit";
            // 
            // chbtnShowMenu
            // 
            this.chbtnShowMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbtnShowMenu.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbtnShowMenu.AutoSize = true;
            this.chbtnShowMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbtnShowMenu.FlatAppearance.BorderSize = 2;
            this.chbtnShowMenu.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chbtnShowMenu.Location = new System.Drawing.Point(718, 734);
            this.chbtnShowMenu.Name = "chbtnShowMenu";
            this.chbtnShowMenu.Size = new System.Drawing.Size(74, 23);
            this.chbtnShowMenu.TabIndex = 3;
            this.chbtnShowMenu.Text = "Show &Menu";
            this.chbtnShowMenu.UseVisualStyleBackColor = true;
            this.chbtnShowMenu.CheckedChanged += new System.EventHandler(this.chbtnShowMenu_CheckedChanged);
            // 
            // chbtnStartStop
            // 
            this.chbtnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbtnStartStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbtnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbtnStartStop.FlatAppearance.BorderSize = 2;
            this.chbtnStartStop.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chbtnStartStop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbtnStartStop.ForeColor = System.Drawing.Color.SeaGreen;
            this.chbtnStartStop.Location = new System.Drawing.Point(638, 734);
            this.chbtnStartStop.Name = "chbtnStartStop";
            this.chbtnStartStop.Size = new System.Drawing.Size(74, 24);
            this.chbtnStartStop.TabIndex = 4;
            this.chbtnStartStop.Text = "&START";
            this.chbtnStartStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbtnStartStop.UseVisualStyleBackColor = true;
            this.chbtnStartStop.CheckedChanged += new System.EventHandler(this.chbtnStartStop_CheckedChanged);
            // 
            // lblFoxLoc
            // 
            this.lblFoxLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFoxLoc.AutoEllipsis = true;
            this.lblFoxLoc.AutoSize = true;
            this.lblFoxLoc.ForeColor = System.Drawing.Color.Maroon;
            this.lblFoxLoc.Location = new System.Drawing.Point(81, 745);
            this.lblFoxLoc.Name = "lblFoxLoc";
            this.lblFoxLoc.Size = new System.Drawing.Size(34, 13);
            this.lblFoxLoc.TabIndex = 2;
            this.lblFoxLoc.Text = "xyFox";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(4, 9);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(308, 16);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "Time elapsed since the beginning (micro second): ";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTime.Location = new System.Drawing.Point(318, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(15, 16);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "0";
            // 
            // timerTickCount
            // 
            this.timerTickCount.Interval = 50;
            this.timerTickCount.Tick += new System.EventHandler(this.timerTickCount_Tick);
            // 
            // trkRenderSpeed
            // 
            this.trkRenderSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trkRenderSpeed.LargeChange = 50;
            this.trkRenderSpeed.Location = new System.Drawing.Point(404, 734);
            this.trkRenderSpeed.Maximum = 500;
            this.trkRenderSpeed.Minimum = 1;
            this.trkRenderSpeed.Name = "trkRenderSpeed";
            this.trkRenderSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trkRenderSpeed.Size = new System.Drawing.Size(228, 45);
            this.trkRenderSpeed.SmallChange = 20;
            this.trkRenderSpeed.TabIndex = 6;
            this.trkRenderSpeed.TickFrequency = 20;
            this.trkRenderSpeed.Value = 80;
            this.trkRenderSpeed.Scroll += new System.EventHandler(this.trkRenderSpeed_Scroll);
            // 
            // lblClientSize
            // 
            this.lblClientSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientSize.AutoSize = true;
            this.lblClientSize.ForeColor = System.Drawing.Color.Blue;
            this.lblClientSize.Location = new System.Drawing.Point(550, 9);
            this.lblClientSize.Name = "lblClientSize";
            this.lblClientSize.Size = new System.Drawing.Size(111, 13);
            this.lblClientSize.TabIndex = 7;
            this.lblClientSize.Text = "Client Size of Screen: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 762);
            this.Controls.Add(this.lblClientSize);
            this.Controls.Add(this.trkRenderSpeed);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.chbtnStartStop);
            this.Controls.Add(this.chbtnShowMenu);
            this.Controls.Add(this.lblFoxLoc);
            this.Controls.Add(this.lblRabbitLoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Fox);
            this.Controls.Add(this.Rabbit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fox Rabbit";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Rabbit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkRenderSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Rabbit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRabbitLoc;
        private System.Windows.Forms.CheckBox chbtnShowMenu;
        private System.Windows.Forms.CheckBox chbtnStartStop;
        private System.Windows.Forms.Label lblFoxLoc;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timerTickCount;
        private System.Windows.Forms.TrackBar trkRenderSpeed;
        private System.Windows.Forms.PictureBox Fox;
        private System.Windows.Forms.Label lblClientSize;

    }
}

