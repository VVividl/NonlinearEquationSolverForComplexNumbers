using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using kursova.Models;
using kursova.Solvers;
using kursova.Services;
using System.IO;

namespace kursova
{
    public partial class Form1 : Form
    {
        private Equation _currentEquation;
        private Complex _lastResult;
        private string _lastReport;
        private bool _isSolved = false;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            cmbMethod.Items.Clear();
            cmbMethod.Items.Add("Bisection Method");
            cmbMethod.Items.Add("Newton's Method");
            cmbMethod.Items.Add("Algebraic Method");
            cmbMethod.SelectedIndex = 0;

            txtCoefficients.TextChanged += txtCoefficients_TextChanged;
            this.FormClosing += Form1_FormClosing;
        }

        //Формула

        private void txtCoefficients_TextChanged(object sender, EventArgs e)
        {
            UpdateFormulaPreview();
        }

        private void UpdateFormulaPreview()
        {
            try
            {
                string[] parts = txtCoefficients.Text
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 1)
                    parts = txtCoefficients.Text
                        .Split(new[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 2)
                {
                    lblFormula.Text = "";
                    return;
                }

                Complex[] coeffs = new Complex[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                {
                    string fixedPart = parts[i].Trim();
                    if (!fixedPart.Contains('i'))
                        fixedPart = fixedPart.Replace(',', '.');

                    if (!DataValidator.TryParseComplexNumber(fixedPart, out Complex c))
                    {
                        lblFormula.ForeColor = Color.FromArgb(255, 99, 110);
                        lblFormula.Text = ":( Wrong coefficients";
                        return;
                    }
                    coeffs[i] = c;
                }

                lblFormula.ForeColor = Color.HotPink;
                lblFormula.Text = BuildFormulaString(coeffs);
            }
            catch
            {
                lblFormula.Text = "";
            }
        }

        private string BuildFormulaString(Complex[] coeffs)
        {
            int degree = coeffs.Length - 1;
            StringBuilder sb = new StringBuilder();
            sb.Append("f(z) = ");

            bool firstTerm = true;

            for (int i = degree; i >= 0; i--)
            {
                Complex c = coeffs[i];
                if (c == Complex.Zero) continue;

                string coeffStr;
                if (c.Imaginary == 0)
                {
                    double real = c.Real;
                    if (!firstTerm)
                        sb.Append(real < 0 ? " - " : " + ");
                    else if (real < 0)
                        sb.Append("-");

                    double absReal = Math.Abs(real);
                    if (i == 0 || absReal != 1)
                        coeffStr = absReal % 1 == 0
                            ? ((int)absReal).ToString()
                            : absReal.ToString("G4");
                    else
                        coeffStr = "";
                }
                else
                {
                    if (!firstTerm) sb.Append(" + ");
                    string imagSign = c.Imaginary < 0 ? "-" : "+";
                    coeffStr = c.Real == 0
                        ? $"({c.Imaginary:G4}i)"
                        : $"({c.Real:G4}{imagSign}{Math.Abs(c.Imaginary):G4}i)";
                }

                sb.Append(coeffStr);

                if (i == 1)
                    sb.Append("z");
                else if (i > 1)
                    sb.Append("z" + ToSuperscript(i));

                firstTerm = false;
            }

            if (firstTerm) sb.Append("0");
            sb.Append(" = 0");
            return sb.ToString();
        }

        private string ToSuperscript(int n)
        {
            string[] superscripts = { "⁰", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹" };
            string result = "";
            foreach (char c in n.ToString())
                result += superscripts[c - '0'];
            return result;
        }

        //Розв'язати 

        private void btnSolve_Click(object sender, EventArgs e)
        {
            //Валідація epsilon
            string epsilonText = txtEpsilon.Text.Replace(',', '.');
            if (!double.TryParse(epsilonText,
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out double epsilon) || !DataValidator.IsValidEpsilon(epsilon))
            {
                MessageBox.Show(
                    "Accuracy must be > 0.\n" +
                    "Use a dot or comma as separator (e.g.: 0.0001)",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Валідація maxIterations
            if (!int.TryParse(txtMaxIterations.Text, out int maxIterations) || maxIterations <= 0)
            {
                MessageBox.Show(
                    "Max iterations must be a positive integer > 0.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Валідація початкового наближення
            string initRealText = txtInitialReal.Text.Replace(',', '.');
            string initImagText = txtInitialImag.Text.Replace(',', '.');
            if (!double.TryParse(initRealText,
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out double initReal) ||
                !double.TryParse(initImagText,
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out double initImag))
            {
                MessageBox.Show(
                    "Initial approximation must be a number.\n" +
                    "Use a dot as separator (e.g.: 1.5)",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Парсинг коефіцієнтів
            string[] coeffStrings = txtCoefficients.Text
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (coeffStrings.Length == 1)
                coeffStrings = txtCoefficients.Text
                    .Split(new[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

            Complex[] coefficients = new Complex[coeffStrings.Length];
            for (int i = 0; i < coeffStrings.Length; i++)
            {
                string fixedCoef = coeffStrings[i].Trim();
                if (!fixedCoef.Contains('i'))
                    fixedCoef = fixedCoef.Replace(',', '.');

                if (!DataValidator.TryParseComplexNumber(fixedCoef, out Complex coef))
                {
                    MessageBox.Show(
                        $"'{coeffStrings[i].Trim()}' — invalid coefficient.\n" +
                        "Supported formats: 1, -2, 3+4i, 5i",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                coefficients[i] = coef;
            }

            if (!DataValidator.IsValidDegree(coefficients.Length - 1))
            {
                MessageBox.Show(
                    "At least 2 coefficients required (degree ≥ 1).\n" +
                    "Example for z²+3z-5=0: enter -5, 3, 1",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentEquation = new Equation(coefficients);

            IEquationSolver solver = cmbMethod.SelectedIndex switch
            {
                0 => new BisectionSolver(),
                1 => new NewtonSolver(),
                2 => new AlgebraicSolver(),
                _ => null
            };

            if (solver == null) return;

            string methodName = cmbMethod.SelectedItem.ToString();
            var result = solver.Solve(
                _currentEquation,
                new Complex(initReal, initImag),
                epsilon,
                maxIterations);

            _lastResult = result.Root;
            _isSolved = true;

            string sign = _lastResult.Imaginary < 0 ? "-" : "+";
            string rootStr = $"{_lastResult.Real:F4} {sign} {Math.Abs(_lastResult.Imaginary):F4}i";

            _lastReport = ComplexityAnalyzer.GetComplexityReport(
                methodName, result.Iterations, result.Success);

            txtResult.Text = $"Root: {rootStr}\n\n{_lastReport}";
            PlotGraph(_currentEquation);
        }

        //Зберегти 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_isSolved)
            {
                MessageBox.Show(
                    "Please solve the equation first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Text Documents|*.txt",
                Title = "Save result"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string sign = _lastResult.Imaginary < 0 ? "-" : "+";
                    string rootStr =
                        $"{_lastResult.Real:F4} {sign} {Math.Abs(_lastResult.Imaginary):F4}i";

                    string content =
                        $"Equation (coefficients): {txtCoefficients.Text}\n" +
                        $"Formula: {lblFormula.Text}\n" +
                        $"Method: {cmbMethod.SelectedItem}\n" +
                        $"Initial approximation: {txtInitialReal.Text} + {txtInitialImag.Text}i\n" +
                        $"Accuracy (epsilon): {txtEpsilon.Text}\n" +
                        $"Max iterations: {txtMaxIterations.Text}\n\n" +
                        $"Found root: {rootStr}\n\n" +
                        $"{_lastReport}";

                    FileService.SaveResult(sfd.FileName, content);
                    MessageBox.Show(
                        "Result saved successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //Очистити 

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCoefficients.Clear();
            txtResult.Clear();
            txtEpsilon.Text = "0.0001";
            txtMaxIterations.Text = "1000";
            txtInitialReal.Text = "1";
            txtInitialImag.Text = "1";
            cmbMethod.SelectedIndex = 0;
            lblFormula.Text = "";
            _isSolved = false;
            chartEquation.Series.Clear();
        }

        // Графік

        private void PlotGraph(Equation eq)
        {
            chartEquation.Series.Clear();

            chartEquation.BackColor = Color.MidnightBlue;
            chartEquation.BorderlineColor = Color.MidnightBlue;
            chartEquation.ChartAreas[0].BackColor = Color.White;
            chartEquation.ChartAreas[0].ShadowColor = Color.Transparent;
            chartEquation.ChartAreas[0].AxisX.LineColor = Color.Azure;
            chartEquation.ChartAreas[0].AxisY.LineColor = Color.Azure;
            chartEquation.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Azure;
            chartEquation.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Azure;
            chartEquation.ChartAreas[0].AxisX.TitleForeColor = Color.Azure;
            chartEquation.ChartAreas[0].AxisY.TitleForeColor = Color.Azure;
            chartEquation.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(70, 74, 95);
            chartEquation.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(70, 74, 95);
            chartEquation.ChartAreas[0].AxisX.Title = "x";
            chartEquation.ChartAreas[0].AxisY.Title = "f(x)";
            chartEquation.Legends[0].BackColor = Color.MidnightBlue;
            chartEquation.Legends[0].ForeColor = Color.Azure;

            var series = new System.Windows.Forms.DataVisualization.Charting.Series("f(x)");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Color = Color.HotPink;
            series.BorderWidth = 2;

            for (double x = -10; x <= 10; x += 0.1)
            {
                Complex z = new Complex(x, 0);
                Complex y = eq.Evaluate(z);
                if (Math.Abs(y.Real) < 1000)
                    series.Points.AddXY(x, y.Real);
            }

            var zeroLine = new System.Windows.Forms.DataVisualization.Charting.Series("y=0");
            zeroLine.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            zeroLine.Color = Color.Azure;
            zeroLine.BorderWidth = 1;
            zeroLine.Points.AddXY(-10, 0);
            zeroLine.Points.AddXY(10, 0);

            chartEquation.Series.Add(series);
            chartEquation.Series.Add(zeroLine);
        }

        //Закриття форми

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to exit?\nUnsaved results will be lost.",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;
        }
    }
}