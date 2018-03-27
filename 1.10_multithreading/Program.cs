using System;
using System.Threading;

namespace _1._10_multithreading
{
    class Params {
        public int Where { get; set; }
        public int Col {get; set;}
        public int i { get; set; }
    }
    class Matrix
    {
        private Mutex m = new Mutex();
        private double[,] arr;
        public Matrix(int N, int M)
        {
            arr = new double[N, M];
            this.setRandom();
            this.Print();
            Thread t = new Thread(this.DoTask);
            t.Name = "Matrix construcor and DoTask";
            t.Start();
        }
        public void setRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(-10, 10) * 0.1;
                } 
            }
        }
        
        public void Print()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],4} ");
                } 
                Console.WriteLine();
            }
        }

        private void SwapCol(object obj)
        {
            m.WaitOne();
            Params p = (Params)obj;
            Swap(ref this.arr[p.i, p.Where], ref this.arr[p.i, p.Col]);
            Console.WriteLine("Active thread: " + Thread.CurrentThread.Name);
            m.ReleaseMutex();
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
        public void ChangeCol(int where, int col)
        {
            for (int i = 0; i < this.arr.GetLength(1); i++)
            {
                Thread th = new Thread(new ParameterizedThreadStart(this.SwapCol));
                th.Name = i.ToString();
                th.Start(new Params { i = i, Col = col, Where = where});
            }
        }
        
        public int[] Max()
        {
            double max = 0;
            int col = 0, row = 0; 

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ( this.arr[i, j] > max )
                    {
                        max = this.arr[i, j];
                        row = i;
                        col = j;
                    }
                } 
            }     
            
            int[] res = new int[2] {row, col};
            return res;
        }

        public int[] Min()
        {
            double min = 0;
            int col = 0, row = 0; 

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ( this.arr[i, j] < min )
                    {
                        min = this.arr[i, j];
                        row = i;
                        col = j;
                    }
                } 
            }

            int[] res = new int[2] {row, col};
            return res;
        }

        public void DoTask()
        {
            m.WaitOne();
            int[] min = this.Min(),
                max = this.Max();
            
            Console.WriteLine("Active thread: " + Thread.CurrentThread.Name);

            if (min[1] != max[1])
            {
                this.ChangeCol(min[1], max[1]);
            } else {
                this.arr[min[0], min[1]] /= 2;
                this.arr[max[0], max[1]] /= 2;
            }
            m.ReleaseMutex();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix(5, 5);
            Thread.Sleep(1000);
            m.Print();

            Console.ReadKey();
        }
    }
}
