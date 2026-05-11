using System.Numerics;
using kursova.Models;

namespace kursova.Solvers
{
    public class AlgebraicSolver : IEquationSolver
    {
        public (Complex Root, int Iterations, bool Success) Solve(Equation equation, Complex initialGuess, double epsilon, int maxIterations)
        {
            int degree = equation.Coefficients.Length - 1;

            if (degree == 1)
            {
                if (equation.Coefficients[1] == Complex.Zero)
                    return (Complex.Zero, 1, false);

                return (-equation.Coefficients[0] / equation.Coefficients[1], 1, true);
            }
            else if (degree == 2)
            {
                Complex a = equation.Coefficients[2];
                Complex b = equation.Coefficients[1];
                Complex c = equation.Coefficients[0];

                Complex discriminant = b * b - 4 * a * c;
                Complex sqrtD = Complex.Sqrt(discriminant);

                Complex root = (-b + sqrtD) / (2 * a);
                return (root, 1, true);
            }

            NewtonSolver fallbackSolver = new NewtonSolver();
            return fallbackSolver.Solve(equation, initialGuess, epsilon, maxIterations);
        }
    }
}