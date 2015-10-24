using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FoxRabbit
{
    public partial class MainForm : Form
    {
        private MenuForm menu;
        private Thread thFuzzyLogic;
        private int Time = 0;
        private Random rand = new Random();
        private int renderSleep = 150;
        private FuzzyLogic fuzzy;

        public MainForm()
        {
            InitializeComponent();
            fuzzy = new FuzzyLogic();
            fuzzy.setRectangleSize(this.ClientSize.Width, this.ClientSize.Height);
            lblClientSize.Text = "Client Size of Screen: " + this.ClientSize.ToString();
            oldLocation = this.Location;
            this.trkRenderSpeed.Value = renderSleep;
            menu = new MenuForm();
            menu.chkSelf = chbtnShowMenu;
            menu.picFox = this.Fox;
            menu.picRabbit = this.Rabbit;
            menu.RandomLoc((FuzzyLogic.Distance(new Point(100, 100), new Point(FuzzyLogic.Width, FuzzyLogic.Height)) - 100) / 2);
            thFuzzyLogic = new Thread(new ThreadStart(Fuzzy));
        }

        #region Graphic Codes

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the Location property on a UserControl object's.
        /// </summary>
        /// <param name="obj">The UserControl object's</param>
        /// <param name="newLocation">Move object to this location</param>
        delegate void SetLocationCallback(PictureBox obj, Point newLocation);
        /// <summary>
        /// This method demonstrates a pattern for making thread-safe
        /// calls on a Windows Forms control. 
        ///
        /// If the calling thread is different from the thread that
        /// created the UserControl object's, this method creates a
        /// SetLocationCallback and calls itself asynchronously using the
        /// Invoke method.
        ///
        /// If the calling thread is the same as the thread that created
        /// the UserControl object's, the Location property is set directly. 
        /// </summary>
        /// <param name="obj">The UserControl object's</param>
        /// <param name="newLocation">Move object to this location</param>
        public void show(PictureBox obj, Point newLocation)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {
                #region Set Location in Safely
                if (obj.InvokeRequired)
                {
                    SetLocationCallback d = new SetLocationCallback(show);
                    obj.Invoke(d, new object[] { obj, newLocation });
                }
                else
                {
                    // if: 
                    //    original location = newLocation = (50, 50)
                    //    obj.Size = (70, 70)
                    // ----------------------------
                    // Virtual location in form
                    // (15,15)._______
                    //        |(50,50)| 
                    //      70|   .---|---. Original location in form
                    //        |   |   |   | 
                    //        |___|___|   |
                    //            |       |
                    //            ._______.
                    //        <--->
                    //          35
                    // 
                    // create virtual location from original location:
                    obj.Location = new Point(newLocation.X - (obj.Size.Width / 2),
                                             newLocation.Y - (obj.Size.Height / 2));
                }
                #endregion
            }
            catch { }
        }

        /// <summary>
        /// Show/Hide The Menu Form's
        /// </summary>
        /// <param name="sender">checkBox object's</param>
        /// <param name="e">Event Argument's</param>
        private void chbtnShowMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (chbtnShowMenu.Checked) menu.Display(this.Location, this.Size);
            else menu.Hide();
        }

        /// <summary>
        /// Start/Stop The Fuzzy Logic Algorithm's
        /// </summary>
        /// <param name="sender">checkBox object's</param>
        /// <param name="e">Event Argument's</param>
        private void chbtnStartStop_CheckedChanged(object sender, EventArgs e)
        {
            if (chbtnStartStop.Checked)
            {
                chbtnStartStop.Text = "&STOP";
                chbtnStartStop.ForeColor = Color.Crimson;
                Time = Environment.TickCount;
                timerTickCount.Start();
                thFuzzyLogic = new Thread(new ThreadStart(Fuzzy));
                thFuzzyLogic.Start();
            }
            else
            {
                chbtnStartStop.Text = "&START";
                chbtnStartStop.ForeColor = Color.SeaGreen;
                timerTickCount.Stop();
                thFuzzyLogic.Abort();
            }
        }

        private void Fox_LocationChanged(object sender, EventArgs e)
        {
            // if: 
            //    obj.Size = (70, 70)
            // ----------------------------
            // Original location in form
            // (15,15)._______
            //        |(50,50)| 
            //      70|   .---|---. Virtual location in form
            //        |   |   |   | 
            //        |___|___|   |
            //            |       |
            //            ._______.
            //        <--->
            //         35=(width/2)
            // 
            // Show virtual location:
            lblFoxLoc.Text = string.Format("X({0}) , Y({1})",
                                           Fox.Location.X + (Fox.Size.Width / 2),
                                           Fox.Location.Y + (Fox.Size.Height / 2));
        }
        private void Rabbit_LocationChanged(object sender, EventArgs e)
        {
            // if: 
            //    obj.Size = (70, 70)
            // ----------------------------
            // Original location in form
            // (15,15)._______
            //        |(50,50)| 
            //      70|   .---|---. Virtual location in form
            //        |   |   |   | 
            //        |___|___|   |
            //            |       |
            //            ._______.
            //        <--->
            //         35=(width/2)
            // 
            // Show virtual location:
            lblRabbitLoc.Text = string.Format("X({0}) , Y({1})",
                                              Rabbit.Location.X + (Rabbit.Size.Width / 2),
                                              Rabbit.Location.Y + (Rabbit.Size.Height / 2));
        }

        #region ------------------------- Move Fox or Rabbits by Mouse --------------------
        private Point MouseLocBuffer;
        private bool keepMouseKeyDown = false;

        private void Fox_MouseDown(object sender, MouseEventArgs e)
        {
            keepMouseKeyDown = true;
            MouseLocBuffer = e.Location;
        }

        private void Fox_MouseMove(object sender, MouseEventArgs e)
        {
            if (keepMouseKeyDown && e.Button == MouseButtons.Left)
            {
                Fox.Location = new Point(Fox.Location.X + (e.X - MouseLocBuffer.X), Fox.Location.Y + (e.Y - MouseLocBuffer.Y));
            }
        }

        private void Fox_MouseUp(object sender, MouseEventArgs e)
        {
            keepMouseKeyDown = false;
        }
        //
        // ------------------------- Move Form by Mouse --------------------
        private void Rabbit_MouseDown(object sender, MouseEventArgs e)
        {
            keepMouseKeyDown = true;
            MouseLocBuffer = e.Location;
        }

        private void Rabbit_MouseMove(object sender, MouseEventArgs e)
        {
            if (keepMouseKeyDown && e.Button == MouseButtons.Left)
            {
                Rabbit.Location = new Point(Rabbit.Location.X + (e.X - MouseLocBuffer.X), Rabbit.Location.Y + (e.Y - MouseLocBuffer.Y));
            }
        }

        private void Rabbit_MouseUp(object sender, MouseEventArgs e)
        {
            keepMouseKeyDown = false;
        }
        #endregion

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            lblFoxLoc.Location = new Point(81, this.Size.Height - 55);
            lblRabbitLoc.Location = new Point(285, this.Size.Height - 55);
            if (fuzzy != null)
                fuzzy.setRectangleSize(this.ClientSize.Width, this.ClientSize.Height);
            lblClientSize.Text = "Client Size of Screen: " + this.ClientSize.ToString();
            if (chbtnShowMenu.Checked && menu != null)
            {
                menu.setCenteralLoc(this.Location, this.Size);
            }
        }

        private Point oldLocation;
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Location = new Point(menu.Location.X + (this.Location.X - oldLocation.X),
                                          menu.Location.Y + (this.Location.Y - oldLocation.Y));
                oldLocation = this.Location;
            }
        }

        /// <summary>
        /// give the location of shape and find center of its.
        /// </summary>
        /// <param name="shapeSize">shape size</param>
        /// <param name="shapLocation">shape location</param>
        /// <returns>shape center locate</returns>
        private Point shapCentral(Size shapeSize, Point shapLocation)
        {
            // if: 
            //    shapeLocation = (15, 15)
            //    Size = (70, 70)
            // ----------------------------
            // shape location in form
            // (15,15)._______
            //        |(50,50)| 
            //      70|   .---|---. Virtual location in form
            //        |   |   |   | 
            //        |___|___|   |
            //            |       |
            //            ._______.
            //        <--->
            //          35
            // 
            // create virtual location from shape location:
            return new Point(shapLocation.X + (shapeSize.Width / 2),
                             shapLocation.Y + (shapeSize.Height / 2));
        }

        private void timerTickCount_Tick(object sender, EventArgs e)
        {
            lblTime.Text = (Environment.TickCount - Time).ToString();
        }

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the checked property on a checkBox object's.
        /// </summary>
        /// <param name="chBox">The checkBox object's</param>
        /// <param name="ch">bool checked</param>
        delegate void SetCheckedCallback(CheckBox chBox, bool ch);
        private void check(CheckBox chBox, bool ch)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {
                #region Set checked in Safely
                if (chBox.InvokeRequired)
                {
                    SetCheckedCallback d = new SetCheckedCallback(check);
                    chBox.Invoke(d, new object[] { chBox, ch });
                }
                else
                {
                    chBox.Checked = ch;
                }
                #endregion
            }
            catch { }
        }

        private void trkRenderSpeed_Scroll(object sender, EventArgs e)
        {
            renderSleep = trkRenderSpeed.Value;
        }
        #endregion

        /// <summary>
        /// Fuzzy Logic Algorithm for 
        /// Chase and catch rabbits by foxes
        /// </summary>
        private void Fuzzy()
        {
            fuzzy = new FuzzyLogic();
            double DXF; // Fox displacement distance for the X axis
            double DYF; // Fox displacement distance for the Y axis
            double DXR; // Rabbit displacement distance for the X axis
            double DYR; // Rabbit displacement distance for the Y axis
            Point pFox; // Location central of Fox
            Point pRabbit; // Location central of Rabbit
            //
            // Keep the commands until the distance of the fox rabbit is more than 35
            //
            while (FuzzyLogic.Distance(shapCentral(Fox.Size, Fox.Location),
                    shapCentral(Rabbit.Size, Rabbit.Location)) > 35)
            {
                pFox = shapCentral(Fox.Size, Fox.Location);
                pRabbit = shapCentral(Rabbit.Size, Rabbit.Location);
                //
                // Move Rabbit Code 
                //
                moveRabbit(pRabbit.X, pRabbit.Y, pFox.X, pFox.Y, out DXR, out DYR);
                pRabbit.X += (int)DXR;
                pRabbit.Y += (int)DYR;
                show(Rabbit, pRabbit);
                //
                // Move Fox Code
                // 
                moveFox(pRabbit.X, pRabbit.Y, pFox.X, pFox.Y, out DXF, out DYF);
                pFox.X += (int)DXF;
                pFox.Y += (int)DYF;
                show(Fox, pFox);
                //
                // this thread waited a few milliseconds.
                // 
                Thread.CurrentThread.Join(renderSleep);
            }
            //
            #region End of Find Rabbits
            timerTickCount.Stop();
            MessageBox.Show(string.Format("Fox successful to get a rabbit to be within {0} seconds.",
                (Environment.TickCount - Time) / 1000), "Fox brings rabbit to grab",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            check(chbtnStartStop, false);
            #endregion
        }

        /// <summary>
        /// Fuzzy Logic Controller  for Rabbit Moves.
        /// </summary>
        /// <param name="xR">Rabbit location in x-coordinate axis</param>
        /// <param name="yR">Rabbit location in y-coordinate axis</param>
        /// <param name="xF">Fox location in x-coordinate axis</param>
        /// <param name="yF">Fox location in y-coordinate axis</param>
        /// <param name="DXR">Rabbit displacement distance for the X axis</param>
        /// <param name="DYR">Rabbit displacement distance for the Y axis</param>
        private void moveRabbit(int xR, int yR, int xF, int yF, out double DXR, out double DYR)
        {
            DXR = DYR = 0;
            int padding = 100;
            int minSpeed = 5;
            int maxSpeed = 20;
            // 
            // Fox is right of Rabbit.
            if (xF > xR)
            {
                //
                // Rabbit is upper than Fox.
                if (yF > yR)
                {
                    //  ----> X+
                    // | .________________.
                    // | |                |
                    // | |  .Rabbit       |
                    // Y |                |
                    // + |                |
                    //   |                |   
                    //   |          .Fox  |
                    //   |                |   
                    //   |________________|
                    //
                    // Set X Axis
                    if (xR <= padding) // rabbit is very left
                    {
                        DXR = rand.Next(minSpeed, maxSpeed); // go right
                    }
                    else 
                    {
                        DXR = rand.Next(-maxSpeed, -minSpeed); // go left (Because away from the fox)
                    }
                    //
                    // Set Y Axis
                    if (yR <= padding) // rabbit is very up
                    {
                        DYR = rand.Next(minSpeed, maxSpeed); // go down
                    }
                    else
                    {
                        DYR = rand.Next(-maxSpeed, -minSpeed); // go up (Because away from the fox)
                    }
                }
                else // Fox is upper than Rabbit
                {
                    //  ----> X+
                    // | .________________.
                    // | |                |
                    // | |         .Fox   |
                    // Y |                |
                    // + |                |
                    //   |                |   
                    //   |                |
                    //   |  .Rabbit       |   
                    //   |________________|
                    //
                    // Set X Axis
                    if (xR <= padding) // rabbit is very left
                    {
                        DXR = rand.Next(minSpeed, maxSpeed); // go right
                    }
                    else
                    {
                        DXR = rand.Next(-maxSpeed, -minSpeed); // go left (Because away from the fox)
                    }
                    //
                    // Set Y Axis
                    if (yR >= FuzzyLogic.Height - padding) // rabbit is very down
                    {
                        DYR = rand.Next(-maxSpeed, -minSpeed); // go up
                    }
                    else
                    {
                        DYR = rand.Next(minSpeed, maxSpeed); // go down (Because away from the fox)
                    }
                }
            }
            else // Fox is left of Rabbit.
            {
                //
                // Rabbit is upper than Fox.
                if (yF > yR)
                {
                    //  ----> X+
                    // | .________________.
                    // | |                |
                    // | |        .Rabbit |
                    // Y |                |
                    // + |                |
                    //   |                |   
                    //   | .Fox           |
                    //   |                |   
                    //   |________________|
                    //
                    // Set X Axis
                    if (xR >= FuzzyLogic.Width - padding) // rabbit is very right
                    {
                        DXR = rand.Next(-maxSpeed, -minSpeed); // go left
                    }
                    else
                    {
                        DXR = rand.Next(minSpeed, maxSpeed); // go right (Because away from the fox)
                    }
                    //
                    // Set Y Axis
                    if (yR <= padding) // rabbit is very up
                    {
                        DYR = rand.Next(minSpeed, maxSpeed); // go down
                    }
                    else
                    {
                        DYR = rand.Next(-maxSpeed, -minSpeed); // go up (Because away from the fox)
                    }
                }
                else // Fox is upper than Rabbit
                {
                    //  ----> X+
                    // | .________________.
                    // | |                |
                    // | | .Fox           |
                    // Y |                |
                    // + |                |
                    //   |                |   
                    //   |        .Rabbit |
                    //   |                |   
                    //   |________________|
                    //
                    //
                    // Set X Axis
                    if (xR >= FuzzyLogic.Width - padding) // rabbit is very right
                    {
                        DXR = rand.Next(-maxSpeed, -minSpeed); // go left
                    }
                    else
                    {
                        DXR = rand.Next(minSpeed, maxSpeed); // go right (Because away from the fox)
                    }
                    //
                    // Set Y Axis
                    if (yR >= FuzzyLogic.Height - padding) // rabbit is very down
                    {
                        DYR = rand.Next(-maxSpeed, -minSpeed); // go up
                    }
                    else
                    {
                        DYR = rand.Next(minSpeed, maxSpeed); // go down (Because away from the fox)
                    }
                }
            }
        }
        
        /// <summary>
        /// Fuzzy Logic Controller  for Fox Moves.
        /// </summary>
        /// <param name="xR">Rabbit location in x-coordinate axis</param>
        /// <param name="yR">Rabbit location in y-coordinate axis</param>
        /// <param name="xF">Fox location in x-coordinate axis</param>
        /// <param name="yF">Fox location in y-coordinate axis</param>
        /// <param name="DXF">Fox displacement distance for the X axis</param>
        /// <param name="DYF">Fox displacement distance for the Y axis</param>
        private void moveFox(int xR, int yR, int xF, int yF, out double DXF, out double DYF)
        {
            // Coordinate axis directions in mathematics:
            //         
            //          Y+
            //          ^
            //          |
            //          |
            //          |---------> X+
            //
            //________________________________________________
            // Coordinate axis directions in c# form:
            //         
            //          |----------> X+
            //          |
            //          |
            //          .
            //          Y+
            //  
            //_____________________________________________________________________
            // dx = xR - xF
            // dy = yR - yF (in mathematics coordinate)
            // dy = yF - yR (Because the C# form to the positive Y axis is down.)
            //
            DXF = fuzzy.calculateDXF((xR - xF), (yF - yR));
            DYF = fuzzy.calculateDYF((xR - xF), (yF - yR));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thFuzzyLogic != null)
                if (thFuzzyLogic.IsAlive)
                {
                    thFuzzyLogic.Abort();
                    thFuzzyLogic = null;
                }
        }
    }
}
