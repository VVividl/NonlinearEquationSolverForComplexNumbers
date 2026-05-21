using System;
using System.Numerics;
using kursova.Models;

namespace kursova.Solvers
{
    public class BisectionSolver : IEquationSolver
    {
        public (Complex Root, int Iterations, bool Success) Solve(Equation equation, Complex initialGuess, double epsilon, int maxIterations)
        {
            Complex center = initialGuess;
            double step = Math.Max(1.0, center.Magnitude * 0.5);
            Random rnd = new Random();

            for (int i = 0; i < maxIterations; i++)
            {
                double currentVal = equation.Evaluate(center).Magnitude;

                if (currentVal <= epsilon)
                {
                    return (center, i, true);
                }

                Complex previousCenter = center;

                Complex[] points = {
                    new Complex(center.Real - step, center.Imaginary),
                    new Complex(center.Real + step, center.Imaginary),
                    new Complex(center.Real, center.Imaginary - step),
                    new Complex(center.Real, center.Imaginary + step),
                    new Complex(center.Real - step, center.Imaginary - step),
                    new Complex(center.Real + step, center.Imaginary - step),
                    new Complex(center.Real - step, center.Imaginary + step),
                    new Complex(center.Real + step, center.Imaginary + step)
                };

                Complex bestPoint = center;
                double minVal = currentVal;

                foreach (var p in points)
                {
                    double val = equation.Evaluate(p).Magnitude;
                    if (val < minVal)
                    {
                        minVal = val;
                        bestPoint = p;
                    }
                }

                if (minVal < currentVal)
                {
                    center = bestPoint;
                    step *= 1.5;

                    if (Complex.Abs(center - previousCenter) < (epsilon / 10.0) && minVal > epsilon)
                    {
                        double jumpRe = (rnd.NextDouble() - 0.5) * step * 5.0;
                        double jumpIm = (rnd.NextDouble() - 0.5) * step * 5.0;
                        center = new Complex(center.Real + jumpRe, center.Imaginary + jumpIm);
                    }
                }
                else
                {
                    step /= 2.0;

                    if (step < epsilon / 100.0)
                    {
                        double jumpRe = (rnd.NextDouble() - 0.5) * 5.0;
                        double jumpIm = (rnd.NextDouble() - 0.5) * 5.0;
                        center = new Complex(center.Real + jumpRe, center.Imaginary + jumpIm);

                        step = Math.Max(1.0, center.Magnitude * 0.5);
                    }
                }
            }

            return (center, maxIterations, false);
        }
    }
}