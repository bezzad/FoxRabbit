namespace FoxRabbit
{
    partial class MenuForm
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
            this.btnRandomLoc = new System.Windows.Forms.Button();
            this.btnShowGraphs = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRandomLoc
            // 
            this.btnRandomLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRandomLoc.Location = new System.Drawing.Point(184, 12);
            this.btnRandomLoc.Name = "btnRandomLoc";
            this.btnRandomLoc.Size = new System.Drawing.Size(80, 80);
            this.btnRandomLoc.TabIndex = 0;
            this.btnRandomLoc.Text = "&Random Coordinates";
            this.btnRandomLoc.UseVisualStyleBackColor = true;
            this.btnRandomLoc.Click += new System.EventHandler(this.btnRandomLoc_Click);
            // 
            // btnShowGraphs
            // 
            this.btnShowGraphs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowGraphs.Location = new System.Drawing.Point(98, 12);
            this.btnShowGraphs.Name = "btnShowGraphs";
            this.btnShowGraphs.Size = new System.Drawing.Size(80, 80);
            this.btnShowGraphs.TabIndex = 0;
            this.btnShowGraphs.Text = "&Show Graphs";
            this.btnShowGraphs.UseVisualStyleBackColor = true;
            this.btnShowGraphs.Click += new System.EventHandler(this.btnShowGraphs_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.Location = new System.Drawing.Point(12, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(80, 80);
            this.btnAbout.TabIndex = 0;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(276, 104);
            this.ControlBox = false;
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnShowGraphs);
            this.Controls.Add(this.btnRandomLoc);
            this.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MenuForm";
            this.Opacity = 0.8;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuForm_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRandomLoc;
        private System.Windows.Forms.Button btnShowGraphs;
        private System.Windows.Forms.Button btnAbout;
    }
}