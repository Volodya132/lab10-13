using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Lab11 : Form
    {
        static double[,] A;
        static double[,] y;
        public Lab11()
        {
            InitializeComponent();
           

        }
        public static double[,] MatrixVectorProduct(double[,] matrix, double[,] vector)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (vector.Length != n)
            {
                throw new ArgumentException("Vector length must be equal to the number of columns in the matrix.");
            }

            double[,] result = new double[n,1];

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += matrix[i, j] * vector[j,0];
                }
                result[i,0] = sum;
            }

            return result;
        }
        void fillDataGrid(double[,] matrix, DataGridView dataGrid)
        {
            dataGrid.Columns.Clear();
            dataGrid.Rows.Clear();
            dataGrid.ColumnCount = A.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dataGrid.Rows.Add();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGrid.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            double[,] res = MatrixVectorProduct(A, y);
         
     
            fillDataGrid(res, dataGridView3);
            watch.Stop();
            dataGridView5.Rows.Add("Послідовно", watch.Elapsed.Milliseconds, A.GetLength(0), A.GetLength(1));

        }
        double calcA(int i, int j, double x)
        {
            return (Math.Pow(Math.Sin(Math.Pow(x+j, 3.0)), 2.0)/(i*i-3.1)) + Math.Pow(x, 2.0/i);
        }
        double calcB(int j,  double x)
        {
            return (Math.Pow(Math.Sin(Math.Pow(6.0 + j, 0.3)), 2) / (Math.Pow(x, 2.0/j) - j*j-3.0));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int m = int.Parse(textBox2.Text);
            A = new double[n, m];
            y = new double[n, 1];
            Random rand = new Random();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = A.GetLength(1);

            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.ColumnCount = y.GetLength(1);
            for (int i = 0; i < A.GetLength(0); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView2.Rows.Add();
                y[i, 0] = calcB(i, 1);
                dataGridView2.Rows[i].Cells[0].Value = y[i, 0];
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = calcA(i, j, 1);
                    dataGridView1.Rows[i].Cells[j].Value = A[i, j]; 
                }

            }
        }
        public static double[] MultiplyBlock(double[,] A, double[,] y, int startRow, int endRow)
        {
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int b = endRow - startRow;
            double[] blockResult = new double[b];

            for (int i = startRow; i < endRow; i++)
            {
                double sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += A[i, j] * y[j,0];
                }
                blockResult[i - startRow] = sum;
            }

            return blockResult;
        }
        private void button3_Click(object sender, EventArgs e)
        {

            Stopwatch watch = new Stopwatch();
            watch.Start();
            int n = int.Parse(textBox1.Text);
            int m = int.Parse(textBox2.Text);
            int b = 4; // розмір блоку
            int numTasks = n / b; // кількість тасків
            if(numTasks*b <n)
            {
                numTasks++;
            }
         
            Task<double[]>[] tasks = new Task<double[]>[numTasks];
            for (int i = 0; i < numTasks; i++)
            {
                int startRow = i * b;
                int endRow = startRow + b > n ? n : startRow + b;
                tasks[i] = Task.Factory.StartNew(() => MultiplyBlock(A, y, startRow, endRow));
            }
            
            Task.WaitAll(tasks);
            double[] result = new double[n];
            for (int i = 0; i < numTasks; i++)
            {
                double[] blockResult = tasks[i].Result;
                int startRow = i * b;
                int endRow = startRow + b > n ? n : startRow + b;
                for (int j = startRow; j < endRow; j++)
                {
                    result[j] = blockResult[j - startRow];
                }
            }
          
            watch.Stop();
            dataGridView5.Rows.Add("Блочний", watch.Elapsed.Milliseconds, A.GetLength(0), A.GetLength(1));

            dataGridView4.Columns.Clear();
            dataGridView4.Rows.Clear();
            dataGridView4.ColumnCount = A.GetLength(1);
            for (int i = 0; i < result.GetLength(0); i++)
            {
                dataGridView4.Rows.Add();

                dataGridView4.Rows[i].Cells[0].Value = result[i];
             
            }



        }

        public static double[,] MultiplyMatrixByVectorRows(double[,] matrix, double[,] vector)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            // Розділимо матрицю на підматриці
            double[][] matrixRows = new double[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                matrixRows[i] = new double[numCols];
                for (int j = 0; j < numCols; j++)
                {
                    matrixRows[i][j] = matrix[i, j];
                }
            }

            Task<double>[] tasks = new Task<double>[numRows];

     
            for (int i = 0; i < numRows; i++)
            {
                int rowIndex = i;
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    double[] row = matrixRows[rowIndex];
                    double dotProduct = 0.0;
                    for (int j = 0; j < numCols; j++)
                    {
                        dotProduct += row[j] * vector[j,0];
                    }
                    return dotProduct;
                });
            }

    
            Task.WaitAll(tasks);

     
            double[,] result = new double[numRows,1];
            for (int i = 0; i < numRows; i++)
            {
                result[i,0] = tasks[i].Result;
            }

            return result;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            double[,] res = MultiplyMatrixByVectorRows(A, y);
            watch.Stop();

            fillDataGrid(res, dataGridView4);
          
            dataGridView5.Rows.Add("Розбиття по стрічках", watch.Elapsed.Milliseconds, A.GetLength(0), A.GetLength(1));

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
