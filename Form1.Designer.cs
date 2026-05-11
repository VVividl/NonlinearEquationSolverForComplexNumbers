namespace kursova
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtCoefficients = new TextBox();
            cmbMethod = new ComboBox();
            txtResult = new RichTextBox();
            btnSolve = new Button();
            btnSave = new Button();
            txtEpsilon = new TextBox();
            txtMaxIterations = new TextBox();
            txtInitialReal = new TextBox();
            txtInitialImag = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblTitle = new Label();
            lblResultHeader = new Label();
            panelInput = new Panel();
            lblFormula = new Label();
            panelButtons = new Panel();
            btnClear = new Button();
            panelResult = new Panel();
            chartEquation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelInput.SuspendLayout();
            panelButtons.SuspendLayout();
            panelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartEquation).BeginInit();
            SuspendLayout();
            // 
            // txtCoefficients
            // 
            txtCoefficients.BackColor = Color.DarkSlateBlue;
            txtCoefficients.BorderStyle = BorderStyle.FixedSingle;
            txtCoefficients.Font = new Font("Comic Sans MS", 10F);
            txtCoefficients.ForeColor = Color.FromArgb(220, 224, 240);
            txtCoefficients.Location = new Point(453, 32);
            txtCoefficients.Name = "txtCoefficients";
            txtCoefficients.Size = new Size(753, 45);
            txtCoefficients.TabIndex = 0;
            // 
            // cmbMethod
            // 
            cmbMethod.BackColor = Color.DarkSlateBlue;
            cmbMethod.FlatStyle = FlatStyle.Flat;
            cmbMethod.Font = new Font("Comic Sans MS", 10F);
            cmbMethod.ForeColor = Color.FromArgb(220, 224, 240);
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Location = new Point(453, 157);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(753, 46);
            cmbMethod.TabIndex = 1;
            // 
            // txtResult
            // 
            txtResult.BackColor = Color.DarkSlateBlue;
            txtResult.BorderStyle = BorderStyle.None;
            txtResult.Font = new Font("Consolas", 10F);
            txtResult.ForeColor = Color.FromArgb(220, 224, 240);
            txtResult.Location = new Point(16, 49);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(1190, 252);
            txtResult.TabIndex = 9;
            txtResult.Text = "";
            // 
            // btnSolve
            // 
            btnSolve.BackColor = Color.FromArgb(0, 191, 255);
            btnSolve.Cursor = Cursors.Hand;
            btnSolve.FlatAppearance.BorderSize = 0;
            btnSolve.FlatStyle = FlatStyle.Flat;
            btnSolve.Font = new Font("Comic Sans MS", 11F, FontStyle.Bold);
            btnSolve.ForeColor = Color.Azure;
            btnSolve.Location = new Point(16, 8);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(294, 46);
            btnSolve.TabIndex = 6;
            btnSolve.Text = "▶  Solve";
            btnSolve.UseVisualStyleBackColor = false;
            btnSolve.Click += btnSolve_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(72, 199, 142);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Comic Sans MS", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.Azure;
            btnSave.Location = new Point(476, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(294, 46);
            btnSave.TabIndex = 7;
            btnSave.Text = "💾  Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtEpsilon
            // 
            txtEpsilon.BackColor = Color.DarkSlateBlue;
            txtEpsilon.BorderStyle = BorderStyle.FixedSingle;
            txtEpsilon.Font = new Font("Comic Sans MS", 10F);
            txtEpsilon.ForeColor = Color.FromArgb(220, 224, 240);
            txtEpsilon.Location = new Point(453, 289);
            txtEpsilon.Name = "txtEpsilon";
            txtEpsilon.Size = new Size(753, 45);
            txtEpsilon.TabIndex = 4;
            txtEpsilon.Text = "0.0001";
            // 
            // txtMaxIterations
            // 
            txtMaxIterations.BackColor = Color.DarkSlateBlue;
            txtMaxIterations.BorderStyle = BorderStyle.FixedSingle;
            txtMaxIterations.Font = new Font("Comic Sans MS", 10F);
            txtMaxIterations.ForeColor = Color.FromArgb(220, 224, 240);
            txtMaxIterations.Location = new Point(453, 358);
            txtMaxIterations.Name = "txtMaxIterations";
            txtMaxIterations.Size = new Size(753, 45);
            txtMaxIterations.TabIndex = 5;
            txtMaxIterations.Text = "1000";
            // 
            // txtInitialReal
            // 
            txtInitialReal.BackColor = Color.DarkSlateBlue;
            txtInitialReal.BorderStyle = BorderStyle.FixedSingle;
            txtInitialReal.Font = new Font("Comic Sans MS", 10F);
            txtInitialReal.ForeColor = Color.FromArgb(220, 224, 240);
            txtInitialReal.Location = new Point(453, 227);
            txtInitialReal.Name = "txtInitialReal";
            txtInitialReal.Size = new Size(278, 45);
            txtInitialReal.TabIndex = 2;
            txtInitialReal.Text = "1";
            // 
            // txtInitialImag
            // 
            txtInitialImag.BackColor = Color.DarkSlateBlue;
            txtInitialImag.BorderStyle = BorderStyle.FixedSingle;
            txtInitialImag.Font = new Font("Comic Sans MS", 10F);
            txtInitialImag.ForeColor = Color.FromArgb(220, 224, 240);
            txtInitialImag.Location = new Point(882, 226);
            txtInitialImag.Name = "txtInitialImag";
            txtInitialImag.Size = new Size(324, 45);
            txtInitialImag.TabIndex = 3;
            txtInitialImag.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Comic Sans MS", 10F);
            label1.ForeColor = Color.Azure;
            label1.Location = new Point(16, 32);
            label1.Name = "label1";
            label1.Size = new Size(385, 38);
            label1.TabIndex = 0;
            label1.Text = "Coefficients (e.g.: 1, 2i, 3+4i):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Comic Sans MS", 10F);
            label2.ForeColor = Color.Azure;
            label2.Location = new Point(16, 165);
            label2.Name = "label2";
            label2.Size = new Size(122, 38);
            label2.TabIndex = 1;
            label2.Text = "Method:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Comic Sans MS", 10F);
            label3.ForeColor = Color.Azure;
            label3.Location = new Point(16, 233);
            label3.Name = "label3";
            label3.Size = new Size(326, 38);
            label3.TabIndex = 2;
            label3.Text = "Initial approximation Re:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Comic Sans MS", 10F);
            label4.ForeColor = Color.Azure;
            label4.Location = new Point(799, 234);
            label4.Name = "label4";
            label4.Size = new Size(61, 38);
            label4.TabIndex = 3;
            label4.Text = "Im:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Comic Sans MS", 10F);
            label5.ForeColor = Color.Azure;
            label5.Location = new Point(16, 296);
            label5.Name = "label5";
            label5.Size = new Size(254, 38);
            label5.TabIndex = 4;
            label5.Text = "Accuracy (epsilon):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Comic Sans MS", 10F);
            label6.ForeColor = Color.Azure;
            label6.Location = new Point(16, 365);
            label6.Name = "label6";
            label6.Size = new Size(209, 38);
            label6.TabIndex = 5;
            label6.Text = "Max iterations:";
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Comic Sans MS", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Azure;
            lblTitle.Location = new Point(20, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1047, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Nonlinear Equation Solver For Complex Numbers ";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblResultHeader
            // 
            lblResultHeader.AutoSize = true;
            lblResultHeader.BackColor = Color.Transparent;
            lblResultHeader.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold);
            lblResultHeader.ForeColor = Color.Azure;
            lblResultHeader.Location = new Point(16, 0);
            lblResultHeader.Name = "lblResultHeader";
            lblResultHeader.Size = new Size(109, 38);
            lblResultHeader.TabIndex = 0;
            lblResultHeader.Text = "Results";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.MidnightBlue;
            panelInput.Controls.Add(label1);
            panelInput.Controls.Add(txtCoefficients);
            panelInput.Controls.Add(label2);
            panelInput.Controls.Add(cmbMethod);
            panelInput.Controls.Add(label3);
            panelInput.Controls.Add(txtInitialReal);
            panelInput.Controls.Add(label4);
            panelInput.Controls.Add(txtInitialImag);
            panelInput.Controls.Add(label5);
            panelInput.Controls.Add(txtEpsilon);
            panelInput.Controls.Add(label6);
            panelInput.Controls.Add(txtMaxIterations);
            panelInput.Controls.Add(lblFormula);
            panelInput.Location = new Point(20, 75);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1225, 427);
            panelInput.TabIndex = 1;
            // 
            // lblFormula
            // 
            lblFormula.BackColor = Color.Transparent;
            lblFormula.Font = new Font("Comic Sans MS", 10F, FontStyle.Italic);
            lblFormula.ForeColor = Color.HotPink;
            lblFormula.Location = new Point(16, 103);
            lblFormula.Name = "lblFormula";
            lblFormula.Size = new Size(540, 51);
            lblFormula.TabIndex = 20;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(btnSolve);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnClear);
            panelButtons.Location = new Point(20, 508);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1225, 63);
            panelButtons.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.HotPink;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Comic Sans MS", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.Azure;
            btnClear.Location = new Point(912, 8);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(294, 46);
            btnClear.TabIndex = 8;
            btnClear.Text = "✕  Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // panelResult
            // 
            panelResult.BackColor = Color.MidnightBlue;
            panelResult.Controls.Add(lblResultHeader);
            panelResult.Controls.Add(txtResult);
            panelResult.Location = new Point(20, 577);
            panelResult.Name = "panelResult";
            panelResult.Size = new Size(1225, 315);
            panelResult.TabIndex = 3;
            // 
            // chartEquation
            // 
            chartEquation.BackColor = Color.MidnightBlue;
            chartEquation.BorderlineColor = Color.MidnightBlue;
            chartArea1.AxisX.LabelStyle.ForeColor = Color.MidnightBlue;
            chartArea1.AxisX.LineColor = Color.MidnightBlue;
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(200, 200, 230);
            chartArea1.AxisX.Title = "x";
            chartArea1.AxisX.TitleForeColor = Color.MidnightBlue;
            chartArea1.AxisY.LabelStyle.ForeColor = Color.MidnightBlue;
            chartArea1.AxisY.LineColor = Color.MidnightBlue;
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(200, 200, 230);
            chartArea1.AxisY.Title = "f(x)";
            chartArea1.AxisY.TitleForeColor = Color.MidnightBlue;
            chartArea1.BackColor = Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = Color.Transparent;
            chartEquation.ChartAreas.Add(chartArea1);
            legend1.BackColor = Color.FromArgb(38, 41, 55);
            legend1.ForeColor = Color.FromArgb(220, 224, 240);
            legend1.Name = "Legend1";
            chartEquation.Legends.Add(legend1);
            chartEquation.Location = new Point(1260, 75);
            chartEquation.Name = "chartEquation";
            chartEquation.Size = new Size(940, 817);
            chartEquation.TabIndex = 4;
            chartEquation.Text = "chartEquation";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 40);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(2220, 910);
            Controls.Add(chartEquation);
            Controls.Add(lblTitle);
            Controls.Add(panelInput);
            Controls.Add(panelButtons);
            Controls.Add(panelResult);
            Font = new Font("Comic Sans MS", 10F);
            ForeColor = SystemColors.ActiveCaptionText;
            MinimumSize = new Size(920, 830);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nonlinear Equation Solver | KPI";
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelResult.ResumeLayout(false);
            panelResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartEquation).EndInit();
            ResumeLayout(false);
        }

        private TextBox txtCoefficients;
        private ComboBox cmbMethod;
        private RichTextBox txtResult;
        private Button btnSolve;
        private Button btnSave;
        private Button btnClear;
        private TextBox txtEpsilon;
        private TextBox txtMaxIterations;
        private TextBox txtInitialReal;
        private TextBox txtInitialImag;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblTitle;
        private Label lblResultHeader;
        private Panel panelInput;
        private Panel panelButtons;
        private Panel panelResult;
        private Label lblFormula;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEquation;
    }
}