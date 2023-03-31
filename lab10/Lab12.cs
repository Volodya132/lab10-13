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
    public partial class Lab12 : Form
    {
        static double[,] A;
        static double[,] B;
        public Lab12()
        {
            InitializeComponent();
        }

        double calcA(int i, int k)
        {
            double res = (Math.Pow(Math.Log(Math.Pow(Math.Pow(k, 0.4) + i, 3)) / (i * i + i + 2), 2)) - Math.Pow(i, k / 3.0);
            return Double.IsNaN(res) || Double.IsInfinity(res) ? 0 : res;
        }
        double calcB(int k, int j)
        {
            double res = (Math.Pow(Math.Log(Math.Pow(6.0 + j, j/4.0)) / (j * j - (double)k/j + 3.0), 2));
            return Double.IsNaN(res) || Double.IsInfinity(res) ? 0 : res;
        }

        public static double[,] MultiplyMatrixParallel(double[,] matrixA, double[,] matrixB)
        {
            int rowCountA = matrixA.GetLength(0);
            int colCountA = matrixA.GetLength(1);
            int colCountB = matrixB.GetLength(1);

            double[,] resultMatrix = new double[rowCountA, colCountB];

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < rowCountA; i++)
            {
                int rowIndex = i;
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < colCountB; j++)
                    {
                        double sum = 0;
                        for (int k = 0; k < colCountA; k++)
                        {
                            sum += matrixA[rowIndex, k] * matrixB[k, j];
                        }
                        resultMatrix[rowIndex, j] = sum;
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            return resultMatrix;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int m = int.Parse(textBox1.Text);
            int n = int.Parse(textBox2.Text);
            int l = int.Parse(textBox3.Text);
            A = new double[m, n];
            B = new double[n, l];
       
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();

            dataGridView1.ColumnCount = A.GetLength(1);
            dataGridView2.ColumnCount = B.GetLength(1);


            for (int i = 0; i < m; i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = calcA(i, j);
                    dataGridView1.Rows[i].Cells[j].Value = A[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                dataGridView2.Rows.Add();
                for (int j = 0; j < l; j++)
                {
                    B[i, j] = calcB(i, j);
                    dataGridView2.Rows[i].Cells[j].Value = B[i, j];
                }
            }
        }

        public static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
        {
            int n = matrixA.GetLength(0);
            int m = matrixA.GetLength(1);
            int l = matrixB.GetLength(1);
            double[,] matrixC = new double[n, l];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    matrixC[i, j] = sum;
                }
            }

            return matrixC;
        }

        void fillDataGrid(double[,] matrix, DataGridView dataGrid)
        {
            dataGrid.Columns.Clear();
            dataGrid.Rows.Clear();
            dataGrid.ColumnCount = matrix.GetLength(1);
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
            double[,] res = MultiplyMatrixParallel(A, B);
            fillDataGrid(res, dataGridView3);
            watch.Stop();
            dataGridView5.Rows.Add("Базовий", watch.Elapsed.Milliseconds, A.GetLength(0), A.GetLength(1), B.GetLength(1));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            double[,] res = MultiplyMatrices(A, B);
            fillDataGrid(res, dataGridView4);
            watch.Stop();

            dataGridView5.Rows.Add("Послідвно", watch.Elapsed.Milliseconds, A.GetLength(0), A.GetLength(1), B.GetLength(1));
        }
    }
}
