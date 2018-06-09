using System;
using System.Threading;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Constants.Extension
{
    public static class XamarinUITestExtensions
    {
        public static void WaitForElementThread(this IApp app, string label, string text, TimeSpan span, int threadSleep = 2000)
        {

            Thread.Sleep(threadSleep);
            app.WaitForElement(label, $"to long wait {text}" , span);
        }

        public static void ScreenshotWait(this IApp app, string title = "Request has been queued for processing", int sleep = 2000, string ElementLabel = "LabelWait", Platform platform = Platform.Android)
        {
            Thread.Sleep(sleep);
            if (platform == Platform.Android)
                app.WaitForNoElement(ElementLabel);
            else
                app.WaitForNoElement(x=>x.Id(ElementLabel));

            Thread.Sleep(sleep);
            app.Screenshot(title);
        }

        public static void WaitForElementThreadTAP(this IApp app, string label, string message, TimeSpan span, int threadSleep = 2000)
        {
            Thread.Sleep(threadSleep);
            app.WaitForElement(label, $"to long wait {message}", span);
            app.Tap(label);
        }
        public static void WaitForElementThreadTAPtext(this IApp app, string text, string message, TimeSpan span, int threadSleep = 2000)
        {
            Thread.Sleep(threadSleep);
            app.WaitForElement(x=>x.Text(text));
            app.Tap(x => x.Text(text));
        }

        public static void WaitForElementThreadTAPId(this IApp app, string text, string message, TimeSpan span, int threadSleep = 2000)
        {
            Thread.Sleep(threadSleep);
            app.WaitForElement(x => x.Id(text));
            app.Tap(x => x.Id(text));
        }
    }
}
