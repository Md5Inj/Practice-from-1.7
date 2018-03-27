using System;

namespace task2
{
    class Program
    {
        interface IMathObject<T, Tp>
        {
            T Add(T a, T b);
            T Subtract(T a, T b);
            T Multiply(T a, T b);
            T Multiply(T a, Tp val);
            string ToString();
        }

        class Polynom : IMathObject<Polynom, int>
        {
            public int[] Coefficient;
            public int pow;
            public Polynom(int pow)
            {
                this.pow = pow;
                Coefficient = new int[pow];
                for (int i = 1; i < pow; i++)
                {
                    Random random = new Random();
                    Coefficient[i] = random.Next(1, 10);
                }
            }
            public Polynom Add(Polynom a, Polynom b)
            {
                int max = 0;
                max = a.pow > b.pow ? a.pow : b.pow;

                int[] arr = new int[max + 1]; 
                if (a.pow == b.pow)
                    for (int i = a.pow - 1; i >= 0 ; i--)
                        arr[i] = a.Coefficient[i] + b.Coefficient[i];

                if (a.pow > b.pow)
                {
                    for (int i = a.pow; i > b.pow; i--)
                        arr[i] = a.Coefficient[i];

                    for (int i = b.pow; i >= 0 ; i--)
                        arr[i] = a.Coefficient[i] + b.Coefficient[i];
                }

                if (a.pow > b.pow)
                {
                    for (int i = b.pow; i > a.pow; i--)
                        arr[i] = b.Coefficient[i];

                    for (int i = a.pow; i >= 0 ; i--)
                        arr[i] = b.Coefficient[i] + a.Coefficient[i];
                }

                this.Coefficient = arr;
                this.pow = max;

                return this;
            }

            public Polynom Multiply(Polynom a, Polynom b)
            {
                int max = a.pow + b.pow;
                int[] arr = new int[max];
                for (int i = a.pow - 1; i >= 0; i--)
                    for (int j = b.pow - 1; j >= 0; j--)
                        arr[i + j] += a.Coefficient[i] * b.Coefficient[j];

                this.Coefficient = arr;
                this.pow = max-1;

                return this;
            }

            public Polynom Multiply(Polynom a, int val)
            {
                int max = a.pow;
                int[] arr = new int[max];
                for (int i = a.pow - 1; i >= 0; i--)
                    arr[i] += a.Coefficient[i] * val;

                this.Coefficient = arr;
                this.pow = max;

                return this;
            }

            public Polynom Subtract(Polynom a, Polynom b)
            {
                int max = 0;
                max = a.pow > b.pow ? a.pow : b.pow;

                int[] arr = new int[max + 1]; 
                if (a.pow == b.pow)
                    for (int i = a.pow - 1; i >= 0 ; i--)
                        arr[i] = a.Coefficient[i] - b.Coefficient[i];

                if (a.pow > b.pow)
                {
                    for (int i = a.pow; i > b.pow; i--)
                        arr[i] = a.Coefficient[i];

                    for (int i = b.pow; i >= 0 ; i--)
                        arr[i] = a.Coefficient[i] - b.Coefficient[i];
                }

                if (a.pow > b.pow)
                {
                    for (int i = b.pow; i > a.pow; i--)
                        arr[i] = b.Coefficient[i];

                    for (int i = a.pow; i >= 0 ; i--)
                        arr[i] = b.Coefficient[i] - a.Coefficient[i];
                }

                this.Coefficient = arr;
                this.pow = max;

                return this;
            }
            public override string ToString()
            {
                string s = "";
                for (int i = this.pow-1; i > 0 ; i--)
                {
                    if (i == 1)
                        s += this.Coefficient[i] + "x^" + i;
                    else
                        s += this.Coefficient[i] + "x^" + i + " + ";
                }
                return s;
            }
        }

        class Vector : IMathObject<Vector, int>
        {
            private int X;
            private int Z;
            private int Y;
            public Vector()
            {
                Random random = new Random();
                this.X = random.Next(-10, 10);
                this.Y = random.Next(-10, 10);
                this.Z = random.Next(-10, 10);
            }

            public Vector Add(Vector a, Vector b)
            {
                a.X += b.X;
                a.Y += b.Y;
                a.Z += b.Z;
                return a;
            }

            public Vector Multiply(Vector a, Vector b)
            {
                a.X *= b.X;
                a.Y *= b.Y;
                a.Z *= a.Z;
                return a;                
            }

            public Vector Multiply(Vector a, int val)
            {
                a.X *= val;
                a.Y *= val;
                a.Z *= val;
                return a;  
            }

            public Vector Subtract(Vector a, Vector b)
            {
                a.X -= b.X;
                a.Y -= b.Y;
                a.Z -= b.Z;
                return a;
            }

            public override string ToString()
            {
                return String.Format($"X: {this.X} Y:{this.Y} Z:{this.Z}");
            }
        }

        static void Main(string[] args)
        {
            Polynom p = new Polynom(3);
            Console.WriteLine($"p:\n{p}");
            Polynom z = new Polynom(3);
            Console.WriteLine($"z:\n{z}");
            Console.WriteLine($"+: {p.Add(p, z)}");
            Console.WriteLine($"-: {p.Subtract(p, z)}");
            Console.WriteLine($"*: {p.Multiply(p, z)}");
            Console.WriteLine($"*: {p.Multiply(p, 5)}");


            Vector r = new Vector();
            Console.WriteLine($"r:\n{r}");
            Vector vector = new Vector();
            Console.WriteLine($"v:\n{vector}");
            Console.WriteLine(r.Add(r, vector));
            Console.WriteLine(r.Multiply(r, vector));
            Console.WriteLine(r.Multiply(r, 2));
            Console.WriteLine(r.Subtract(r, vector));
            Console.ReadKey();
        }
    }
}
