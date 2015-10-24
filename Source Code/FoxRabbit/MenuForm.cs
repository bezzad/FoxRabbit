using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FoxRabbit
{
    public partial class MenuForm : Form
    {
        public PictureBox picFox;
        public PictureBox picRabbit;
        private ShowGraphsForm SHF;
        private AboutForm AF;
        public CheckBox chkSelf;

        public MenuForm()
        {
            InitializeComponent();
        }

        #region ------------------------- Move Form by Mouse --------------------
        private Point MouseLocBuffer;
        private bool keepMouseKeyDown = false;
        private void MenuForm_MouseDown(object sender, MouseEventArgs e)
        {
            keepMouseKeyDown = true;
            MouseLocBuffer = e.Location;
        }
        private void MenuForm_MouseUp(object sender, MouseEventArgs e)
        {
            keepMouseKeyDown = false;
        }
        private void MenuForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (keepMouseKeyDown)
            {
                this.Location = new Point(this.Location.X + (e.X - MouseLocBuffer.X), this.Location.Y + (e.Y - MouseLocBuffer.Y));
            }
        }
        #endregion

        private void btnRandomLoc_Click(object sender, EventArgs e)
        {
            RandomLoc((FuzzyLogic.Distance(new Point(100, 100), new Point(FuzzyLogic.Width, FuzzyLogic.Height)) - 100) / 2);
        }

        /// <summary>
        /// create random position for Fox and Rabbit
        /// </summary>
        /// <param name="distance">distance between Fox and Rabbit</param>
        public void RandomLoc(float distance)
        {
            Random rand = new Random();
            //
            // create random position between 100, 700 for rabbit
            do
            {
                picRabbit.Location = new Point(rand.Next(100, Math.Abs(FuzzyLogic.Width - 100)),
                                               rand.Next(100, Math.Abs(FuzzyLogic.Height - 100)));
            }
            while (FuzzyLogic.Distance(picRabbit.Location, new Point(picRabbit.Location.X, FuzzyLogic.Width - 100)) < distance &&
                  FuzzyLogic.Distance(picRabbit.Location, new Point(FuzzyLogic.Height - 100, picRabbit.Location.Y)) < distance);
            //
            // create random position between 100, 700 for rabbit
            // but must be have distance more than "distance" float's
            do
            {
                picFox.Location = new Point(rand.Next(100, Math.Abs(FuzzyLogic.Width - 100)),
                                            rand.Next(100, Math.Abs(FuzzyLogic.Height - 100)));
            }
            while (FuzzyLogic.Distance(picFox.Location, picRabbit.Location) < distance);
        }

        public void Display(Point originalFormLocation, Size originalFormSize)
        {
            setCenteralLoc(originalFormLocation, originalFormSize);
            this.Show();
        }

        private void btnShowGraphs_Click(object sender, EventArgs e)
        {
            if (SHF == null || SHF.IsDisposed)
            {
                SHF = new ShowGraphsForm();
                SHF.Show();
            }
            else
            {
                SHF.BringToFront();
            }
            chkSelf.Checked = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (AF == null || AF.IsDisposed)
            {
                AF = new AboutForm();
                AF.Show();
            }
            else
            {
                AF.BringToFront();
            }
            chkSelf.Checked = false;
        }

        public void setCenteralLoc(Point originalFormLocation, Size originalFormSize)
        {
            this.Location = new Point((originalFormSize.Width / 2) - (this.Size.Width / 2) + originalFormLocation.X,
                                      (originalFormSize.Height / 2) - (this.Size.Height / 2) + originalFormLocation.Y);
        }
    }
}
