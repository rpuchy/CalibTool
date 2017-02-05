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
using System.Xml;
using System.Xml.XPath;

namespace CalibrationDocumentation
{
    public partial class Form1 : Form
    {

        private Dictionary<String, DataMap> Mappings;

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
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mappings = new Dictionary<string, DataMap>();
            using (var fs = File.OpenRead(@".\OutputMap.csv"))
            using (var reader = new StreamReader(fs))
            {
                //skip the first line
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //remove whitespace from items.
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();
                    }
                    Mappings.Add(values[0], new DataMap() {File=values[1] , xPath= values[2]});
                }
            }


            MemoryStream documentStream;
            String templatePath = Path.Combine(Environment.CurrentDirectory, ReportTemplate.Text);
            string path = CalibrationReport.Text;

            File.Copy(templatePath, path, true);

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

                
                XmlDocument OldCalibXml = new XmlDocument();
                XmlDocument NewCalibXml = new XmlDocument();
                OldCalibXml.Load(OldCalibFile.Text);
                NewCalibXml.Load(NewCalibFile.Text);

                foreach (var item in Mappings)
                {
                    XmlDocument fileToUse;
                    if (item.Value.File != "" && item.Value.xPath != "")
                    {
                        if (item.Value.File == "OldFile")
                        {
                            fileToUse = OldCalibXml;
                        }
                        else
                        {
                            fileToUse = NewCalibXml;
                        }
                        XmlNode temp = fileToUse.SelectSingleNode(item.Value.xPath);

                        item.Value.Value = temp?.InnerText;
                    }


                }
                //find all text encapsulated by @@ signs
                Regex regexText = new Regex("@@(.*?)@@");

                Match m = regexText.Match(docText);

                Regex angleBrackets = new Regex("<(.*?)>");

                string clean;
                DataMap val;
                while (m.Success)
                {
                    regexText = new Regex(m.Value);
                    clean = angleBrackets.Replace(m.Value, "");
                    if (Mappings.TryGetValue(clean,out val))
                    {
                        if (val.Value != null)
                        {
                            docText = regexText.Replace(docText, val.Value);
                        }
                    }
                    m = m.NextMatch();
                }

                
                //docText = regexText.Replace(docText, val);
                
                using (StreamWriter sw = new StreamWriter(template.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }

            // Run Word to open the document:
            System.Diagnostics.Process.Start(path);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NewCalibFile.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OldCalibFile.Text = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Word Document files (*.docx)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReportTemplate.Text = openFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Word Document files (*.docx)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CalibrationReport.Text = saveFileDialog1.FileName;
            }
        }
    }
}
