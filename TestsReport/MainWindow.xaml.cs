using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace TestsReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentReportFile;

        public MainWindow()
        {
            InitializeComponent();
            FindPaths();
            var reportFile = FindReport();
            currentReportFile = reportFile;
        }

        private void FindPaths()
        {
            try
            {
                var nunitPath = "";
                var path = "";
                do
                {
                    var packages = Path.Combine(path, "packages");
                    if (Directory.Exists(packages))
                    {
                        var dir = Directory.GetDirectories(packages).FirstOrDefault(v => Path.GetFileName(v).StartsWith("NUnit.ConsoleRunner"));
                        if (dir != null)
                        {
                            var f = Path.Combine(dir, "tools", "nunit3-console.exe");
                            if (File.Exists(f))
                            {
                                nunitPath = f;
                            }
                        }
                    }
                    path = Path.Combine(path, "..");
                    if (!Directory.Exists(path)) break;
                }
                while (nunitPath == "");
                tbNunitConsole.Text = nunitPath == "" ? "no nunit3-console.exe" : nunitPath;
            }
            catch (Exception ex)
            {
                tbNunitConsole.Text = ex.ToString();
            }
            try
            {
                var testDllPath = "";
                var path = "";
                do
                {
                    var testProj = Path.Combine(path, "AsyncWebDriver.SeleniumAdapter.Common.Tests");
                    if (Directory.Exists(testProj))
                    {

                        var f = Path.Combine(testProj, "bin", "Debug", "AsyncWebDriver.SeleniumAdapter.Common.Tests.dll");
                        if (File.Exists(f))
                        {
                            testDllPath = f;
                        }
                    }
                    path = Path.Combine(path, "..");
                    if (!Directory.Exists(path)) break;
                }
                while (testDllPath == "");
                tbTestDll.Text = testDllPath == "" ? "no AsyncWebDriver.SeleniumAdapter.Common.Tests.dll" : testDllPath;
            }
            catch (Exception ex)
            {
                tbTestDll.Text = ex.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartTests(tbNunitConsole.Text, tbTestDll.Text);
        }

        private void StartTests(string nunitPath, string testDllPath)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = nunitPath;
            p.StartInfo.Arguments = testDllPath;
            p.Start();
            //string output = p.StandardOutput.ReadToEnd();
            //tbOutput.Text = output;
            p.WaitForExit();
            tbOutput.Text = "done";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var reportFile = FindReport();
            currentReportFile = reportFile;
        }

        private string FindReport()
        {
            try
            {
                var reportFileName = "TestResult.xml";
                var nunitReportPath = "";
                if (File.Exists(reportFileName)) nunitReportPath = reportFileName;
                var path = "";
                while (nunitReportPath == "")
                {
                    if (!Directory.Exists(path)) break;
                    var packages = Path.Combine(path, "packages");
                    if (Directory.Exists(packages))
                    {
                        var dir = Directory.GetDirectories(packages).FirstOrDefault(v => Path.GetFileName(v).StartsWith("NUnit.ConsoleRunner"));
                        if (dir != null)
                        {
                            var f = Path.Combine(dir, "tools", reportFileName);
                            if (File.Exists(f))
                            {
                                nunitReportPath = f;
                            }
                        }
                    }
                    path = Path.Combine(path, "..");
                }
                tbReportFile.Text = nunitReportPath == "" ? $"no {reportFileName}" : nunitReportPath;
                return nunitReportPath == "" ? null : nunitReportPath;
            }
            catch (Exception ex)
            {
                tbReportFile.Text = ex.ToString();
                return null;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (currentReportFile != null)
            {
                tbReport.Text = File.ReadAllText(currentReportFile);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (currentReportFile != null)
            {
                try
                {
                    var xml = XElement.Load(currentReportFile);
                    var sb = new StringBuilder();
                    var sb2 = new StringBuilder();
                    var testSuites = xml.Descendants().Where(v => v.Name == "test-suite" && v.Attribute("type").Value == "TestFixture");
                    foreach (var testSuite in testSuites)
                    {
                        var name = testSuite.Attribute("name").Value;
                        var fullname = testSuite.Attribute("fullname").Value;
                        //if (name.StartsWith("OpenQA.Selenium.")) name = name.Substring("OpenQA.Selenium.".Length);
                        var result = testSuite.Attribute("result").Value;
                        var total = testSuite.Attribute("total").Value;
                        var passed = testSuite.Attribute("passed").Value;
                        var failed = testSuite.Attribute("failed").Value;
                        var warnings = testSuite.Attribute("warnings").Value;
                        var skipped = testSuite.Attribute("skipped").Value;
                        var asserts = testSuite.Attribute("asserts").Value;

                        sb.AppendLine($"#### [{name}.cs]({GetLinkFor(name)}): {passed} passed, {failed} failed  ");
                        var anchor = $"{name.Replace(".", "")}cs-{passed}-passed-{failed}-failed";
                        sb2.AppendLine($"* [{name}](#{anchor.ToLower()}): {passed} passed, {failed} failed  ");


                        var testCases = testSuite.Elements("test-case");
                        foreach (var testCase in testCases)
                        {
                            var name2 = testCase.Attribute("name").Value;
                            var result2 = testCase.Attribute("result").Value;
                            var asserts2 = testCase.Attribute("asserts").Value;
                            string info = null;
                            if (result2 == "Failed")
                            {
                                result2 = result2.ToUpper();
                                var failure = testCase.Element("failure");
                                var failureMessage = failure?.Element("message");
                                var mess = failureMessage?.Value;
                                info = mess == null ? null : $"    {mess.Replace("\n", "  \n\t\t")}";
                            }
                            else if (result2 == "Skipped")
                            {
                                var reason = testCase.Element("reason");
                                var reasonMessage = reason?.Element("message");
                                var mess = reasonMessage?.Value;
                                info = mess == null ? null : $"    {mess.Replace("\n", "  \n\t\t")}";
                            }
                            sb.AppendLine($"    * {result2}: {name2}  ");
                            if (info != null) sb.AppendLine($"{info}  ");
                        }
                        sb.AppendLine();
                        sb.AppendLine();
                    }
                    tbReport.Text = $"{sb2.ToString()}{Environment.NewLine}<br>{Environment.NewLine}{Environment.NewLine}{sb.ToString()}";
                }
                catch (Exception ex)
                {
                    tbReport.Text = ex.ToString();
                }
            }

        }

        string baseLink = "https://github.com/ToCSharp/AsyncChromeDriverExamplesAndTests/tree/master/AsyncWebDriver.SeleniumAdapter.Common.Tests/";
        private string GetLinkFor(string name)
        {
            switch (name)
            {
                case "AppCacheTest":
                case "LocalStorageTest":
                case "LocationContextTest":
                case "SessionStorageTest":
                    return $"{baseLink}HTML5/{name}.cs";
                case "BasicKeyboardInterfaceTest":
                case "BasicMouseInterfaceTest":
                case "CombinedInputActionsTest":
                case "DragAndDropTest":
                    return $"{baseLink}Interactions/{name}.cs";
            }
            return $"{baseLink}{name}.cs";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (currentReportFile != null)
            {
                File.WriteAllText(currentReportFile, RemoveRus(File.ReadAllText(currentReportFile)));
            }
        }

        private string RemoveRus(string str)
        {
            str = str.Replace("Метод или операция не реализована.", "Method or operation is not implemented.");
            str = str.Replace("Выдано исключение типа", "An exception of type");
            str = str.Replace("Значение не может быть неопределенным", "The value can not be undefined");
            str = str.Replace("Ссылка на объект не указывает на экземпляр объекта", "The object reference does not point to an instance of the object");
            str = str.Replace("Путь имеет недопустимую форму", "The path has an unacceptable form");
            str = str.Replace("Имя параметра", "Parameter name");
            str = str.Replace("строка", "line");
            str = str.Replace("в", "in");
            return str;
        }
    }
}
