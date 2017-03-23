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
            this.label5 = new System.Windows.Forms.Label();
            this.UnitTextharness = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ScenarioOutput = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 334);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 334);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "Generate Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Calibration File";
            // 
            // NewCalibFile
            // 
            this.NewCalibFile.Location = new System.Drawing.Point(172, 53);
            this.NewCalibFile.Margin = new System.Windows.Forms.Padding(2);
            this.NewCalibFile.Name = "NewCalibFile";
            this.NewCalibFile.Size = new System.Drawing.Size(466, 20);
            this.NewCalibFile.TabIndex = 3;
            this.NewCalibFile.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\NewCalib.xml";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(646, 53);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 16);
            this.button3.TabIndex = 4;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(646, 96);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 16);
            this.button4.TabIndex = 7;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OldCalibFile
            // 
            this.OldCalibFile.Location = new System.Drawing.Point(172, 96);
            this.OldCalibFile.Margin = new System.Windows.Forms.Padding(2);
            this.OldCalibFile.Name = "OldCalibFile";
            this.OldCalibFile.Size = new System.Drawing.Size(466, 20);
            this.OldCalibFile.TabIndex = 6;
            this.OldCalibFile.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\OldCalib.xml";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Old Calibration File";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(646, 141);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 16);
            this.button5.TabIndex = 10;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ReportTemplate
            // 
            this.ReportTemplate.Location = new System.Drawing.Point(172, 141);
            this.ReportTemplate.Margin = new System.Windows.Forms.Padding(2);
            this.ReportTemplate.Name = "ReportTemplate";
            this.ReportTemplate.Size = new System.Drawing.Size(466, 20);
            this.ReportTemplate.TabIndex = 9;
            this.ReportTemplate.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\Calibration report template.docx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Report template";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(646, 188);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(38, 16);
            this.button6.TabIndex = 13;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // CalibrationReport
            // 
            this.CalibrationReport.Location = new System.Drawing.Point(172, 188);
            this.CalibrationReport.Margin = new System.Windows.Forms.Padding(2);
            this.CalibrationReport.Name = "CalibrationReport";
            this.CalibrationReport.Size = new System.Drawing.Size(466, 20);
            this.CalibrationReport.TabIndex = 12;
            this.CalibrationReport.Text = "c:\\temp\\Calibration Report.docx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Calibration Report";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Unit Test Harnress";
            // 
            // UnitTextharness
            // 
            this.UnitTextharness.Location = new System.Drawing.Point(172, 223);
            this.UnitTextharness.Margin = new System.Windows.Forms.Padding(2);
            this.UnitTextharness.Name = "UnitTextharness";
            this.UnitTextharness.Size = new System.Drawing.Size(466, 20);
            this.UnitTextharness.TabIndex = 16;
            this.UnitTextharness.Text = "C:\\Git\\CalibTool\\CalibrationDocumentation\\UnitTestHarness.exe";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(646, 223);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 20);
            this.button8.TabIndex = 17;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Scenario File Location";
            // 
            // ScenarioOutput
            // 
            this.ScenarioOutput.Location = new System.Drawing.Point(173, 259);
            this.ScenarioOutput.Name = "ScenarioOutput";
            this.ScenarioOutput.Size = new System.Drawing.Size(465, 20);
            this.ScenarioOutput.TabIndex = 19;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(646, 259);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 20);
            this.button7.TabIndex = 20;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 452);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.ScenarioOutput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.UnitTextharness);
            this.Controls.Add(this.label5);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UnitTextharness;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ScenarioOutput;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

