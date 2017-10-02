using OpenQA.Selenium;
using OpenQA.Selenium.Interactions.Internal;
using Zu.AsyncWebDriver.Remote;

namespace Zu.SeleniumAdapter
{
    public class MouseAdapter : IMouse
    {
        private SyncMouse mouse;

        public MouseAdapter(SyncMouse mouse)
        {
            this.mouse = mouse;
        }

        public void Click(ICoordinates where)
        {
            //mouse.Click(where);
            throw new System.NotImplementedException();
        }

        public void ContextClick(ICoordinates where)
        {
            throw new System.NotImplementedException();
        }

        public void DoubleClick(ICoordinates where)
        {
            throw new System.NotImplementedException();
        }

        public void MouseDown(ICoordinates where)
        {
            throw new System.NotImplementedException();
        }

        public void MouseMove(ICoordinates where)
        {
            throw new System.NotImplementedException();
        }

        public void MouseMove(ICoordinates where, int offsetX, int offsetY)
        {
            throw new System.NotImplementedException();
        }

        public void MouseUp(ICoordinates where)
        {
            throw new System.NotImplementedException();
        }
    }
}