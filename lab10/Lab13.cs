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
    public partial class Lab13 : Form
    {
        static int[] arr;
        public Lab13()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Random random = new Random();
            int count = int.Parse(textBox1.Text);
            arr = new int[count];
            for(int i = 0; i < count; i++)
            {
                arr[i] = random.Next(0, 100);
                textBox2.Text += arr[i].ToString() +" ";
            }
        }

        public static void ParallelOddEvenSort(int[] arr)
        {
            bool sorted = false;

            while (!sorted)
            {
                sorted = true;

                Task oddTask = Task.Run(() =>
                {
                    for (int i = 1; i < arr.Length - 1; i += 2)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            Swap(arr, i, i + 1);
                            sorted = false;
                        }
                    }
                });

                Task evenTask = Task.Run(() =>
                {
                    for (int i = 0; i < arr.Length - 1; i += 2)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            Swap(arr, i, i + 1);
                            sorted = false;
                        }
                    }
                });

                Task.WaitAll(oddTask, evenTask);
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ParallelOddEvenSort(arr);
      
            for (int i = 0; i < arr.Length; i++)
            {
                textBox3.Text += arr[i].ToString() + " ";
            }
            watch.Stop();
            dataGridView5.Rows.Add("Паралельно", watch.Elapsed.Milliseconds, arr.Length);

        }

        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < n; i++)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        Swap(arr, i - 1, i);
                        swapped = true;
                    }
                }

                n--;
            } while (swapped);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            BubbleSort(arr);
         
            for (int i = 0; i < arr.Length; i++)
            {
                textBox3.Text += arr[i].ToString() + " ";
            }
            watch.Stop();

            dataGridView5.Rows.Add("Послідовно", watch.Elapsed.Milliseconds, arr.Length);
        }
    }
}
