using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Constants.Extension;

using ACons = StringConstants.AppConstantsLabels;

namespace UITest_Android
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests_Android
    {
        public static string Android_Login(IApp app, string login, string pass, bool IsScreen)
        {
            app.WaitForElement(x => x.Marked(ACons.BtnEnter), "too long request", new TimeSpan(0, 3, 0));
            app.EnterText(x => x.Marked(ACons.TxbxLogin), login);
            app.PressEnter();
            System.Threading.Thread.Sleep(5000);
            app.EnterText(x => x.Marked(ACons.TxbxPassword), pass);
            app.PressEnter();
            var loginButton = app.Query(x => x.Marked(ACons.BtnEnter)).FirstOrDefault();
            string textButtonLogin = loginButton.Text;
            if (IsScreen == true)
                app.Screenshot($"label button - '{textButtonLogin}'.");

            app.Tap(x => x.Marked(ACons.BtnEnter));
            return textButtonLogin;
        }

        public static void AndroidTransactionHistory(IApp app, TimeSpan Span, string Ok, string CalendReady, string alert)
        {
            app.WaitForElementThread(ACons.BtnFlexSave, "logining", Span);
            app.ScrollDown(strategy: ScrollStrategy.Programmatically);
            app.ScrollDown(strategy: ScrollStrategy.Programmatically);
            app.WaitForElementThreadTAP(ACons.BtnTransactionHistory, "transaction history", Span);
            app.ScreenshotWait("All Transaction History");
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.ScreenshotWait("Select dates");
            /* period: START -> to long BACK, end -> hold  */
            app.WaitForElementThreadTAP(ACons.PeriodStart, "period start", Span);
            try
            {
                app.Tap((DateTime.Now.Year).ToString());
                app.Tap((DateTime.Now.Year - 1).ToString());
            }
            catch (Exception)
            {
                TransactionHistoryLowAPI(app, Span, Ok, CalendReady, alert, (DateTime.Now.Year).ToString(), (DateTime.Now.Year - 1).ToString());
            }
            app.ScreenshotWait("Start reset");
            try
            {
                app.Tap(Ok.ToUpper());
            }
            catch (Exception)
            {
                app.Tap(CalendReady);
            }
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "Start period (--1) year ALERT");
            app.Tap(alert);
            app.Tap(Ok);
            /* period: START -> to long FUTURE, end -> hold  */
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.WaitForElementThreadTAP(ACons.PeriodStart, "period start", Span);
            try
            {
                app.Tap((DateTime.Now.Year - 1).ToString());
                app.Tap((DateTime.Now.Year).ToString());
                app.Tap((DateTime.Now.Year).ToString());
                app.Tap((DateTime.Now.Year + 1).ToString());
            }
            catch (Exception)
            {
                TransactionHistoryLowAPI(app, Span, Ok, CalendReady, alert, (DateTime.Now.Year - 1).ToString(), (DateTime.Now.Year + 1).ToString());
            }
            app.ScreenshotWait("Start reset");
            try
            {
                app.Tap(Ok.ToUpper());
            }
            catch (Exception)
            {
                app.Tap(CalendReady);
            }
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "Start period (++1) year");
            /* period: start -> hold, END -> to long BACK  */
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.WaitForElementThreadTAP(ACons.PeriodEnd, "period end", Span);
            try
            {
                app.Tap((DateTime.Now.Year).ToString());
                app.Tap((DateTime.Now.Year - 1).ToString());
            }
            catch (Exception)
            {
                TransactionHistoryLowAPI(app, Span, Ok, CalendReady, alert, DateTime.Now.Year.ToString(), (DateTime.Now.Year - 1).ToString());
            }
            app.ScreenshotWait("End reset");
            try
            {
                app.Tap(Ok.ToUpper());
            }
            catch (Exception)
            {
                app.Tap(CalendReady);
            }
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "End period (--1) year");
            /* period: start -> hold, END -> to long FUTURE  */
            app.WaitForElementThreadTAP(ACons.Filter, "filter", Span, 10000);
            app.WaitForElementThreadTAP(ACons.PeriodEnd, "period end", Span);
            try
            {
                app.Tap((DateTime.Now.Year - 1).ToString());
                app.Tap((DateTime.Now.Year).ToString());
                app.Tap((DateTime.Now.Year).ToString());
                app.Tap((DateTime.Now.Year + 1).ToString());
            }
            catch (Exception)
            {
                TransactionHistoryLowAPI(app, Span, Ok, CalendReady, alert, (DateTime.Now.Year - 1).ToString(), (DateTime.Now.Year + 1).ToString());
            }
            app.ScreenshotWait("End reset");
            try
            {
                app.Tap(Ok.ToUpper());
            }
            catch (Exception)
            {
                app.Tap(CalendReady);
            }
            app.Tap(ACons.DateApply);
            app.ScreenshotWait(title: "End period (--1) year ALERT");
            app.Tap(alert);
            app.Tap(Ok);
            app.ScreenshotWait(title: "End period (--1) skip alert");
        }

        private static void TransactionHistoryLowAPI(IApp app, TimeSpan Span, string Ok, string CalendReady, string alert, string condition, string EnterText)
        {
            app.EnterText(x => x.Text(condition), EnterText);
        }

    }
}

