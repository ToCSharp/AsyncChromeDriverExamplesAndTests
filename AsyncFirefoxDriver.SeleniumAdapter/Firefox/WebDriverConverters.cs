using System;
using System.Collections.Generic;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Zu.AsyncWebDriver;
using Zu.AsyncWebDriver.Remote;
using Zu.WebBrowser.BasicTypes;
using System.Linq;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class WebDriverConverters
    {
        public static Zu.AsyncWebDriver.By By(OpenQA.Selenium.By by)
        {
            var description = by.ToString();
            if (description.StartsWith("By.Id: ")) return Zu.AsyncWebDriver.By.Id(description.Substring("By.Id: ".Length));
            if (description.StartsWith("By.LinkText: ")) return Zu.AsyncWebDriver.By.LinkText(description.Substring("By.LinkText: ".Length));
            if (description.StartsWith("By.Name: ")) return Zu.AsyncWebDriver.By.Name(description.Substring("By.Name: ".Length));
            if (description.StartsWith("By.XPath: ")) return Zu.AsyncWebDriver.By.XPath(description.Substring("By.XPath: ".Length));
            if (description.StartsWith("By.ClassName[Contains]: ")) return Zu.AsyncWebDriver.By.ClassName(description.Substring("By.ClassName[Contains]: ".Length));
            if (description.StartsWith("By.PartialLinkText: ")) return Zu.AsyncWebDriver.By.PartialLinkText(description.Substring("By.PartialLinkText: ".Length));
            if (description.StartsWith("By.TagName: ")) return Zu.AsyncWebDriver.By.TagName(description.Substring("By.TagName: ".Length));
            if (description.StartsWith("By.CssSelector: ")) return Zu.AsyncWebDriver.By.CssSelector(description.Substring("By.CssSelector: ".Length));
            throw new NotSupportedException(description);
        }

        internal static OpenQA.Selenium.Screenshot SeleniumScreenshot(Zu.WebBrowser.BasicTypes.Screenshot screenshot)
        {
            return new OpenQA.Selenium.Screenshot(screenshot.AsBase64EncodedString);
        }

        internal static Point ToDrawingPoint(WebPoint webPoint)
        {
            return new Point(webPoint.X, webPoint.Y);
        }


        internal static IList<Zu.WebBrowser.BasicTypes.ActionSequence> SeleniumActionSequenceList(SyncWebDriver syncWebDriver, IList<OpenQA.Selenium.Interactions.ActionSequence> actionSequenceList)
        {
            var actions = new Zu.AsyncWebDriver.Interactions.Actions(syncWebDriver.AsyncDriver);
            var res = new List<Zu.WebBrowser.BasicTypes.ActionSequence>();
            foreach (var item in actionSequenceList)
            {
                if (/*item.Device.DeviceKind == OpenQA.Selenium.Interactions.InputDeviceKind.Pointer &&*/
                   item.Device is PointerInputDevice)
                {
                    var i = 0;
                    while (i < item.Interactions.Count)
                    {
                        var item2 = item.Interactions[i];
                        if (item2 is OpenQA.Selenium.Interactions.PauseInteraction)
                        {
                            var pi = (OpenQA.Selenium.Interactions.PauseInteraction)item2;
                            if(pi.Duration.TotalMilliseconds>0) actions.ActionBuilder.AddAction(new Zu.WebBrowser.BasicTypes.PauseInteraction(actions.defaultMouse, pi.Duration));
                        }
                        else if (item2 is PointerInputDevice.PointerMoveInteraction)
                        {
                            if ((item.Interactions.ElementAtOrDefault(i + 1) as PointerInputDevice.PointerDownInteraction)?.Button == MouseButton.Left &&
                                (item.Interactions.ElementAtOrDefault(i + 2) as PointerInputDevice.PointerUpInteraction)?.Button == MouseButton.Left)
                            {
                                var target = (WebElementAdapter)((PointerInputDevice.PointerMoveInteraction)item2).Target;
                                if ((item.Interactions.ElementAtOrDefault(i + 3) as PointerInputDevice.PointerDownInteraction)?.Button == MouseButton.Left &&
                               (item.Interactions.ElementAtOrDefault(i + 4) as PointerInputDevice.PointerUpInteraction)?.Button == MouseButton.Left)
                                {
                                    i += 4;
                                    actions.DoubleClick(target?.GetSyncWebElement().AsyncElement);
                                }
                                else
                                {
                                    i += 2;
                                    actions.Click(target?.GetSyncWebElement().AsyncElement);
                                }
                            }
                            else if ((item.Interactions.ElementAtOrDefault(i + 1) as PointerInputDevice.PointerDownInteraction)?.Button == MouseButton.Left)
                            {
                                var target = (WebElementAdapter)((PointerInputDevice.PointerMoveInteraction)item2).Target;
                                i += 1;
                                actions.ClickAndHold(target?.GetSyncWebElement().AsyncElement);
                            }
                            else if ((item.Interactions.ElementAtOrDefault(i + 1) as PointerInputDevice.PointerUpInteraction)?.Button == MouseButton.Left)
                            {
                                var target = (WebElementAdapter)((PointerInputDevice.PointerMoveInteraction)item2).Target;
                                i += 1;
                                actions.Release(target?.GetSyncWebElement().AsyncElement);
                            }
                            else if ((item.Interactions.ElementAtOrDefault(i + 1) as PointerInputDevice.PointerDownInteraction)?.Button == MouseButton.Right &&
                                     (item.Interactions.ElementAtOrDefault(i + 2) as PointerInputDevice.PointerUpInteraction)?.Button == MouseButton.Right)
                            {
                                var target = (WebElementAdapter)((PointerInputDevice.PointerMoveInteraction)item2).Target;
                                i += 2;
                                actions.ContextClick(target?.GetSyncWebElement().AsyncElement);
                            }
                            else
                            {
                                var pmi = (PointerInputDevice.PointerMoveInteraction)item2;
                                var target = (WebElementAdapter)pmi.Target;
                                if (pmi.X != 0 || pmi.Y != 0)
                                    actions.MoveToElement(target?.GetSyncWebElement().AsyncElement, pmi.X, pmi.Y);
                                else actions.MoveToElement(target?.GetSyncWebElement().AsyncElement);
                            }
                        }
                        else if (item2 is PointerInputDevice.PointerCancelInteraction)
                        {

                        }
                        else if (item2 is PointerInputDevice.PointerDownInteraction)
                        {

                        }
                        else if (item2 is PointerInputDevice.PointerUpInteraction)
                        {

                        }
                        i++;
                    }
                }
                else if (item.Device is KeyInputDevice)
                {
                    var i = 0;
                    while (i < item.Interactions.Count)
                    {
                        var item2 = item.Interactions[i];
                        if (item2 is OpenQA.Selenium.Interactions.PauseInteraction)
                        {
                            var pi = (OpenQA.Selenium.Interactions.PauseInteraction)item2;
                            if (pi.Duration.TotalMilliseconds > 0) actions.ActionBuilder.AddAction(new Zu.WebBrowser.BasicTypes.PauseInteraction(actions.defaultKeyboard, pi.Duration));
                        }
                        else if(item2 is KeyInputDevice.KeyDownInteraction)
                        {

                            var key = ((KeyInputDevice.TypingInteraction)item2).Value;
                            actions.ActionBuilder.AddAction(actions.defaultKeyboard.CreateKeyDown(key[0]));
                        }
                        else if (item2 is KeyInputDevice.KeyUpInteraction)
                        {
                            var key = ((KeyInputDevice.TypingInteraction)item2).Value;
                            actions.ActionBuilder.AddAction(actions.defaultKeyboard.CreateKeyUp(key[0]));
                        }
                        i++;
                    }
                }
            }
            return actions.ActionBuilder.ToActionSequenceList();
        }
    }
}