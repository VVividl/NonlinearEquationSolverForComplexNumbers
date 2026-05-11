using System.Numerics;
using kursova.Models;

namespace kursova.Solvers
{
    public class NewtonSolver : IEquationSolver
    {
        public (Complex Root, int Iterations, bool Success) Solve(Equation equation, Complex initialGuess, double epsilon, int maxIterations)
        {
            Complex z = initialGuess;

            for (int i = 0; i < maxIterations; i++)
            {
                Complex fz = equation.Evaluate(z);

                if (fz.Magnitude <= epsilon)
                {
                    return (z, i, true);
                }

                Complex dfz = equation.EvaluateDerivative(z);

                if (dfz.Magnitude == 0)
                {
                    return (z, i, false);
                }

                z = z - fz / dfz;
            }

            return (z, maxIterations, false);
        }
    }
}