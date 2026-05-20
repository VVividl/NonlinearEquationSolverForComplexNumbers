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

            // ПОКРАЩЕННЯ 1: Динамічний початковий крок (Адаптивність)
            // Крок залежить від стартової точки, але не може бути меншим за 1.0
            double step = Math.Max(1.0, center.Magnitude * 0.5);
            Random rnd = new Random();

            for (int i = 0; i < maxIterations; i++)
            {
                double currentVal = equation.Evaluate(center).Magnitude;

                // Перевіряємо, чи досягли необхідної точності
                if (currentVal <= epsilon)
                {
                    return (center, i, true);
                }

                // Зберігаємо попередню позицію для перевірки "топтання на місці"
                Complex previousCenter = center;

                // Перевіряємо 8 сусідніх точок (прямі напрямки + діагоналі)
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
                    // Якщо знайшли кращу точку, переходимо туди
                    center = bestPoint;

                    // ПОКРАЩЕННЯ 2: Детектор "топтання на місці" (Критерій Коші)
                    // Якщо ми майже не зрушили з місця, але корінь ще не знайдено
                    if (Complex.Abs(center - previousCenter) < (epsilon / 10.0) && minVal > epsilon)
                    {
                        // Робимо стохастичний (випадковий) стрибок для виходу з локального мінімуму
                        double jumpRe = (rnd.NextDouble() - 0.5) * step * 5.0;
                        double jumpIm = (rnd.NextDouble() - 0.5) * step * 5.0;
                        center = new Complex(center.Real + jumpRe, center.Imaginary + jumpIm);
                    }
                }
                else
                {
                    // Якщо жодна сусідня точка не краща, ділимо область пошуку навпіл
                    step /= 2.0;

                    // АНТИ-ПАСТКА: Якщо крок став критично малим, але корінь не знайдено
                    if (step < epsilon / 100.0)
                    {
                        // Робимо випадковий стрибок 
                        double jumpRe = (rnd.NextDouble() - 0.5) * 5.0;
                        double jumpIm = (rnd.NextDouble() - 0.5) * 5.0;
                        center = new Complex(center.Real + jumpRe, center.Imaginary + jumpIm);

                        // Відновлюємо розмір кроку для нової області
                        step = Math.Max(1.0, center.Magnitude * 0.5);
                    }
                }
            }

            // Якщо ліміт ітерацій вичерпано
            return (center, maxIterations, false);
        }
    }
}