using System;
using System.Numerics;

namespace kursova.Models
{
    public class Equation
    {
        public Complex[] Coefficients { get; set; }

        public Equation(Complex[] coefficients)
        {
            Coefficients = coefficients;
        }
        public Complex Evaluate(Complex z)
        {
            Complex result = Complex.Zero;
            Complex currentZPower = Complex.One;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                result += Coefficients[i] * currentZPower;
                currentZPower *= z;
            }

            return result;
        }

        public Complex EvaluateDerivative(Complex z)
        {
            Complex result = Complex.Zero;
            Complex currentZPower = Complex.One;

            for (int i = 1; i < Coefficients.Length; i++)
            {
                result += Coefficients[i] * new Complex(i, 0) * currentZPower;
                currentZPower *= z;
            }

            return result;
        }
    }
}