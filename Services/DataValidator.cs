using System.Numerics;

namespace kursova.Services
{
    public static class DataValidator
    {
        public static bool IsValidDegree(int degree)
        {
            return degree > 0;
        }

        public static bool IsValidEpsilon(double epsilon)
        {
            return epsilon > 0;
        }

        public static bool TryParseComplexNumber(string input, out Complex result)
        {
            result = Complex.Zero;
            input = input.Trim().Replace(" ", "");

            if (double.TryParse(input,
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out double realOnly))
            {
                result = new Complex(realOnly, 0);
                return true;
            }

            if (input.EndsWith("i") && !input.Contains("+") &&
                input.LastIndexOf('-') <= 0)
            {
                string imagStr = input.TrimEnd('i');
                if (imagStr == "" || imagStr == "+") imagStr = "1";
                if (imagStr == "-") imagStr = "-1";
                if (double.TryParse(imagStr,
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double imagOnly))
                {
                    result = new Complex(0, imagOnly);
                    return true;
                }
            }

            if (input.EndsWith("i"))
            {
                int splitIdx = -1;
                for (int k = input.Length - 2; k > 0; k--)
                {
                    if (input[k] == '+' || input[k] == '-')
                    {
                        splitIdx = k;
                        break;
                    }
                }

                if (splitIdx > 0)
                {
                    string realPart = input.Substring(0, splitIdx);
                    string imagPart = input.Substring(splitIdx,
                        input.Length - splitIdx - 1);

                    if (imagPart == "+" || imagPart == "") imagPart = "1";
                    if (imagPart == "-") imagPart = "-1";

                    if (double.TryParse(realPart,
                            System.Globalization.NumberStyles.Float,
                            System.Globalization.CultureInfo.InvariantCulture,
                            out double r) &&
                        double.TryParse(imagPart,
                            System.Globalization.NumberStyles.Float,
                            System.Globalization.CultureInfo.InvariantCulture,
                            out double im))
                    {
                        result = new Complex(r, im);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}