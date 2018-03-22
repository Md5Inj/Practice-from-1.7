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

        class Rational : IMathObject<Rational, int>
        {
            int Numenator;
            int Denumenator;
            public Rational()
            {
                Random random = new Random();
                this.Numenator = random.Next(-10, 10);
                this.Denumenator = random.Next(-10, 10);
            }
            public Rational Add(Rational a, Rational b)
            {
                if (a.Denumenator == b.Denumenator)
                {
                    a.Numenator = a.Numenator + b.Numenator;
                } 
                else
                {
                    int temp = a.Denumenator;
                    a.Numenator *= b.Denumenator;
                    a.Denumenator *= b.Denumenator;

                    b.Denumenator *= temp;
                    b.Numenator *= temp;

                    a.Numenator = a.Numenator + b.Numenator;
                }

                return a;
            }

            public Rational Multiply(Rational a, Rational b)
            {
                a.Numenator *= b.Numenator;
                a.Denumenator *= b.Denumenator;
                return a;
            }

            public Rational Multiply(Rational a, int val)
            {
                a.Numenator *= val;
                return a;
            }

            public Rational Subtract(Rational a, Rational b)
            {
                if (a.Denumenator == b.Denumenator)
                {
                    a.Numenator = a.Numenator + b.Numenator;
                } 
                else
                {
                    int temp = a.Denumenator;
                    a.Numenator *= b.Denumenator;
                    a.Denumenator *= b.Denumenator;

                    b.Denumenator *= temp;
                    b.Numenator *= temp;

                    a.Numenator = a.Numenator - b.Numenator;
                }

                return a;
            }
            
            public override string ToString()
            {
                return String.Format($"{this.Numenator}/{this.Denumenator}");
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


            Rational r = new Rational();
            Console.WriteLine($"r:\n{r}");
            Rational b = new Rational();
            Console.WriteLine($"b:\n{b}");
            Console.WriteLine($"+: {r.Add(r, b)}");
            Console.WriteLine($"-: {r.Subtract(r, b)}");
            Console.WriteLine($"*: {r.Multiply(r, b)}");
            Console.WriteLine($"*: {r.Multiply(r, 2)}");
            Console.ReadKey();
        }
    }
}
