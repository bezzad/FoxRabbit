using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace FoxRabbit
{
    public partial class ShowGraphsForm : Form
    {
        GraphPane myPane;
        FuzzyLogic fuzzy;

        public ShowGraphsForm()
        {
            InitializeComponent();
            txtAverage0.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtAverage0.Leave += new EventHandler(txtAveVar_Leave);
            txtAverage1.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtAverage1.Leave += new EventHandler(txtAveVar_Leave);
            txtAverage2.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtAverage2.Leave += new EventHandler(txtAveVar_Leave);
            txtAverage3.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtAverage3.Leave += new EventHandler(txtAveVar_Leave);
            txtAverage4.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtAverage4.Leave += new EventHandler(txtAveVar_Leave);

            txtVariance0.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtVariance0.Leave += new EventHandler(txtAveVar_Leave);
            txtVariance1.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtVariance1.Leave += new EventHandler(txtAveVar_Leave);
            txtVariance2.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtVariance2.Leave += new EventHandler(txtAveVar_Leave);
            txtVariance3.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtVariance3.Leave += new EventHandler(txtAveVar_Leave);
            txtVariance4.KeyDown += new KeyEventHandler(txtAveVar_KeyDown);
            txtVariance4.Leave += new EventHandler(txtAveVar_Leave);
            //
            //
            myPane = zgc.GraphPane;
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            //
            // fill by default values
            //
            fuzzy = new FuzzyLogic();
        }

        void txtAveVar_Leave(object sender, EventArgs e)
        {
            //SendKeys.Send("{Tab}");
            txtAveVar_ChangeValue(sender);
        }

        void txtAveVar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAveVar_ChangeValue(sender);
            }
        }

        void txtAveVar_ChangeValue(object sender)
        {
            double txtDouble;
            string name = ((LabelTextBox)sender).Name;
            if (double.TryParse(((LabelTextBox)sender).Text, out txtDouble))
            {
                // txtAverage
                if (name.StartsWith("txtAverage"))
                {
                    int index = int.Parse(name.Substring(name.Length - 1));
                    switch (cmbCoordinateName.SelectedItem.ToString())
                    {
                        case "DX (Distance of the fox from rabbit on X axis) Input data":
                            {
                                FuzzyLogic.gaussianData_DX[index, 0] = txtDouble;
                            } break;
                        case "DY (Distance of the fox from rabbit on Y axis) Input data":
                            {
                                FuzzyLogic.gaussianData_DY[index, 0] = txtDouble;
                            } break;
                        case "DXF (Amount of the fox displacement distances on the X axis)":
                            {
                                FuzzyLogic.gaussianData_DXF[index, 0] = txtDouble;
                            } break;
                        case "DYF (Amount of the fox displacement distances on the Y axis)":
                            {
                                FuzzyLogic.gaussianData_DYF[index, 0] = txtDouble;
                            } break;
                    }
                    ((LabelTextBox)sender).LabelText = "میانگین:  " + txtDouble.ToString();
                    ((LabelTextBox)sender).clearByLabelText();
                    CreateGraph(zgc);
                }
                // txtVariance
                else if (name.StartsWith("txtVariance"))
                {
                    int index = int.Parse(name.Substring(name.Length - 1));
                    switch (cmbCoordinateName.SelectedItem.ToString())
                    {
                        case "DX (Distance of the fox from rabbit on X axis) Input data":
                            {
                                FuzzyLogic.gaussianData_DX[index, 1] = txtDouble;
                            } break;
                        case "DY (Distance of the fox from rabbit on Y axis) Input data":
                            {
                                FuzzyLogic.gaussianData_DY[index, 1] = txtDouble;
                            } break;
                        case "DXF (Amount of the fox displacement distances on the X axis)":
                            {
                                FuzzyLogic.gaussianData_DXF[index, 1] = txtDouble;
                            } break;
                        case "DYF (Amount of the fox displacement distances on the Y axis)":
                            {
                                FuzzyLogic.gaussianData_DYF[index, 1] = txtDouble;
                            } break;
                    }
                    ((LabelTextBox)sender).LabelText = "واریانس:  " + txtDouble.ToString();
                    ((LabelTextBox)sender).clearByLabelText();
                    CreateGraph(zgc);
                }
            }
            else
            {
                ((LabelTextBox)sender).Text = ((LabelTextBox)sender).LabelText;
                ((LabelTextBox)sender).ForeColor = ((LabelTextBox)sender).LabelColor;
            }
        }

        private void ShowGraphsForm_Load(object sender, EventArgs e)
        {
            drawBySelectedItem(zgc, cmbCoordinateName.SelectedItem.ToString());      
        }
        
        private void CreateGraph(ZedGraphControl zgc)
        {
            //
            // clear old coordinates
            //
            myPane.CurveList.Clear();
            zgc.AxisChange();
            //
            // Make up some data points from the Sine function
            PointPairList[] list = new PointPairList[5];
            int minValue = 0, maxValue = 0;
            //
            // set data according by selectedIndex
            //
            switch (cmbCoordinateName.SelectedIndex)
            {
                case 0: // DX (Distance of the fox from rabbit on X axis) Input data
                    {
                        // size of screen                                   0           800
                        minValue = -FuzzyLogic.Width; // Rabbit is very Right than Fox (F-----------R) DX = xFox-xRabbit = -800
                        maxValue = FuzzyLogic.Width; // Rabbit is very Left than Fox   (R-----------F) DX = xFox-xRabbit = +800
                    } break;
                case 1: // DY (Distance of the fox from rabbit on Y axis) Input data
                    {
                        // size of screen                                   0           800
                        minValue = -FuzzyLogic.Height; // Rabbit is very Up than Fox (F-----------R) DY = xFox-xRabbit = -800
                        maxValue = FuzzyLogic.Height; // Rabbit is very Down than Fox   (R-----------F) DY = xFox-xRabbit = +800
                    } break;
                case 2: // DXF (Amount of the fox displacement distances on the X axis)
                case 3: // DYF (Amount of the fox displacement distances on the Y axis)
                    {
                        // Amount of the fox displacement distances
                        minValue = -FuzzyLogic.maxStepSpeed; // (F-----------R)
                        //                        -30
                        //
                        maxValue = FuzzyLogic.maxStepSpeed; // (R-----------F)
                        //                       +30
                    } break;
            }
            //
            // set double GaussianArray according by selectedIndex
            //
            double[,] gaussianBuffer = new double[5, 2];
            switch (cmbCoordinateName.SelectedIndex)
            {
                case 0: gaussianBuffer = FuzzyLogic.gaussianData_DX;
                    break;
                case 1: gaussianBuffer = FuzzyLogic.gaussianData_DY;
                    break;
                case 2: gaussianBuffer = FuzzyLogic.gaussianData_DXF;
                    break;
                case 3: gaussianBuffer = FuzzyLogic.gaussianData_DYF;
                    break;
            }
            //
            for (int i = 0; i < 5; i++) // 5 type for gaussian Coordinate in one plot
            {
                list[i] = new PointPairList();
                for (double x = minValue; x <= maxValue; x++)
                {
                    double y = FuzzyLogic.Gaussian(x, gaussianBuffer[i, 0], gaussianBuffer[i, 1]);
                    list[i].Add(x, y);
                }
            }
            

            // Generate a blue curve with circle symbols, and "My Curve" in the legend
            LineItem Curve0 = myPane.AddCurve(grb0.Text, list[0], grb0.ForeColor, SymbolType.Circle);
            LineItem Curve1 = myPane.AddCurve(grb1.Text, list[1], grb1.ForeColor, SymbolType.Circle);
            LineItem Curve2 = myPane.AddCurve(grb2.Text, list[2], grb2.ForeColor, SymbolType.Circle);
            LineItem Curve3 = myPane.AddCurve(grb3.Text, list[3], grb3.ForeColor, SymbolType.Circle);
            LineItem Curve4 = myPane.AddCurve(grb4.Text, list[4], grb4.ForeColor, SymbolType.Circle);

            float allPointSize = 50F;
            // Fill the area under the curve with a white-red gradient at 45 degrees
            Curve0.Line.Fill = new Fill(Color.Transparent, grb0.ForeColor, allPointSize);
            // Make the symbols opaque by filling them with white
            Curve0.Symbol.Fill = new Fill(Color.Transparent);

            // Fill the area under the curve with a white-red gradient at 45 degrees
            Curve1.Line.Fill = new Fill(Color.Transparent, grb1.ForeColor, allPointSize);
            // Make the symbols opaque by filling them with white
            Curve1.Symbol.Fill = new Fill(Color.Transparent);

            // Fill the area under the curve with a white-red gradient at 45 degrees
            Curve2.Line.Fill = new Fill(Color.Transparent, grb2.ForeColor, allPointSize);
            // Make the symbols opaque by filling them with white
            Curve2.Symbol.Fill = new Fill(Color.Transparent);

            // Fill the area under the curve with a white-red gradient at 45 degrees
            Curve3.Line.Fill = new Fill(Color.Transparent, grb3.ForeColor, allPointSize);
            // Make the symbols opaque by filling them with white
            Curve3.Symbol.Fill = new Fill(Color.Transparent);

            // Fill the area under the curve with a white-red gradient at 45 degrees
            Curve4.Line.Fill = new Fill(Color.Transparent, grb4.ForeColor, allPointSize);
            // Make the symbols opaque by filling them with white
            Curve4.Symbol.Fill = new Fill(Color.Transparent);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zgc.Refresh();
        }

        private void cmbCoordinateName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void drawBySelectedItem(ZedGraphControl zGraphControl, string selectedItem)
        {
            switch (selectedItem)
            {
                case "DX (Distance of the fox from rabbit on X axis) Input data":
                    {
                        //
                        // set groupBox text and LabelTextBox LabelTexts
                        //
                        grb0.Text = "Very Right";
                        grb1.Text = "Right";
                        grb2.Text = "Equal";
                        grb3.Text = "Left";
                        grb4.Text = "Very Left";
                        txtAverage0.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DX[0, 0].ToString();
                        txtAverage1.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DX[1, 0].ToString();
                        txtAverage2.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DX[2, 0].ToString();
                        txtAverage3.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DX[3, 0].ToString();
                        txtAverage4.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DX[4, 0].ToString();
                        txtVariance0.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DX[0, 1].ToString();
                        txtVariance1.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DX[1, 1].ToString();
                        txtVariance2.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DX[2, 1].ToString();
                        txtVariance3.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DX[3, 1].ToString();
                        txtVariance4.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DX[4, 1].ToString();
                        // Set the titles and axis labels
                        myPane.Title.Text = "Input DX Fuzzy Collections";
                        myPane.XAxis.Title.Text = "DX (Distance of the fox from rabbit on X axis)";
                        myPane.YAxis.Title.Text = "Fuzzy Value";
                        CreateGraph(zGraphControl);
                    } break;
                case "DY (Distance of the fox from rabbit on Y axis) Input data":
                    {
                        //
                        // set groupBox text and LabelTextBox LabelTexts
                        //
                        grb0.Text = "Very Up";
                        grb1.Text = "Up";
                        grb2.Text = "Equal";
                        grb3.Text = "Down";
                        grb4.Text = "Very Down";
                        txtAverage0.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DY[0, 0].ToString();
                        txtAverage1.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DY[1, 0].ToString();
                        txtAverage2.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DY[2, 0].ToString();
                        txtAverage3.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DY[3, 0].ToString();
                        txtAverage4.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DY[4, 0].ToString();
                        txtVariance0.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DY[0, 1].ToString();
                        txtVariance1.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DY[1, 1].ToString();
                        txtVariance2.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DY[2, 1].ToString();
                        txtVariance3.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DY[3, 1].ToString();
                        txtVariance4.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DY[4, 1].ToString();
                        // Set the titles and axis labels
                        myPane.Title.Text = "Input DY Fuzzy Collections";
                        myPane.XAxis.Title.Text = "DY (Distance of the fox from rabbit on Y axis)";
                        myPane.YAxis.Title.Text = "Fuzzy Value";
                        CreateGraph(zGraphControl);
                    } break;
                case "DXF (Amount of the fox displacement distances on the X axis)":
                    {
                        //
                        // set groupBox text and LabelTextBox LabelTexts
                        //
                        grb0.Text = "Hight Right";
                        grb1.Text = "Low Right";
                        grb2.Text = "Equal";
                        grb3.Text = "Low Left";
                        grb4.Text = "Hight Left";
                        txtAverage0.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DXF[0, 0].ToString();
                        txtAverage1.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DXF[1, 0].ToString();
                        txtAverage2.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DXF[2, 0].ToString();
                        txtAverage3.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DXF[3, 0].ToString();
                        txtAverage4.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DXF[4, 0].ToString();
                        txtVariance0.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DXF[0, 1].ToString();
                        txtVariance1.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DXF[1, 1].ToString();
                        txtVariance2.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DXF[2, 1].ToString();
                        txtVariance3.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DXF[3, 1].ToString();
                        txtVariance4.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DXF[4, 1].ToString();
                        // Set the titles and axis labels
                        myPane.Title.Text = "Output DXF Fuzzy Collections";
                        myPane.XAxis.Title.Text = "DXF (Amount of the fox displacement distances on the X axis)";
                        myPane.YAxis.Title.Text = "Fuzzy Value";
                        CreateGraph(zGraphControl);
                    } break;
                case "DYF (Amount of the fox displacement distances on the Y axis)":
                    {
                        //
                        // set groupBox text and LabelTextBox LabelTexts
                        //
                        grb0.Text = "Hight Up";
                        grb1.Text = "Low Up";
                        grb2.Text = "Equal";
                        grb3.Text = "Low Down";
                        grb4.Text = "Hight Down";
                        txtAverage0.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DYF[0, 0].ToString();
                        txtAverage1.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DYF[1, 0].ToString();
                        txtAverage2.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DYF[2, 0].ToString();
                        txtAverage3.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DYF[3, 0].ToString();
                        txtAverage4.LabelText = "میانگین:  " + FuzzyLogic.gaussianData_DYF[4, 0].ToString();
                        txtVariance0.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DYF[0, 1].ToString();
                        txtVariance1.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DYF[1, 1].ToString();
                        txtVariance2.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DYF[2, 1].ToString();
                        txtVariance3.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DYF[3, 1].ToString();
                        txtVariance4.LabelText = "واریانس:  " + FuzzyLogic.gaussianData_DYF[4, 1].ToString();
                        // Set the titles and axis labels
                        myPane.Title.Text = "Output DYF Fuzzy Collections";
                        myPane.XAxis.Title.Text = "DYF (Amount of the fox displacement distances on the Y axis)";
                        myPane.YAxis.Title.Text = "Fuzzy Value";
                        CreateGraph(zGraphControl);
                    } break;
            }
        }

        private void cmbCoordinateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawBySelectedItem(zgc, cmbCoordinateName.SelectedItem.ToString());
        }
    }
}
