using System.Numerics;
using kursova.Models;

namespace kursova.Solvers
{
    public class BisectionSolver : IEquationSolver
    {
        public (Complex Root, int Iterations, bool Success) Solve(Equation equation, Complex initialGuess, double epsilon, int maxIterations)
        {
            double step = 10.0;
            Complex center = initialGuess;

            for (int i = 0; i < maxIterations; i++)
            {
                if (equation.Evaluate(center).Magnitude <= epsilon)
                {
                    return (center, i, true);
                }

                Complex[] points = {
                    new Complex(center.Real - step, center.Imaginary - step),
                    new Complex(center.Real + step, center.Imaginary - step),
                    new Complex(center.Real - step, center.Imaginary + step),
                    new Complex(center.Real + step, center.Imaginary + step)
                };

                Complex bestPoint = center;
                double minVal = equation.Evaluate(center).Magnitude;

                foreach (var p in points)
                {
                    double val = equation.Evaluate(p).Magnitude;
                    if (val < minVal)
                    {
                        minVal = val;
                        bestPoint = p;
                    }
                }

                center = bestPoint;
                step /= 2.0;
            }

            return (center, maxIterations, false);
        }
    }
}