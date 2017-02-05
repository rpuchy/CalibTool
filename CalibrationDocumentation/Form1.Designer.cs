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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(724, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 98);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 514);
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
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Calibration File";
            // 
            // NewCalibFile
            // 
            this.NewCalibFile.Location = new System.Drawing.Point(345, 102);
            this.NewCalibFile.Name = "NewCalibFile";
            this.NewCalibFile.Size = new System.Drawing.Size(928, 31);
            this.NewCalibFile.TabIndex = 3;
            this.NewCalibFile.Text = "C:\\Code\\CalibTool\\CalibrationDocumentation\\NewCalib.xml";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1291, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1291, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 31);
            this.button4.TabIndex = 7;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OldCalibFile
            // 
            this.OldCalibFile.Location = new System.Drawing.Point(345, 184);
            this.OldCalibFile.Name = "OldCalibFile";
            this.OldCalibFile.Size = new System.Drawing.Size(928, 31);
            this.OldCalibFile.TabIndex = 6;
            this.OldCalibFile.Text = "C:\\Code\\CalibTool\\CalibrationDocumentation\\OldCalib.xml";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Old Calibration File";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1291, 271);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 31);
            this.button5.TabIndex = 10;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ReportTemplate
            // 
            this.ReportTemplate.Location = new System.Drawing.Point(345, 271);
            this.ReportTemplate.Name = "ReportTemplate";
            this.ReportTemplate.Size = new System.Drawing.Size(928, 31);
            this.ReportTemplate.TabIndex = 9;
            this.ReportTemplate.Text = "C:\\Code\\CalibTool\\CalibrationDocumentation\\Calibration report template.docx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Report template";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1291, 361);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 31);
            this.button6.TabIndex = 13;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // CalibrationReport
            // 
            this.CalibrationReport.Location = new System.Drawing.Point(345, 361);
            this.CalibrationReport.Name = "CalibrationReport";
            this.CalibrationReport.Size = new System.Drawing.Size(928, 31);
            this.CalibrationReport.TabIndex = 12;
            this.CalibrationReport.Text = "c:\\test\\Calibration Report.docx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Calibration Report";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 697);
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
    }
}

