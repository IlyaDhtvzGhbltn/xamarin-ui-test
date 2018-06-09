using System;
using System.IO;
using System.Linq;
using Constants.Extension;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using ACons = StringConstants.AppConstantsLabels;

namespace UITest_iOS
{
   // [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests_iOS
    {
        Platform platform;

        public Tests_iOS(Platform platform)
        {
            this.platform = platform;
        }

        public static string iOS_Login(IApp app, string login, string pass, bool IsScreen)
        {
            
            app.WaitForElement(x => x.Marked(ACons.TxbxLogin), "too long request", new TimeSpan(0, 3, 0));
            app.EnterText(x => x.Marked(ACons.TxbxLogin), login);
            app.PressEnter();
            app.EnterText(x => x.Marked(ACons.TxbxPassword), pass);
            var loginButton = app.Query(x => x.Id(ACons.BtnEnter)).FirstOrDefault();
            string textButtonLogin = loginButton.Label;
            if(IsScreen==true) 
                app.Screenshot($"label button - '{textButtonLogin}' ");

            app.PressEnter();
            app.Tap(x => x.Id(ACons.BtnEnter));
            return textButtonLogin;
        }

        public static void iOS_TransactionHistoryFilter(IApp app, 
            string Ok,
            string alert,  
            string CalendReady, 
            TimeSpan Span)
        {

            app.ScrollDown(strategy: ScrollStrategy.Programmatically);
            app.ScrollDown(strategy: ScrollStrategy.Programmatically);
            app.WaitForElementThreadTAP(ACons.BtnTransactionHistory, "transaction history", Span);
            app.ScreenshotWait("All Transaction History");
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.ScreenshotWait("Select dates");
            /* period: START -> to long BACK, end -> hold  */
            app.WaitForElementThreadTAP(ACons.PeriodStart, "period start", Span);
            app.Tap((DateTime.Now.Year).ToString());
            app.Tap((DateTime.Now.Year - 1).ToString());
            app.ScreenshotWait("Start reset");
            app.Tap("Done");
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "Start period (--1) year ALERT");
            app.Tap(alert);
            app.Tap(Ok);
            /* period: START -> to long FUTURE, end -> hold  */
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.WaitForElementThreadTAP(ACons.PeriodStart, "period start", Span);
            app.Tap((DateTime.Now.Year - 1).ToString());
            app.Tap((DateTime.Now.Year).ToString());
            app.Tap((DateTime.Now.Year).ToString());
            app.Tap((DateTime.Now.Year + 1).ToString());
            app.ScreenshotWait("Start reset");
            app.Tap("Done");
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "Start period (++1) year");
            /* period: start -> hold, END -> to long BACK  */
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.WaitForElementThreadTAP(ACons.PeriodEnd, "period end", Span);
            app.Tap((DateTime.Now.Year).ToString());
            app.Tap((DateTime.Now.Year - 1).ToString());
            app.ScreenshotWait("End reset");
            app.Tap("Done");
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "End period (--1) year");
            /* period: start -> hold, END -> to long FUTURE  */
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.WaitForElementThreadTAP(ACons.PeriodEnd, "period end", Span);
            app.Tap((DateTime.Now.Year - 1).ToString());
            app.Tap((DateTime.Now.Year).ToString());
            app.Tap((DateTime.Now.Year).ToString());
            app.Tap((DateTime.Now.Year + 1).ToString());
            app.ScreenshotWait("End reset");
            app.Tap("Done");
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "End period (--1) year ALERT");
            app.Tap(alert);
            app.Tap(Ok);
            app.ScreenshotWait(title: "End period (--1) skip alert");
        }

        public static void iOS_PressEnter(IApp app, string Enter)
        {
            app.Tap(x => x.Text(Enter));
        }
    }
}

