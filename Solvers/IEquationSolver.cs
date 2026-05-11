using System.Numerics;
using kursova.Models;

namespace kursova.Solvers
{
    public interface IEquationSolver
    {
        (Complex Root, int Iterations, bool Success) Solve(Equation equation, Complex initialGuess, double epsilon, int maxIterations);
    }
}