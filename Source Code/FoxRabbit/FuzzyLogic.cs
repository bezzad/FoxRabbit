using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FoxRabbit
{
    public class FuzzyLogic
    {
        #region Public Static Properties 

        /// <summary>
        /// To store data (Average, Variance) for 
        /// five graphs showing changes Gaussian input X
        /// </summary>
        public static double[,] gaussianData_DX;

        /// <summary>
        /// To store data (Average, Variance) for 
        /// five graphs showing changes Gaussian input Y
        /// </summary>
        public static double[,] gaussianData_DY;

        /// <summary>
        /// To store data (Average, Variance) for 
        /// five graphs showing changes Gaussian output X
        /// </summary>
        public static double[,] gaussianData_DXF;

        /// <summary>
        /// To store data (Average, Variance) for 
        /// five graphs showing changes Gaussian output Y
        /// </summary>
        public static double[,] gaussianData_DYF;

        /// <summary>
        /// width of client screen size
        /// </summary>
        private static int _width;
        public static int Width
        {
            get { return FuzzyLogic._width; }
        }

        /// <summary>
        /// height of client screen size
        /// </summary>
        private static int _height;
        public static int Height
        {
            get { return FuzzyLogic._height; }
        }

        /// <summary>
        /// maximum moving step size
        /// </summary>
        public static int maxStepSpeed;

        #endregion
        #region Private Local Properties
        /// <summary>
        /// ȳ average matrix for DXF
        /// </summary>
        double[,] yBar_DXF;
 
        /// <summary>
        /// ȳ average matrix for DYF
        /// </summary>
        double[,] yBar_DYF;

        /// <summary>
        /// RuleFire Matrix is equal by (MDY * MDX). use for DXF and DYF
        /// </summary>
        double[,] RuleFire;

        /// <summary>
        /// Membership degree of dX in DX Fuzzy Collections (Matrix 5×1)
        /// </summary>
        double[,] MDX;
        /// <summary>
        /// Membership degree of dY in DY Fuzzy Collections (Matrix 1×5)
        /// </summary>
        double[,] MDY;

        /// <summary>
        /// ProdMatrix = (ȳ .* RuleFire)
        /// </summary>
        double[,] ProdMatrix;
        #endregion

        /// <summary>
        /// set Display Size
        /// </summary>
        /// <param name="width">float number for width of Screen</param>
        /// <param name="height">float number for height of Screen</param>
        public void setRectangleSize(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                _width = width;
                _height = height;
            }
        }

        public FuzzyLogic()
        {
            if (gaussianData_DX == null || gaussianData_DY == null ||
                gaussianData_DXF == null || gaussianData_DYF == null)
            {
                fillGaussianDefaults();
            }
            //
            // Set Matrix or Const data
            //
            yBar_DXF = new double[5, 5];
            yBar_DYF = new double[5, 5];
            RuleFire = new double[5, 5];
            MDX = new double[1, 5];
            MDY = new double[5, 1];
            //
            // Set ȳ average matrix for DXF (Used for DXF Laws Matrix)
            //
            //Default valus:     ____ ____ _____ ____ ____
            //                  |    |    |     |    |    |
            //               VU | HL | LL |  E  | LR | HR |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //                U | HL | LL |  E  | LR | HR |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //                E | HL | LL |  E  | LR | HR |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //                D | HL | LL |  E  | LR | HR |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //               VD | HL | LL |  E  | LR | HR |
            //                  |____|____|_____|____|____|
            //                    VL    L    E    R    VR
            //
            //yBar_DXF = new double[,] {
            //                             {-22, -17, 0, 17, 22},
            //                             {-22, -17, 0, 17, 22},
            //                             {-22, -17, 0, 17, 22},
            //                             {-22, -17, 0, 17, 22},
            //                             {-22, -17, 0, 17, 22}
            //                         };
            //
            //Dynamic values:
            for (int column = 0; column < 5; column++)
                for (int row = 0; row < 5; row++)
                {
                    yBar_DXF[row, column] = gaussianData_DXF[Math.Abs(4 - column), 0];
                }
            
            //
            // Set ȳ average matrix for DYF (Used for DYF Laws Matrix)
            // 
            //Default valus:     ____ ____ _____ ____ ____
            //                  |    |    |     |    |    |
            //               VU | HU | HU | HU  | HU | HU |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //                U | LU | LU | LU  | LU | LU |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //                E |  E |  E |  E  | E  | E  |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //                D | LD | LD | LD  | LD | LD |
            //                  |____|____|_____|____|____|
            //                  |    |    |     |    |    |
            //               VD | HD | HD | HD  | HD | HD |
            //                  |____|____|_____|____|____|
            //                    VL    L    E    R    VR
            //
            //yBar_DYF = new double[,] {
            //                             {-20, -20, -20, -20, -20},
            //                             {-15, -15, -15, -15, -15},
            //                             {0, 0, 0, 0, 0},
            //                             {15, 15, 15, 15, 15},
            //                             {20, 20, 20, 20, 20}
            //                         };
            //
            //Dynamic values:
            for (int row = 0; row < 5; row++)
                for (int column = 0; column < 5; column++)
                {
                    yBar_DYF[row, column] = gaussianData_DYF[Math.Abs(4 - row), 0];
                }
        }

        /// <summary>
        /// set default value for all gaussianData arrays
        /// </summary>
        public void fillGaussianDefaults()
        {
            _width = 800;  // width of display.clientRectangleSize
            _height = 800; // height of display.clientRectangleSize
            maxStepSpeed = 22;
            //
            //
            gaussianData_DX = new double[5, 2];  // 0~4 types and any type have average and variance
            gaussianData_DY = new double[5, 2];  // 0~4 types and any type have average and variance
            gaussianData_DXF = new double[5, 2]; // 0~4 types and any type have average and variance
            gaussianData_DYF = new double[5, 2]; // 0~4 types and any type have average and variance
            //
            // Set DX (Distance of the fox from rabbit on X axis) Input Gaussian data
            //
            gaussianData_DX[0, 0] = 700;  // [Very Right, Average]
            gaussianData_DX[0, 1] = 300;  // [Very Right, Varianc]
            gaussianData_DX[1, 0] = 220;  // [Right, Average]
            gaussianData_DX[1, 1] = 100;  // [Right, Varianc]
            gaussianData_DX[2, 0] = 0;    // [Equal, Average]
            gaussianData_DX[2, 1] = 40;   // [Equal, Varianc]
            gaussianData_DX[3, 0] = -220; // [Left, Average]
            gaussianData_DX[3, 1] = 100;  // [Left, Varianc]
            gaussianData_DX[4, 0] = -700; // [Very Left, Average]
            gaussianData_DX[4, 1] = 300;  // [Very Left, Varianc]
            //
            // Set DY (Distance of the fox from rabbit on Y axis) Input Gaussian data
            //
            gaussianData_DY[0, 0] = 700;  // [Very Up, Average]
            gaussianData_DY[0, 1] = 300;  // [Very Up, Varianc]
            gaussianData_DY[1, 0] = 220;  // [Up, Average]
            gaussianData_DY[1, 1] = 100;  // [Up, Varianc]
            gaussianData_DY[2, 0] = 0;    // [Equal, Average]
            gaussianData_DY[2, 1] = 40;   // [Equal, Varianc]
            gaussianData_DY[3, 0] = -220; // [Down, Average]
            gaussianData_DY[3, 1] = 100;  // [Down, Varianc]
            gaussianData_DY[4, 0] = -700; // [Very Down, Average]
            gaussianData_DY[4, 1] = 300;  // [Very Down, Varianc]
            //
            // Set DXF (Amount of the fox displacement distances on the X axis) Output Gaussian data
            //
            gaussianData_DXF[0, 0] = 22;  // [High Right, Average]
            gaussianData_DXF[0, 1] = 7;   // [High Right, Varianc]
            gaussianData_DXF[1, 0] = 17;  // [Low Right, Average]
            gaussianData_DXF[1, 1] = 4;  // [Low Right, Varianc]
            gaussianData_DXF[2, 0] = 0;   // [Equal, Average]
            gaussianData_DXF[2, 1] = 5;   // [Equal, Varianc]
            gaussianData_DXF[3, 0] = -17; // [Low Left, Average]
            gaussianData_DXF[3, 1] = 4;  // [Low Left, Varianc]
            gaussianData_DXF[4, 0] = -22; // [High Left, Average]
            gaussianData_DXF[4, 1] = 7;   // [High Left, Varianc]
            //
            // Set DYF (Amount of the fox displacement distances on the Y axis) Output Gaussian data
            //
            gaussianData_DYF[0, 0] = 20;  // [High Up, Average]
            gaussianData_DYF[0, 1] = 7;   // [High Up, Varianc]
            gaussianData_DYF[1, 0] = 15;  // [Low Up, Average]
            gaussianData_DYF[1, 1] = 4;  // [Low Up, Varianc]
            gaussianData_DYF[2, 0] = 0;   // [Equal, Average]
            gaussianData_DYF[2, 1] = 5;   // [Equal, Varianc]
            gaussianData_DYF[3, 0] = -15; // [Low Down, Average]
            gaussianData_DYF[3, 1] = 4;  // [Low Down, Varianc]
            gaussianData_DYF[4, 0] = -20; // [High Down, Average]
            gaussianData_DYF[4, 1] = 7;   // [High Down, Varianc]
        }

        /// <summary>
        /// Output of Fuzzy System for Fox amount of 
        /// displacement on the X axis coordinates than the previous.
        /// </summary>
        /// <param name="dX">The relative distance between fox and Rabbit on X axis.</param>
        /// <param name="dY">The relative distance between fox and Rabbit on Y axis</param>
        /// <returns>Amount of displacement on the Y axis</returns>
        public double calculateDXF(float dX, float dY)
        {
            //
            for (int i = 0; i < 5; i++)
            {
                // set MDY by DY gaussians coordinate
                //
                // MDY:  ___
                //      |   |
                //      | 0 | µ(DY)vu
                //      |___| 
                //      |   |
                //      | 1 | µ(DY)u
                //      |___|    
                //      |   |
                //      | 2 | µ(DY)e
                //      |___| 
                //      |   |
                //      | 3 | µ(DY)d
                //      |___|    
                //      |   |
                //      | 4 | µ(DY)vd
                //      |___|    
                //
                MDY[i, 0] = Gaussian(dY, gaussianData_DY[i, 0], gaussianData_DY[i, 1]);
                //
                // set MDY by DY gaussians coordinate
                //
                // MDX:  _____ _____ _____ _____ _____
                //      |     |     |     |     |     |
                //      |  0  |  1  |  2  |  3  |  4  | 
                //      |_____|_____|_____|_____|_____|
                //       µ(DX) µ(DX) µ(DX) µ(DX) µ(DX)
                //        VL    L     E     R     VR
                //
                MDX[0, i] = Gaussian(dX, gaussianData_DX[4 - i, 0], gaussianData_DX[4 - i, 1]);
            }
            //
            // calculate RuleFire Matrix of (MDY * MDX)
            //
            RuleFire = Multiply(MDY, 5, 1, MDX, 1, 5);
            //
            // create Product Multiply between ȳ and RuleFire
            //
            ProdMatrix = Dot(yBar_DXF, 5, 5, RuleFire, 5, 5);
            //
            // calc DXF = sum(ȳ.*RuleFire)/sum(RuleFire)
            //
            return Sum(ProdMatrix, 5, 5) / Sum(RuleFire, 5, 5);
        }

        /// <summary>
        /// Output of Fuzzy System for Fox amount of 
        /// displacement on the Y axis coordinates than the previous.
        /// </summary>
        /// <param name="dX">The relative distance between fox and Rabbit on X axis.</param>
        /// <param name="dY">The relative distance between fox and Rabbit on Y axis</param>
        /// <returns>Amount of displacement on the Y axis</returns>
        public double calculateDYF(float dX, float dY)
        {
            //
            for (int i = 0; i < 5; i++)
            {
                // set MDY by DY gaussians coordinate
                //
                // MDY:  ___
                //      |   |
                //      | 0 | µ(DY)vu
                //      |___| 
                //      |   |
                //      | 1 | µ(DY)u
                //      |___|    
                //      |   |
                //      | 2 | µ(DY)e
                //      |___| 
                //      |   |
                //      | 3 | µ(DY)d
                //      |___|    
                //      |   |
                //      | 4 | µ(DY)vd
                //      |___|    
                //
                MDY[i, 0] = Gaussian(dY, gaussianData_DY[i, 0], gaussianData_DY[i, 1]);
                //
                // set MDY by DY gaussians coordinate
                //
                // MDX:  _____ _____ _____ _____ _____
                //      |     |     |     |     |     |
                //      |  0  |  1  |  2  |  3  |  4  | 
                //      |_____|_____|_____|_____|_____|
                //       µ(DX) µ(DX) µ(DX) µ(DX) µ(DX)
                //        VL    L     E     R     VR
                //
                MDX[0, i] = Gaussian(dX, gaussianData_DX[4 - i, 0], gaussianData_DX[4 - i, 1]);
            }
            //
            // calculate RuleFire Matrix of (MDX * MDY)
            //
            RuleFire = Multiply(MDY, 5, 1, MDX, 1, 5);
            //
            // create Product Multiply between ȳ and RuleFire
            //
            ProdMatrix = Dot(yBar_DYF, 5, 5, RuleFire, 5, 5);
            //
            // calc DXF = sum(ȳ.*RuleFire)/sum(RuleFire)
            //
            return Sum(ProdMatrix, 5, 5) / Sum(RuleFire, 5, 5);
        }

        #region Dynamic func
        /// <summary>
        /// find distance between P0 and P1
        /// </summary>
        /// <param name="P0">first point of the line</param>
        /// <param name="P1">second point of the line</param>
        /// <returns>distance between p0 and p1</returns>
        public static float Distance(Point P0, Point P1)
        {
            //
            // Distance = ( (X2-X1)^2 + (Y2-Y1)^2 )^0.5
            return (float)Math.Sqrt(Math.Pow((P1.X - P0.X), 2) + Math.Pow((P1.Y - P0.Y), 2));
        }

        /// <summary>
        /// Calculating Gaussian function.
        /// </summary>
        /// <param name="x">value on the X axis</param>
        /// <param name="avg">Gaussian Avrage</param>
        /// <param name="variance">Gaussian Variance</param>
        /// <returns>value on the Y axis</returns>
        public static double Gaussian(double x, double avg, double variance)
        {
            try
            {
                //
                // Gaussian = exp^-[(x-avg)/σ]^2
                return Math.Pow(Math.E, -Math.Pow(((x - avg) / variance), 2));
            }
            catch { return 0; }
        }

        /// <summary>
        /// Multiply two Matrix
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <param name="columnA">ColumnCount of Matrix A</param>
        /// <param name="rowA">RowCount of Matrix A</param>
        /// <param name="B">Matrix B</param>
        /// <param name="columnB">ColumnCount of Matrix B</param>
        /// <param name="rowB">RowCount of Matrix B</param>
        /// <returns>A * B</returns>
        public double[,] Multiply(double[,] A, int rowA, int columnA, double[,] B , int rowB, int columnB)
        {
            if (columnA != rowB) 
                throw new ArgumentException("Inner matrix dimensions must agree.");

            double[,] C = new double[rowA, columnB];

            for (int i = 0; i < rowA; i++)
            {
                for (int j = 0; j < columnB; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < columnA; k++)
                        C[i, j] += A[i, k] * B[k, j];                    
                } 
            }
            
            return C;
        }

        /// <summary>
        /// Dot Multiply two Matrix
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <param name="columnA">ColumnCount of Matrix A</param>
        /// <param name="rowA">RowCount of Matrix A</param>
        /// <param name="B">Matrix B</param>
        /// <param name="columnB">ColumnCount of Matrix B</param>
        /// <param name="rowB">RowCount of Matrix B</param>
        /// <returns>(A .* B)</returns>
        public double[,] Dot(double[,] A, int rowA, int columnA, double[,] B, int rowB, int columnB)
        {
            if (columnA != columnB || rowA != rowB || A.Length != B.Length)
                throw new ArgumentException("Both dimensions of the matrix should be equal.");

            double[,] C = new double[rowA, columnA];

            for (int i = 0; i < rowA; i++)
            {
                for (int j = 0; j < columnA; j++)
                {
                    C[i, j] = A[i, j] * B[i, j];
                }
            }

            return C;
        }

        /// <summary>
        /// calculate sum of any index in Matrix
        /// </summary>
        /// <param name="matrix">a 2D Matrix</param>
        /// <param name="columnCount">Matrix column count</param>
        /// <param name="rowCount">Matrix row count</param>
        /// <returns>sum of all index in matrix</returns>
        public double Sum(double[,] matrix, int columnCount, int rowCount)
        {
            double sum = 0;
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                {
                    sum += matrix[i, j];
                }
            return sum;
        }

        /// <summary>
        /// calculate matrix transpose
        /// </summary>
        /// <param name="matrix">a 2D Matrix</param>
        /// <param name="columnCount">Matrix column count</param>
        /// <param name="rowCount">Matrix row count</param>
        /// <returns>transposed matrix</returns>
        public double[,] Transpose(double[,] matrix, int columnCount, int rowCount)
        {
            if(columnCount != rowCount)
                throw new ArgumentException("To calculate the transpose must be square matrix desired.");

            double[,] t = new double[rowCount, columnCount];

            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < columnCount; c++)
                {
                    t[r, c] = matrix[c, r];
                }

            return t;
        }

        #endregion
    }
}

