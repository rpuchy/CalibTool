using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

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

        private double correlation(List<double> Var1, List<double> Var2)
        {
            if (Var1.Count != Var2.Count)
                throw new ArgumentException("values must be the same length");

            var avg1 = Var1.Average();
            var avg2 = Var2.Average();

            var sum1 = Var1.Zip(Var2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = Var1.Sum(x => Math.Pow((x - avg1), 2.0));
            var sumSqr2 = Var2.Sum(y => Math.Pow((y - avg2), 2.0));

            var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

            return result;

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
                    if ((values[0] != "" && values[1] != "" && values[2] != "" && values[3] != "")||(values[0]!="" &&values[4]!=""))
                    {
                        Mappings.Add(values[0],
                            new DataMap() {File = values[1], xPath = values[2], decimals = int.Parse(values[3]), overwrite = values[4]});
                    }
                }
            }

            Dictionary<string, ModelID> ModelMap = new Dictionary<string, ModelID>();
            //Load Model ID MAP
            using (var fs = File.OpenRead(@".\ModelIDMAP.csv"))
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
                    if (values[0] != "" && values[1] != "")
                    {
                        ModelMap.Add(values[0], new ModelID() { RangeName = values[1], VarName = values[2], timestep = int.Parse(values[3]), order = int.Parse(values[4]),LBound=Double.Parse(values[5]),UBound = Double.Parse(values[6])});
                    }
                }
            }


            MemoryStream documentStream;
            String templatePath = Path.Combine(Environment.CurrentDirectory, ReportTemplate.Text);
            string path = CalibrationReport.Text;
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            string xlOrigLoc = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Results.xlsx";

            string xlLoc = Path.GetTempPath() + "\\Results.xlsx";

            File.Copy(xlOrigLoc, xlLoc, true);

            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(xlLoc);
            Excel.Worksheet xlWorksheet;

            string OldCalib = Path.GetTempPath() + "\\OldCalib.csv";
            string NewCalib = Path.GetTempPath() + "\\NewCalib.csv";


            string OldCalibLocation = Path.GetTempPath() + Path.GetFileName(OldCalibFile.Text);
            ChangeScenarioFileLocation(OldCalibFile.Text, OldCalibLocation, Path.GetTempPath(), "Old_");
            string NewCalibLocation = Path.GetTempPath() + Path.GetFileName(NewCalibFile.Text);
            ChangeScenarioFileLocation(NewCalibFile.Text, NewCalibLocation, Path.GetTempPath(), "New_");

            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = "--forceoutput --testdata " + OldCalibLocation + " --compdata c:\\results.csv --csvresdata " + OldCalib;
            // Enter the executable to run, including the complete path
            start.FileName = UnitTextharness.Text;
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            int exitCode;
            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }

            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = "--forceoutput --testdata " + NewCalibLocation + " --compdata c:\\results.csv --csvresdata " + NewCalib;
            // Enter the executable to run, including the complete path
            start.FileName = UnitTextharness.Text;
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;

            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }





            //Now we need to process the scenario files.
            XmlDocument CalibXml = new XmlDocument();
            CalibXml.Load(OldCalibLocation);
            string xPathQuery_filename = "//ScenarioFile//FileName";
            string xPathQuery_ModelID = "//ScenarioFile//ModelId";
            XmlNodeList sfilenames = CalibXml.SelectNodes(xPathQuery_filename);
            XmlNodeList sModelIDs = CalibXml.SelectNodes(xPathQuery_ModelID);

            for (int i = 0; i < sfilenames.Count; i++)
            {
                string filename = sfilenames[i].InnerText;
                string modelid = sModelIDs[i].InnerText;
                ModelID temp;
                if (!ModelMap.TryGetValue(modelid, out temp))
                {
                    continue;
                }

                Double[,] HistData = HistogramData(filename, ModelMap[modelid].timestep, ModelMap[modelid].VarName,ModelMap[modelid].LBound,ModelMap[modelid].UBound);

                var rng = xlWorkbook.Names.Item("Old" + ModelMap[modelid].RangeName).RefersToRange;
                rng.Cells[1, 1] = HistData[0, 0];
                rng.Cells[2, 1] = HistData[1, 0];

                for (int j = 1; j < 50; j++)
                {
                    rng.Cells[1, j + 1] = HistData[0, j];
                    rng.Cells[2, j + 1] = HistData[1, j] - HistData[1, j - 1];
                }
            }

            CalibXml.Load(NewCalibLocation);
            sfilenames = CalibXml.SelectNodes(xPathQuery_filename);
            sModelIDs = CalibXml.SelectNodes(xPathQuery_ModelID);

            for (int i = 0; i < sfilenames.Count; i++)
            {
                string filename = sfilenames[i].InnerText;
                string modelid = sModelIDs[i].InnerText;
                ModelID temp;
                if (!ModelMap.TryGetValue(modelid, out temp))
                {
                    continue;
                }

                Double[,] HistData = HistogramData(filename, ModelMap[modelid].timestep, ModelMap[modelid].VarName, ModelMap[modelid].LBound, ModelMap[modelid].UBound);

                var rng = xlWorkbook.Names.Item("New" + ModelMap[modelid].RangeName).RefersToRange;
                rng.Cells[1, 1] = HistData[0, 0];
                rng.Cells[2, 1] = HistData[1, 0];

                for (int j = 1; j < 50; j++)
                {
                    rng.Cells[1, j + 1] = HistData[0, j];
                    rng.Cells[2, j + 1] = HistData[1, j] - HistData[1, j - 1];
                }
            }

            Excel.Workbook xlOldCalib = xlApp.Workbooks.Open(OldCalib);
            Excel.Range srcrange;

            Excel.Worksheet dstworkSheet = xlWorkbook.Worksheets.get_Item("OldCalib");
            var range = xlWorkbook.Names.Item("OldCalib").RefersToRange;
            range.ClearContents();
            Excel.Worksheet srcworkSheet = xlOldCalib.Worksheets.get_Item(1);
            srcrange = srcworkSheet.UsedRange;
            srcrange.Copy(Type.Missing);
            range.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, Type.Missing, Type.Missing);
            xlOldCalib.Close();

            dstworkSheet = xlWorkbook.Worksheets.get_Item("NewCalib");
            range = xlWorkbook.Names.Item("NewCalib").RefersToRange;
            range.ClearContents();
            Excel.Workbook xlNewCalib = xlApp.Workbooks.Open(NewCalib);
            srcworkSheet = xlNewCalib.Worksheets.get_Item(1);
            srcrange = srcworkSheet.UsedRange;
            srcrange.Copy(Type.Missing);
            range.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, Type.Missing, Type.Missing);
            xlNewCalib.Close();

            srcrange = dstworkSheet.get_Range("A1:A1");
            srcrange.Copy(Type.Missing);

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
                    if (item.Value.overwrite != "")
                    {
                        item.Value.Value = item.Value.overwrite;
                        continue;
                    }
                    if (item.Value.File == "OldCalibFile" || item.Value.File == "NewCalibFile")
                    {
                        
                        XmlDocument fileToUse;
                        if (item.Value.File != "" && item.Value.xPath != "")
                        {
                            if (item.Value.File == "OldCalibFile")
                            {
                                fileToUse = OldCalibXml;
                            }
                            else
                            {
                                fileToUse = NewCalibXml;
                            }
                            XmlNode temp = fileToUse.SelectSingleNode(item.Value.xPath);

                            if (temp != null && item.Value.decimals >= 0)
                            {
                                item.Value.Value = Math.Round(Double.Parse(temp.InnerText), item.Value.decimals).ToString();
                            }
                            else
                            {
                                if (temp!=null && item.Value.decimals == -1)
                                {
                                    //we are using -1 as a full date conversion
                                    DateTime dt = Convert.ToDateTime(temp.InnerText);
                                    item.Value.Value = dt.ToString("dd MMMM yyyy");
                                }
                                else
                                {
                                    item.Value.Value = temp?.InnerText;
                                }
                                
                            }

                            
                        }
                    }
                    if (item.Value.File == "OutputFile")
                    {
                        //strip square brackets off end
                        Regex SquareBrackets = new Regex("\\[(.*?)]");

                        Match msbrackets = SquareBrackets.Match(item.Value.xPath);

                        var Cells = msbrackets.Value.Trim(new char[] {'[', ']'}).Split('|');

                        string RangeName = SquareBrackets.Replace(item.Value.xPath, "");

                        var RangeData = xlWorkbook.Names.Item(RangeName).RefersToRange.Value;

                        if (item.Value.decimals >= 0)
                        {
                            item.Value.Value = Math.Round(RangeData[int.Parse(Cells[0]), int.Parse(Cells[1])], item.Value.decimals).ToString();
                        }
                        else
                        {
                            item.Value.Value = RangeData[int.Parse(Cells[0]), int.Parse(Cells[1])].ToString();
                        }

                       


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

               
                using (StreamWriter sw = new StreamWriter(template.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
            //We are going to do the charts afterwards because we need to paste the images in interop.
            Word.Application wordApp = new Word.Application();
            wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            string ReportLoc = CalibrationReport.Text;
            Word.Document wrdDocument = wordApp.Documents.Open(ReportLoc);

            foreach (var item in Mappings)
            {
               if (item.Value.File == "Chart")
               {
                   //try
                   //{
                       xlWorksheet = xlWorkbook.Worksheets.get_Item(item.Value.xPath.Split('_')[0]);
                       xlWorksheet.Select();
                       var rng_temp = xlWorksheet.get_Range("A1", "A1");
                       rng_temp.Select();
                       Excel.ChartObject chartObject =
                           (Excel.ChartObject) xlWorksheet.ChartObjects(item.Value.xPath.Split('_')[1]);

                       chartObject.Chart.ChartArea.Copy();
                       Word.Range rng = wrdDocument.Bookmarks[item.Key.Trim('@')].Range;
                       rng.PasteSpecial(Type.Missing, Type.Missing,
                           Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                  // }
                  // catch (Exception e1)
                  // {
                       //make a note of errors
                 //  }

               }

            }





            CalibXml = new XmlDocument();
            OldCalibLocation = Path.GetTempPath() + Path.GetFileName(OldCalibFile.Text);
            CalibXml.Load(OldCalibLocation);
            xPathQuery_filename = "//ScenarioFile//FileName";
            xPathQuery_ModelID = "//ScenarioFile//ModelId";
            sfilenames = CalibXml.SelectNodes(xPathQuery_filename);
            sModelIDs = CalibXml.SelectNodes(xPathQuery_ModelID);

            for (int i = 0; i < sfilenames.Count; i++)
            {
                string filename = sfilenames[i].InnerText;
                string modelid = sModelIDs[i].InnerText;
                ModelID temp;
                if (!ModelMap.TryGetValue(modelid, out temp))
                {
                    continue;
                }

                List<double> ScenarioData = new List<double>();

                using (var fs = File.OpenRead(filename))
                using (var reader = new StreamReader(fs))
                {
                    //skip the first line
                    var header = reader.ReadLine().Split(',');
                    //Figure out the index to use
                    int headertouse = 0;
                    for (int j = 0; j < header.Length; j++)
                    {
                        if (header[j] == ModelMap[modelid].VarName)
                        {
                            headertouse = j;
                        }

                    }
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (int.Parse(values[1]) == ModelMap[modelid].timestep)
                            ScenarioData.Add(Double.Parse(values[headertouse]));
                    }
                    ModelMap[modelid].ScenarioData = ScenarioData;
                }
            }


            Word.Range rng2 = wrdDocument.Bookmarks["CORRELATIONMATRIX"].Range;

            Word.Table CorrTable = rng2.Tables[1];

            foreach (var kvp in ModelMap)
            {
                foreach (var kvp2 in ModelMap)
                {
                    if (kvp.Value.order < kvp2.Value.order)
                    {
                        CorrTable.Cell(1 + kvp.Value.order, 1 + kvp2.Value.order).Range.Text =
                            Math.Round(correlation(kvp.Value.ScenarioData, kvp2.Value.ScenarioData), 2).ToString();
                    }
                }

            }


            wrdDocument.Save();
            wrdDocument.Close(Type.Missing,Type.Missing,Type.Missing);
            wordApp.Quit();  
            xlWorkbook.Close();
            xlApp.Quit();            
            
            // Run Word to open the document:
            System.Diagnostics.Process.Start(path);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
    
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
         
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Word Document files (*.docx)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CalibrationReport.Text = saveFileDialog1.FileName;
            }
        }

        private void ChangeScenarioFileLocation(string inCalibrationFile, string outCalibrationFile, string newLocation, string prefix = "")
        {
            //first we need to change the output location of the scenario files
            XmlDocument CalibXml = new XmlDocument();
            CalibXml.Load(inCalibrationFile);
            string xPathQuery = "//ScenarioFiles//FileName";
            XmlNodeList temp = CalibXml.SelectNodes(xPathQuery);
            foreach (XmlNode _node in temp)
            {
                _node.InnerText = newLocation + prefix+ Path.GetFileName(_node.InnerText);
            }
            
            CalibXml.Save(outCalibrationFile);
        }


        private Double[,] HistogramData(string filename, int timestep, string Variable, double LBound, double UBound)
        {
            List<double> ScenarioData = new List<double>();
            Double[,] Result = new Double[2,50];
            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                //skip the first line
                var header = reader.ReadLine().Split(',');
                //Figure out the index to use
                int headertouse = 0;
                for (int j = 0; j < header.Length; j++)
                {
                    if (header[j] == Variable)
                    {
                        headertouse = j;
                    }

                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (int.Parse(values[1]) == timestep)
                    {
                        var val = double.Parse(values[headertouse]);
                        if (val < UBound && val > LBound)
                        {
                            ScenarioData.Add(val);
                        }
                    }
                }
                //now process the data.
                ScenarioData.Sort();
                double min = LBound;
                double max = UBound;
                double bucketsize = (max - min) / 50;
                List<Double> Buckets = new List<double>();
                Buckets.Add(min + bucketsize);
                for (int j = 1; j < 50; j++)
                {
                    Buckets.Add(Buckets[j - 1] + bucketsize);
                }
                //Now we count
                List<Double> Percentages = new List<double>();
                double boundary = Buckets[0];
                
                for (int j = 0; j < ScenarioData.Count; j++)
                {
                    if (boundary <= ScenarioData[j])
                    {
                        Percentages.Add((double) j / ScenarioData.Count);
                        boundary = Buckets[Math.Min(Percentages.Count,Buckets.Count-1)];
                    }
                }
                //Finish up to 50 buckets.
                for (int j = Percentages.Count; j < 50; j++)
                {
                    Percentages.Add(1);
                }
                for (int j = 0; j < 50; j++)
                {
                    Result[0, j]=Buckets[j];
                    Result[1, j] = Percentages[j];
                }
            }                       
            return Result;
            }

        private void button7_Click(object sender, EventArgs e)
        {

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Unit Test harness (UnitTestHarenss.exe)|UnitTestHarness.exe|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                UnitTextharness.Text = openFileDialog1.FileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
  
        }
    }
}
