using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using BaristaLabs.ChromeDevTools.Runtime.Console;
using BaristaLabs.ChromeDevTools.Runtime.Debugger;
using Zu.AsyncWebDriver.Remote;
using Zu.Chrome;
using Zu.WebBrowser.BasicTypes;

namespace AsyncChromeDriverExamplesAndTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AsyncChromeDriver asyncChromeDriver;
        private WebDriver webDriver;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region OpenTab

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (webDriver != null)
            {
                await webDriver.Close();
            }
        }

        private async void OpenTab_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var addArgs = tbOpenAddArgs.Text;
                if (chbOpenProfileHeadless.IsChecked == true)
                {
                    var width = 1200;
                    var height = 900;
                    int.TryParse(tbOpenProfileHeadlessWidth.Text, out width);
                    int.TryParse(tbOpenProfileHeadlessHeight.Text, out height);
                    var config = new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height).SetIsTempProfile();
                    if (!string.IsNullOrWhiteSpace(addArgs)) config.SetCommandLineArgumets(addArgs);
                    asyncChromeDriver = new AsyncChromeDriver(config);
                }
                else asyncChromeDriver = string.IsNullOrWhiteSpace(addArgs) ? new AsyncChromeDriver() : new AsyncChromeDriver(new ChromeDriverConfig().SetCommandLineArgumets(addArgs));
                webDriver = new WebDriver(asyncChromeDriver);
                await asyncChromeDriver.Connect();
                tbDevToolsRes2.Text = $"opened on port {asyncChromeDriver.Port} in dir {asyncChromeDriver.UserDir} \nWhen close, dir will be DELETED";
            }
            catch (Exception ex)
            {
                tbDevToolsRes2.Text = ex.ToString();
            }
        }
        private async void OpenTab_Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (webDriver != null)
            {
                await webDriver.Close();
                //await asyncChromeDriver?.Close();
                tbDevToolsRes2.Text = "closed";
            }
        }

        private async void OpenTab_Button_Click_9(object sender, RoutedEventArgs e)
        {
            var userDir = tbOpenProfileDir.Text;
            var addArgs = tbOpenAddArgs.Text;
            try
            {
                if (chbOpenProfileHeadless.IsChecked == true)
                {
                    var width = 1200;
                    var height = 900;
                    int.TryParse(tbOpenProfileHeadlessWidth.Text, out width);
                    int.TryParse(tbOpenProfileHeadlessHeight.Text, out height);
                    var config = new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height).SetUserDir(userDir);
                    if (!string.IsNullOrWhiteSpace(addArgs)) config.SetCommandLineArgumets(addArgs);
                    asyncChromeDriver = new AsyncChromeDriver(config);
                }
                else asyncChromeDriver = string.IsNullOrWhiteSpace(addArgs) ? new AsyncChromeDriver(userDir) : new AsyncChromeDriver(new ChromeDriverConfig().SetUserDir(userDir).SetCommandLineArgumets(addArgs));
                //else asyncChromeDriver = new AsyncChromeDriver(userDir);
                webDriver = new WebDriver(asyncChromeDriver);
                // await asyncChromeDriver.Connect(); // browser opens here
                await webDriver.GoToUrl("https://www.google.com/"); // browser opens here
                var mess = $"opened on port {asyncChromeDriver.Port} in dir {asyncChromeDriver.UserDir} \nWhen close, dir will NOT be deleted";
                tbDevToolsRes2.Text = mess;
            }
            catch (Exception ex)
            {
                tbDevToolsRes2.Text = ex.ToString();
            }

        }

        private async void OpenTab_Button_Click_10(object sender, RoutedEventArgs e)
        {
            var userDir = tbOpenProfileDir.Text;
            var addArgs = tbOpenAddArgs.Text;
            if (int.TryParse(tbOpenProfilePort.Text, out int port))
            {
                try
                {
                    if (chbOpenProfileHeadless.IsChecked == true)
                    {
                        var width = 1200;
                        var height = 900;
                        int.TryParse(tbOpenProfileHeadlessWidth.Text, out width);
                        int.TryParse(tbOpenProfileHeadlessHeight.Text, out height);
                        var config = new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height).SetUserDir(userDir).SetPort(port);
                        if (!string.IsNullOrWhiteSpace(addArgs)) config.SetCommandLineArgumets(addArgs);
                        asyncChromeDriver = new AsyncChromeDriver(config);
                    }
                    else asyncChromeDriver = string.IsNullOrWhiteSpace(addArgs) ?
                            new AsyncChromeDriver(userDir, port) :
                            new AsyncChromeDriver(new ChromeDriverConfig().SetUserDir(userDir).SetPort(port).SetCommandLineArgumets(addArgs));
                    webDriver = new WebDriver(asyncChromeDriver);
                    // await asyncChromeDriver.Connect(); // browser opens here
                    await webDriver.GoToUrl("https://www.google.com/"); // browser opens here
                    var mess = $"opened on port {asyncChromeDriver.Port} in dir {asyncChromeDriver.UserDir} \nWhen close, dir will NOT be deleted";
                    tbDevToolsRes2.Text = mess;
                }
                catch (Exception ex)
                {
                    tbDevToolsRes2.Text = ex.ToString();
                }
            }
        }

        private async void OpenTab_Button_Click_12(object sender, RoutedEventArgs e)
        {
            try
            {
                var addArgs = tbOpenAddArgs.Text;
                if (chbOpenProfileHeadless.IsChecked == true)
                {
                    var width = 1200;
                    var height = 900;
                    int.TryParse(tbOpenProfileHeadlessWidth.Text, out width);
                    int.TryParse(tbOpenProfileHeadlessHeight.Text, out height);
                    var config = new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height);
                    if (!string.IsNullOrWhiteSpace(addArgs)) config.SetCommandLineArgumets(addArgs);
                    asyncChromeDriver = new AsyncChromeDriver(config);
                }
                else asyncChromeDriver = string.IsNullOrWhiteSpace(addArgs) ? new AsyncChromeDriver(new ChromeDriverConfig()) : new AsyncChromeDriver(new ChromeDriverConfig().SetCommandLineArgumets(addArgs));
                webDriver = new WebDriver(asyncChromeDriver);
                await asyncChromeDriver.Connect(); // browser opens here
                                                   // await webDriver.GoToUrl("https://www.google.com/"); // browser opens here
                var mess = $"opened on port {asyncChromeDriver.Port} in dir {asyncChromeDriver.UserDir} \nWhen close, dir will NOT be deleted";
                tbDevToolsRes2.Text = mess;
            }
            catch (Exception ex)
            {
                tbDevToolsRes2.Text = ex.ToString();
            }
        }
        #endregion

        #region MouseTab
        private async void MouseTab_Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (webDriver == null)
            {
                asyncChromeDriver = new AsyncChromeDriver();
                webDriver = new WebDriver(asyncChromeDriver);
            }
            await webDriver.GoToUrl(Path.Combine(Environment.CurrentDirectory, "selenium_common_src_web\\mousePositionTracker.html"));
        }

        private async void MouseTab_Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (webDriver == null) return;
            var div = await webDriver.FindElementById("mousetracker");
            var location = await div.Location();
            var size = await div.Size();
            tbMouseInfo.Text = $"Location: {location}{Environment.NewLine}" +
                               $"Size: {size}{Environment.NewLine}" + tbMouseInfo.Text;
        }

        private void MouseTab_Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (webDriver == null) return;
            if (int.TryParse(tbMouseX1.Text, out int x) && int.TryParse(tbMouseY1.Text, out int y))
            {
                webDriver.Mouse.MouseMove(new WebPoint(x, y));
            }
        }

        private async void MouseTab_Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (webDriver == null) return;
            if (int.TryParse(tbMouseX1.Text, out int x) && int.TryParse(tbMouseY1.Text, out int y))
            {
                var div = await webDriver.FindElementById("mousetracker");
                var divLocation = await div.Location();
                await webDriver.Mouse.MouseMove(divLocation.Offset(x, y));
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (webDriver == null) return;
            if (int.TryParse(tbMouseX1.Text, out int x) && int.TryParse(tbMouseY1.Text, out int y))
            {
                var div = await webDriver.FindElementById("mousetracker");

                //// Not implemented. Give me a couple of days
                //await div.Click(x, y)

                var divLocation = await div.Location();
                var clickLocation = divLocation.Offset(x, y);
                await webDriver.Mouse.Click(clickLocation);
                //OR
                //await webDriver.Mouse.MouseDown(clickLocation);
                //await Task.Delay(2000);
                //await webDriver.Mouse.MouseUp(clickLocation);

            }
        }
        #endregion

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (webDriver == null)
            {
                asyncChromeDriver = new AsyncChromeDriver();
                webDriver = new WebDriver(asyncChromeDriver);
            }
            await webDriver.GoToUrl(Path.Combine(Environment.CurrentDirectory, "html\\myclicks.html"));
            tbClicksInfo.Text = $"opened myclicks.html";
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (webDriver == null) return;
            var link = await webDriver.FindElementById("normal");

            var text = await link.Text();
            var location = await link.Location();
            var size = await link.Size();

            await link.Click();

            tbClicksInfo.Text = $"clicked on link with text = \"{text}\"" + Environment.NewLine +
                                $"link location = \"{location}\"" + Environment.NewLine +
                                $"link size = \"{size}\"" + Environment.NewLine + tbClicksInfo.Text;
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (webDriver == null)
            {
                asyncChromeDriver = new AsyncChromeDriver();
                webDriver = new WebDriver(asyncChromeDriver);
            }
            await asyncChromeDriver.CheckConnected();
            asyncChromeDriver.DevToolsEvent += AsyncChromeDriver_DevToolsEvent;
            await asyncChromeDriver.DevTools.Session.Page.Enable();

        }

        private void AsyncChromeDriver_DevToolsEvent(object sender, string methodName, Newtonsoft.Json.Linq.JToken eventData)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                tbPage.Text = $"{methodName}: {eventData.ToString()} {Environment.NewLine}" + tbPage.Text;
            });
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (webDriver == null) return;
            if (int.TryParse(tbMouseX1.Text, out int x) && int.TryParse(tbMouseY1.Text, out int y))
            {
                var clickLocation = new WebPoint(x, y);
                await webDriver.Mouse.Click(clickLocation);

            }

        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (webDriver == null)
            {
                asyncChromeDriver = new AsyncChromeDriver();
                webDriver = new WebDriver(asyncChromeDriver);
            }
            //await asyncChromeDriver.Navigation.GoToUrl("chrome://settings/content/microphone");
            await webDriver.GoToUrl("chrome://settings/content/microphone");
            //await asyncChromeDriver.WebView.EvaluateScript("chrome.send('setCategoryPermissionForOrigin', ['https://www.google.com:443', '', 'media-stream-mic', 'allow', false])");
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var site = tbSettingsSite.Text;
            var incognito = chbIncognito.IsChecked == true;
            await AddSiteMicPermission(site, incognito);
        }

        private async Task AddSiteMicPermission(string site, bool incognito)
        {
            var res = await webDriver.ExecuteScript($"chrome.send('setCategoryPermissionForOrigin', ['{site}', '', 'media-stream-mic', 'allow', {incognito.ToString().ToLower()}])");
        }

        private async void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (webDriver != null)
            {
                var dir = tbScreenshotDir.Text;
                var screenshot = await webDriver.GetScreenshot();
                //screenshot.SaveAsFile(GetFilePathToSaveScreenshot(), Zu.WebBrowser.BasicTypes.ScreenshotImageFormat.Png);
                using (MemoryStream imageStream = new MemoryStream(screenshot.AsByteArray))
                {
                    System.Drawing.Image screenshotImage = System.Drawing.Image.FromStream(imageStream);
                    screenshotImage.Save(GetFilePathToSaveScreenshot(dir), System.Drawing.Imaging.ImageFormat.Png);
                }

            }
        }

        private static string GetFilePathToSaveScreenshot(string dir = null)
        {
            dir = dir ?? @"C:\temp";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            var i = 0;
            var path = "";
            do
            {
                i++;
                path = Path.Combine(dir, $"screenshot{i}.png");
            } while (File.Exists(path));
            return path;
        }

        private async void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (webDriver == null)
            {
                asyncChromeDriver = new AsyncChromeDriver();
                webDriver = new WebDriver(asyncChromeDriver);
            }
            await asyncChromeDriver.CheckConnected();
            asyncChromeDriver.DevTools.Session.Console.SubscribeToMessageAddedEvent(OnConsoleMessage);
            await asyncChromeDriver.DevTools.Session.Console.Enable();

        }

        private void OnConsoleMessage(MessageAddedEvent mess)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                tbConsoleMessages.Text = $"{mess.Message.Level}: {mess.Message.Text} {Environment.NewLine}" + tbConsoleMessages.Text;
            });

        }

        private async void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (webDriver == null) return;
            await webDriver.GoToUrl("data:text/html,%3Cscript%3Econsole.log%28%27test1%27%29%3B%3C%2Fscript%3E");
        }

        bool listeningDebugger = false;
        private async void Button_Click_10(object sender, RoutedEventArgs e)
        {
            try
            {
                if (webDriver == null) return;
                var nodeDomId = tbDOMDebuggerNodeId.Text;
                //var el = await webDriver.FindElementById(nodeDomId);

                //if (el == null)
                //{
                //    tbDOMDebuggerMessages.Text = $"No element with id '{nodeDomId}'";
                //    return;
                //}
                //var nodeId1 = await asyncChromeDriver.DevTools.Session.DOM.RequestNode(new BaristaLabs.ChromeDevTools.Runtime.DOM.RequestNodeCommand
                //{
                //    ObjectId = nodeDomId
                //});
                var doc = await asyncChromeDriver.DevTools.Session.DOM.GetDocument(new BaristaLabs.ChromeDevTools.Runtime.DOM.GetDocumentCommand
                {
                    Depth = -1,
                  //  Pierce = true
                });
                //var docFlattened = await asyncChromeDriver.DevTools.Session.DOM.GetFlattenedDocument(new BaristaLabs.ChromeDevTools.Runtime.DOM.GetFlattenedDocumentCommand
                //{
                //    Depth = -1,
                // //   Pierce = true
                //});

                var objId = await asyncChromeDriver.DevTools.Session.DOM.ResolveNode(new BaristaLabs.ChromeDevTools.Runtime.DOM.ResolveNodeCommand
                {
                    NodeId = doc.Root.NodeId
                });
                var nodeId1 = await asyncChromeDriver.DevTools.Session.DOM.RequestNode(new BaristaLabs.ChromeDevTools.Runtime.DOM.RequestNodeCommand
                {
                    ObjectId = objId.Object.ObjectId
                });

                var nodeId = await asyncChromeDriver.DevTools.Session.DOM.QuerySelector(new BaristaLabs.ChromeDevTools.Runtime.DOM.QuerySelectorCommand
                {
                    NodeId = doc.Root.NodeId,
                    Selector = "#" + nodeDomId
                });

                var outerHTML = await asyncChromeDriver.DevTools.Session.DOM.GetOuterHTML(new BaristaLabs.ChromeDevTools.Runtime.DOM.GetOuterHTMLCommand
                {
                    NodeId = nodeId.NodeId
                });

                if (!listeningDebugger)
                {
                    listeningDebugger = true;
                    asyncChromeDriver.DevTools.Session.Debugger.SubscribeToBreakpointResolvedEvent(OnBreakpointResolvedEvent);
                    asyncChromeDriver.DevTools.Session.Debugger.SubscribeToPausedEvent(OnPausedEvent);
                    await asyncChromeDriver.DevTools.Session.Debugger.Enable();
                }
                var res = await asyncChromeDriver.DevTools.Session.DOMDebugger.SetDOMBreakpoint(new BaristaLabs.ChromeDevTools.Runtime.DOMDebugger.SetDOMBreakpointCommand
                {
                    Type = BaristaLabs.ChromeDevTools.Runtime.DOMDebugger.DOMBreakpointType.SubtreeModified,
                    NodeId = nodeId.NodeId
                });
            }
            catch(Exception ex)
            {
                tbDOMDebuggerMessages.Text = ex.ToString();
            }
        }

        private async void OnPausedEvent(PausedEvent obj)
        {
            var mess = $"{obj.Reason}: {obj.Data.ToString()}";
            Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                tbDOMDebuggerMessages.Text = $"{mess} {Environment.NewLine}" + tbDOMDebuggerMessages.Text;
            });
            await asyncChromeDriver.DevTools.Session.Debugger.Resume();
        }

        private void OnBreakpointResolvedEvent(BreakpointResolvedEvent obj)
        {

        }

        private async void Button_Click_11(object sender, RoutedEventArgs e)
        {
            try
            {
                if (webDriver == null) return;
                var nodeDomId = tbDOMDebuggerNodeId.Text;
                var doc = await asyncChromeDriver.DevTools.Session.DOM.GetDocument(new BaristaLabs.ChromeDevTools.Runtime.DOM.GetDocumentCommand
                {
                    Depth = -1,
                    //  Pierce = true
                });

                var objId = await asyncChromeDriver.DevTools.Session.DOM.ResolveNode(new BaristaLabs.ChromeDevTools.Runtime.DOM.ResolveNodeCommand
                {
                    NodeId = doc.Root.NodeId
                });
                var nodeId = await asyncChromeDriver.DevTools.Session.DOM.QuerySelector(new BaristaLabs.ChromeDevTools.Runtime.DOM.QuerySelectorCommand
                {
                    NodeId = doc.Root.NodeId,
                    Selector = "#" + nodeDomId
                });

                if (!listeningDebugger)
                {
                    listeningDebugger = true;
                    asyncChromeDriver.DevTools.Session.Debugger.SubscribeToBreakpointResolvedEvent(OnBreakpointResolvedEvent);
                    asyncChromeDriver.DevTools.Session.Debugger.SubscribeToPausedEvent(OnPausedEvent);
                    await asyncChromeDriver.DevTools.Session.Debugger.Enable();
                }
                var res = await asyncChromeDriver.DevTools.Session.DOMDebugger.SetDOMBreakpoint(new BaristaLabs.ChromeDevTools.Runtime.DOMDebugger.SetDOMBreakpointCommand
                {
                    Type = BaristaLabs.ChromeDevTools.Runtime.DOMDebugger.DOMBreakpointType.AttributeModified,
                    NodeId = nodeId.NodeId
                });
            }
            catch (Exception ex)
            {
                tbDOMDebuggerMessages.Text = ex.ToString();
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {

        }
    }
}
