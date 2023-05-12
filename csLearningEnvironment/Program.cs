using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace csLearningEnvironment // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            decimal avgMs = decimal.Zero;
            BigInteger n = 3981072;
            ulong numIterations = 25;

            Console.WriteLine($"Fast doubling total runtime O(log2(n)) = {Math.Log2((double) n)} iterations");
            avgMs = fibControl(n, numIterations, 'd');
            Console.WriteLine($"fast doubling computed in: {avgMs} ms");
            Console.WriteLine($"fast doubling computed in: {avgMs * 1000000} ns\n\n");

            Console.WriteLine($"Conventional iteration total runtime O(n) = {n} iterations");
            avgMs = fibControl(n, numIterations, 'i');
            Console.WriteLine($"fast doubling computed in: {avgMs} ms");
            Console.WriteLine($"fast doubling computed in: {avgMs * 1000000} ns\n\n");

        }

        static decimal fibControl(BigInteger n, ulong numIterations, char varient)
        {
            decimal totalTime = 0;
            BigInteger fib = BigInteger.Zero;

            Stopwatch sw = new Stopwatch();

            for (ulong i = 0; i < numIterations; i++)
            {   
                if(varient == 'i')
                {
                    sw.Start();
                    fib = iterativeFib(n);
                    sw.Stop();
                }
                else if(varient == 'r')
                {
                    sw.Start();
                    fib = recursiveFib(n);
                    sw.Stop();
                }
                else if(varient == 'd')
                {
                    sw.Start();
                    fib = fastDoubleFib(n);
                    sw.Stop();
                }

                TimeSpan ts = sw.Elapsed;
                totalTime += (decimal)ts.TotalMilliseconds;
                sw.Restart();
            }

            decimal avgMs = totalTime / numIterations;

            return avgMs;
        }

        static BigInteger fastDoubleFib(BigInteger n)
        {
            BigInteger a = BigInteger.Zero;
            BigInteger b = BigInteger.One;
            for(int i = 31; i >= 0; i--)
            {
                BigInteger d = a * (b * 2 - a);
                BigInteger e = a * a + b * b;
                a = d;
                b = e;
                if((((uint) n >> i) & 1) != 0)
                {
                    BigInteger c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a;
        }

        static System.Numerics.BigInteger recursiveFib(System.Numerics.BigInteger n)
        {
            if (n <= 1)
                return n;
            else
                return recursiveFib(n - 1) + recursiveFib(n - 2);
        }

        static System.Numerics.BigInteger iterativeFib(System.Numerics.BigInteger n)
        {
            System.Numerics.BigInteger fib = 1;
            System.Numerics.BigInteger prevFib = 1;
            System.Numerics.BigInteger temp = 0;

            for(System.Numerics.BigInteger i = 0; i < n; i++)
            {
                temp = fib;
                fib += prevFib;
                prevFib = temp;
            }
            return fib;
        }
    }
}