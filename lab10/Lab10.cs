using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Lab10 : Form
    {
        static Mutex mut = new Mutex();
        public Lab10()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int numThreads = Environment.ProcessorCount;
            int numIterations = int.Parse(textBox1.Text);
            List<Task<double>> tasks = new List<Task<double>>();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < numThreads; i++)
            {

                int num = i;
                tasks.Add(Task<double>.Factory.StartNew(() =>
                {
                    double sum = 0;
                    for (int j = num; j < numIterations; j += numThreads)
                    {
                        sum += CalcA(j) * CalcB(j);
                    }
                    return sum;
                }));


            }

            Task.WaitAll(tasks.ToArray());

            double result = 0;
            foreach (Task<double> task in tasks)
            {

                result += task.Result;
            }
            watch.Stop();
            double efect = (numIterations - 1) / ((numIterations / 2.0) * Math.Log(numIterations, 2));
            double speedup = (numIterations - 1) / Math.Log(numIterations, 2);

            dataGridView1.Rows.Add("Каскадна схема", watch.Elapsed.Milliseconds, numIterations, efect, speedup, result, AmdahlLaw(numThreads, speedup), GustafsonLaw(numThreads, speedup));


        }



        private void Lab10_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static double AmdahlLaw(int n, double p)
        {
            return 1 / ((1 - p) + p / n);
        }


        public static double GustafsonLaw(int n, double p)
        {
            return n - p * (n - 1);
        }

        public double CalcA(int x)
        {
            double res = Math.Pow(-1, x) * ((5.0 * Math.Pow(x, 5.0)) / (Math.Pow(2.0, 3 * x + 1)));
            return Double.IsNaN(res) ? 0 : res;
        }
        public double CalcB(int x)
        {
            double res = 1 + 5.0 / ((2 * x + 1) * x) - (Math.Abs(Math.Sin(x)) / (x * x));
            return Double.IsNaN(res) ? 0 : res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            int numThreads = Environment.ProcessorCount;
            double[] results = new double[numThreads];
            int numIterations = int.Parse(textBox1.Text);
            int length = numIterations;
            List<double> needcalc = new List<double>();
            for (int i = 0; i < numIterations; i++)
            {
                needcalc.Add(CalcA(i) * CalcB(i));
            }
            watch.Start();
            while (length > 1)
            {
                //MessageBox.Show(length.ToString());
                int halfLength = length / 2;
                Task[] tasks = new Task[halfLength];
                if (length % 2 != 0)
                {
                    needcalc[0] += needcalc[halfLength];
                }
                //for (int i = 0; i < halfLength; i++)
                //{
                //    int index = i;
                //    tasks[i] = Task.Run(() => {
                //        needcalc[index] += needcalc[length - index - 1];
                //    });
                //}
                //Task.WaitAll(tasks);

                Parallel.For(0, halfLength, i =>
                {
                    needcalc[i] += needcalc[length - i - 1];
                });

                length = halfLength;
            }
            watch.Stop();
            double efect = (numIterations) / (3 * Math.Log(numIterations, 2));
            double speedup = (2 * numIterations) / (3 * Math.Log(numIterations, 2));


            dataGridView1.Rows.Add("Редукція", watch.Elapsed.Milliseconds, numIterations, efect, speedup, needcalc[0], AmdahlLaw(numThreads, speedup), GustafsonLaw(numThreads, speedup));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            double result = 0;
            watch.Start();
            int numIterations = int.Parse(textBox1.Text);
            for (int i = 0; i < numIterations; i++)
            {
                ;
                result += CalcA(i) * CalcB(i);

            }
            watch.Stop();
            dataGridView1.Rows.Add("Послідовно", watch.Elapsed.Milliseconds, numIterations, "-", "-", result, "-", "-");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numThreads = Environment.ProcessorCount;
            Stopwatch watch = new Stopwatch();


            int numIterations = int.Parse(textBox1.Text);
            // List<Task<double>> tasks = new List<Task<double>>();

            int countElement = numIterations;
            int countOfGroup = (int)(countElement / Math.Log(numIterations, 2));

            int groupSize = numIterations / countOfGroup;
            //if(countOfGroup * groupSize < countElement)
            //{
            //    groupSize++;
            //}
            //for (int i = 0; i < countOfGroup; i++)
            //{
            //    int startIndex = i * groupSize;
            //    int endIndex = (startIndex + groupSize);
            //    endIndex = endIndex > countElement ? countElement : endIndex;
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        double groupSum = 0;

            //        for (int j = startIndex; j < endIndex; j++)
            //        {

            //            groupSum += Math.Cos(j) * Math.Sin(j);
            //        }
            //        return groupSum;

            //    })); 
            //}

            //Task.WaitAll(tasks.ToArray());
            //watch.Start();

            List<double> needcalc = new List<double>();
            for (int i = 0; i < numIterations; i++)
            {
                needcalc.Add(CalcA(i) * CalcB(i));
            }
            watch.Start();
            while (needcalc.Count != 1)
            {

                //MessageBox.Show(needcalc.Sum().ToString());
                //MessageBox.Show(needcalc.Count.ToString());
                int countOfElement = needcalc.Count;
                countOfGroup = (int)(countOfElement / Math.Log(needcalc.Count, 2));
                countOfGroup = countOfGroup > 12 ? 12 : countOfGroup;
                groupSize = countOfElement / countOfGroup;
                if (countOfGroup * groupSize < countOfElement)
                {
                    groupSize++;
                }
                List<Task<double>> tasks = new List<Task<double>>();
                for (int i = 0; i < countOfGroup; i++)
                {
                    int startIndex = i * groupSize;
                    int endIndex = (startIndex + groupSize);
                    endIndex = endIndex > countOfElement ? countOfElement : endIndex;
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        double groupSum = 0;

                        for (int j = startIndex; j < endIndex; j++)
                        {

                            groupSum += needcalc[j];
                        }
                        return groupSum;

                    }));
                }

                Task.WaitAll(tasks.ToArray());

                needcalc.Clear();
                foreach (Task<double> task in tasks)
                {
                    needcalc.Add(task.Result);
                }

                if (needcalc.Count == 2)
                {
                    break;
                }
            }
            double result = needcalc.Sum();

            watch.Stop();

            double efect = (numIterations - 1.0) / (2.0 * numIterations);
            double speedup = (numIterations - 1) / (2.0 * Math.Log(numIterations, 2));

            dataGridView1.Rows.Add("Каскадна модифікована схема", watch.Elapsed.Milliseconds, numIterations, efect, speedup, result, AmdahlLaw(numThreads, speedup), GustafsonLaw(numThreads, speedup));
        }
    }
}
