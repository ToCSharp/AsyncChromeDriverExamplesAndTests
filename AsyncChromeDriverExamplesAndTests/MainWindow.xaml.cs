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
                if (chbOpenProfileHeadless.IsChecked == true)
                {
                    var width = 1200;
                    var height = 900;
                    int.TryParse(tbOpenProfileHeadlessWidth.Text, out width);
                    int.TryParse(tbOpenProfileHeadlessHeight.Text, out height);
                    asyncChromeDriver = new AsyncChromeDriver(new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height).SetIsTempProfile());
                }
                else asyncChromeDriver = new AsyncChromeDriver();
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
            try
            {
                if (chbOpenProfileHeadless.IsChecked == true)
                {
                    var width = 1200;
                    var height = 900;
                    int.TryParse(tbOpenProfileHeadlessWidth.Text, out width);
                    int.TryParse(tbOpenProfileHeadlessHeight.Text, out height);
                    asyncChromeDriver = new AsyncChromeDriver(new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height).SetUserDir(userDir));
                }
                else asyncChromeDriver = new AsyncChromeDriver(userDir);
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
                        asyncChromeDriver = new AsyncChromeDriver(new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height).SetUserDir(userDir).SetPort(port));
                    }
                    else asyncChromeDriver = new AsyncChromeDriver(userDir, port);
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
                if (chbOpenProfileHeadless.IsChecked == true)
                {
                    var width = 1200;
                    var height = 900;
                    int.TryParse(tbOpenProfileHeadlessWidth.Text, out width);
                    int.TryParse(tbOpenProfileHeadlessHeight.Text, out height);
                    asyncChromeDriver = new AsyncChromeDriver(new ChromeDriverConfig().SetHeadless().SetWindowSize(width, height));
                }
                else asyncChromeDriver = new AsyncChromeDriver(new ChromeDriverConfig());
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
            await asyncChromeDriver.GoToUrl("chrome://settings/content/microphone");
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
            await asyncChromeDriver.WebView.EvaluateScript($"chrome.send('setCategoryPermissionForOrigin', ['{site}', '', 'media-stream-mic', 'allow', {incognito.ToString().ToLower()}])");
        }
    }
}
