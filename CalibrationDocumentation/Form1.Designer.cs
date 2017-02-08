namespace CalibrationDocumentation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NewCalibFile = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.OldCalibFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.ReportTemplate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.CalibrationReport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.UnitTextharness = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 513);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 98);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(406, 513);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 98);
            this.button2.TabIndex = 1;
            this.button2.Text = "Generate Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Calibration File";
            // 
            // NewCalibFile
            // 
            this.NewCalibFile.Location = new System.Drawing.Point(344, 102);
            this.NewCalibFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewCalibFile.Name = "NewCalibFile";
            this.NewCalibFile.Size = new System.Drawing.Size(928, 31);
            this.NewCalibFile.TabIndex = 3;
            this.NewCalibFile.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\NewCalib.xml";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1292, 102);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1292, 185);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 31);
            this.button4.TabIndex = 7;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OldCalibFile
            // 
            this.OldCalibFile.Location = new System.Drawing.Point(344, 185);
            this.OldCalibFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OldCalibFile.Name = "OldCalibFile";
            this.OldCalibFile.Size = new System.Drawing.Size(928, 31);
            this.OldCalibFile.TabIndex = 6;
            this.OldCalibFile.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\OldCalib.xml";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Old Calibration File";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1292, 271);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 31);
            this.button5.TabIndex = 10;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ReportTemplate
            // 
            this.ReportTemplate.Location = new System.Drawing.Point(344, 271);
            this.ReportTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReportTemplate.Name = "ReportTemplate";
            this.ReportTemplate.Size = new System.Drawing.Size(928, 31);
            this.ReportTemplate.TabIndex = 9;
            this.ReportTemplate.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\Calibration report template.docx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Report template";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1292, 362);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(76, 31);
            this.button6.TabIndex = 13;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // CalibrationReport
            // 
            this.CalibrationReport.Location = new System.Drawing.Point(344, 362);
            this.CalibrationReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CalibrationReport.Name = "CalibrationReport";
            this.CalibrationReport.Size = new System.Drawing.Size(928, 31);
            this.CalibrationReport.TabIndex = 12;
            this.CalibrationReport.Text = "c:\\temp\\Calibration Report.docx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 367);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Calibration Report";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(115, 513);
            this.button7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(258, 98);
            this.button7.TabIndex = 14;
            this.button7.Text = "runEngine";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 442);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Unit Test Harnress";
            // 
            // UnitTextharness
            // 
            this.UnitTextharness.Location = new System.Drawing.Point(344, 429);
            this.UnitTextharness.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UnitTextharness.Name = "UnitTextharness";
            this.UnitTextharness.Size = new System.Drawing.Size(928, 31);
            this.UnitTextharness.TabIndex = 16;
            this.UnitTextharness.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\UnitTestHarness.exe";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1292, 429);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(76, 38);
            this.button8.TabIndex = 17;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(984, 513);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(248, 98);
            this.button9.TabIndex = 18;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 696);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.UnitTextharness);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.CalibrationReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ReportTemplate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.OldCalibFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.NewCalibFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Calibration Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewCalibFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox OldCalibFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox ReportTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox CalibrationReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UnitTextharness;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

