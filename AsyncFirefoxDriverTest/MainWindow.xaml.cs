using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zu.AsyncWebDriver.Remote;
using Zu.Firefox;
using Zu.WebBrowser;
using Zu.WebBrowser.BasicTypes;

namespace AsyncFirefoxDriverTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string DBG_XUL = "chrome://devtools/content/framework/toolbox-process-window.xul";
        string CHROME_DEBUGGER_PROFILE_NAME = "chrome_debugger_profile";
        private AsyncFirefoxDriver asyncFirefoxDriver;
        private WebDriver webDriver;
        private AsyncFirefoxDriver asyncFirefoxDriver2;
        private WebDriver webDriver2;
        private Process process;
        private string devToolsProfileName;

        ///**
        // * Shortcuts for accessing various debugger preferences.
        // */
        //var Prefs = new PrefsHelper("devtools.debugger", {
        //  chromeDebuggingHost: ["Char", "chrome-debugging-host"],
        //  chromeDebuggingPort: ["Int", "chrome-debugging-port"],
        //  chromeDebuggingWebSocket: ["Bool", "chrome-debugging-websocket"],
        //});

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var debuggerPort = 9876;
            //var config = new DriverConfig().SetCommandLineArgumets(" --start-debugger-server " + debuggerPort);
            var config = new FirefoxDriverConfig()
                .SetCommandLineArgumets("-start-debugger-server " + debuggerPort) //;
                .SetUserPreferences(new Dictionary<string, string>
            {
                { "devtools.debugger.prompt-connection", "false" },
                { "devtools.debugger.remote-enabled", "true" },
                { "devtools.chrome.enabled", "true" },
                { "devtools.debugger.remote-port", debuggerPort.ToString() },
                { "devtools.debugger.chrome-debugging-port", debuggerPort.ToString() }

            });
            var path = config.UserDir;

            asyncFirefoxDriver = new AsyncFirefoxDriver(config);
            webDriver = new WebDriver(asyncFirefoxDriver);

            await asyncFirefoxDriver.Connect();
            var devToolsPrefs = new Dictionary<string, string>
            {
                { "devtools.debugger.prompt-connection", "false" },
                { "devtools.debugger.remote-enabled", "true" },
                { "devtools.debugger.remote-port", "9876" },
                { "devtools.debugger.chrome-debugging-port", debuggerPort.ToString() }

            };
            var devToolsProfileDir = Path.Combine(path, CHROME_DEBUGGER_PROFILE_NAME);
            devToolsProfileName = CHROME_DEBUGGER_PROFILE_NAME + new Random().Next(1000).ToString();
            await FirefoxProfilesWorker.CreateFirefoxProfile(devToolsProfileDir, devToolsProfileName);

            FirefoxProfilesWorker.AddWriteUserPreferences(devToolsProfileDir, devToolsPrefs);


            var xulURI = DBG_XUL;
            var args = new string[] {
     //"-no-remote",
     "-foreground",
     //"-profile", this._dbgProfilePath,
     "-chrome", xulURI
            };
            var argsStr = string.Join(" ", args);
            var configDevTools = new FirefoxDriverConfig()
                .SetProfileName(devToolsProfileName);
            //.SetIsTempProfile()
            //.SetCommandLineArgumets(argsStr);

            asyncFirefoxDriver2 = new AsyncFirefoxDriver(configDevTools);
            webDriver2 = new WebDriver(asyncFirefoxDriver2);
            await asyncFirefoxDriver2.Connect();
            await asyncFirefoxDriver2.Navigation.GoToUrl(DBG_XUL);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            webDriver?.CloseSync();
            webDriver2?.CloseSync();
            try
            {
                process?.CloseMainWindow();
            }
            catch { }
            try
            {
                process?.Close();
            }
            catch { }
            try
            {
                FirefoxProfilesWorker.RemoveProfile(devToolsProfileName);
            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var debuggerPort = 9876;
            var args = " --start-debugger-server " + debuggerPort;
            var processJob = new ProcessWithJobObject();
            process = processJob.StartProc(FirefoxProfilesWorker.FirefoxBinaryFileName, args);

        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var path = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            var debuggerPort = 9876;
            var devToolsPrefs = new Dictionary<string, string>
            {
                { "devtools.debugger.prompt-connection", "false" },
                //{ "devtools.debugger.remote-enabled", "true" },
                { "devtools.debugger.remote-port", "9876" },
                { "devtools.debugger.chrome-debugging-port", debuggerPort.ToString() }

            };
            devToolsProfileName = CHROME_DEBUGGER_PROFILE_NAME + new Random().Next(1000).ToString();
            var devToolsProfileDir = Path.Combine(Path.GetTempPath(), devToolsProfileName); // Path.Combine(path, CHROME_DEBUGGER_PROFILE_NAME);
            await FirefoxProfilesWorker.CreateFirefoxProfile(devToolsProfileDir, devToolsProfileName);

            FirefoxProfilesWorker.AddWriteUserPreferences(devToolsProfileDir, devToolsPrefs);


            var xulURI = DBG_XUL;
            var args = new string[] {
     //"-no-remote",
     "-foreground",
     //"-profile", this._dbgProfilePath,
     "-chrome", xulURI
            };
            var argsStr = string.Join(" ", args);
            var configDevTools = new FirefoxDriverConfig()
                .SetProfileName(devToolsProfileName);
            //.SetIsTempProfile()
            //.SetCommandLineArgumets(argsStr);

            asyncFirefoxDriver2 = new AsyncFirefoxDriver(configDevTools);
            webDriver2 = new WebDriver(asyncFirefoxDriver2);
            await asyncFirefoxDriver2.Connect();
            await asyncFirefoxDriver2.Navigation.GoToUrl(DBG_XUL);

        }
    }
}
