using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;

namespace CalibrationDocumentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void CopyStream(Stream source, Stream target)
        {
            if (source != null)
            {
                MemoryStream mstream = source as MemoryStream;
                if (mstream != null) mstream.WriteTo(target);
                else
                {
                    byte[] buffer = new byte[2048];
                    int length = buffer.Length, size;
                    while ((size = source.Read(buffer, 0, length)) != 0)
                        target.Write(buffer, 0, size);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryStream documentStream;
            String templatePath = Path.Combine(Environment.CurrentDirectory, @"C:\test\Calibration report templatev2.docx");
            string path = @"C:\test\NewDoc.docx";

            File.Copy(templatePath, path,true);

            using (Stream tplStream = File.OpenRead(path))
            {
                documentStream = new MemoryStream((int)tplStream.Length);
                CopyStream(tplStream, documentStream);
                documentStream.Position = 0L;
            }
            
            using (WordprocessingDocument template = WordprocessingDocument.Open(path, true))
            {

                string docText = null;

                using (StreamReader sr = new StreamReader(template.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }
                                
                Regex regexText = new Regex("Chart 1");
                docText = regexText.Replace(docText, "I have replaced the chart now");

                using (StreamWriter sw = new StreamWriter(template.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }

            // Run Word to open the document:
            System.Diagnostics.Process.Start(path);
        }

    }
}
