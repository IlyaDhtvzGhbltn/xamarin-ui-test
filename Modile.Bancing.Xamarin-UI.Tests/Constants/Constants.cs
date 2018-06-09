using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringConstants
{
    public class TestConstants
    {
        public Dictionary<string, User> Users { get; private set; }
        public TestConstants()
        {
            Users = new Dictionary<string, User>();
            Users["test"] = new User { Login = "test.1", Password = "C1S&CXu" };
            Users["laurs"] = new User { Login = "userlaura", Password = "rH1#Rr6"};
            Users["letmein"] = new User { Login = "letmein", Password="1" };
        }
    }

    public class AppConstantsLabels
    {
        public const string BtnEnter = "IDEnterApp";
        public const string TxbxLogin = "IDLogin";
        public const string TxbxPassword = "IDPass";
        public const string BtnFlexSave = "IDTransFS";
        public const string BtnTransactionHistory = "IDTransHistory";
        public const string BtnHomeView = "Button.Home";
        public const string BtnProductsView = "Button.Products";
        public const string BtnCardsView = "Button.Cards";
        public const string BtnTransfersView = "Button.Transfers";
        public const string BtnBack = "Button.Back";
        public const string LblBalance = "Avil";
        public const string LblTopAccounts = "Top.Accounts";
        public const string LblTopTermDeposit = "Top.TDeposits";
        public const string LblTopLoans = "Top.Loans";
        public const string LblTransfer = "IDOwnTransMake";
        public const string LblbAmountTransferConfirm = "IDOwnTrans";
        public const string BtnDebitAcc = "DebitAccount";
        public const string BtnCreditAcc = "CredititAccount";
        public const string TxtbTransferAmount = "Entry.Trans.Amount";
        public const string CurrentCardsAccount = "CurrAcc.ConnectCards";

        public const string BtnRefresh = "RefreshLabel";
        public const string LblWait = "LabelWait";

        public const string BtnBlockCard = "IDCardBlock";
        public const string BtnCardLimit = "IDCardLimit";
        public const string LimitsList = "LimitLists.DataTemplate";
        public const string LimitTxbx = "Limit.Entry";
        public const string BtnIsQueued = "Operation.Result.Button";
        public const string BtnNext = "Next.Button";
        public const string BtnConfirm = "Button.Confirm";

        public const string BtnOpenTermDeposit = "OpenTermDeposit";
        public const string BtnProductsMass = "Products.List";
        public const string BtnSelectTermDeposit = "SelectTermDeposit";
        public const string BtnSetCardLimit = "IDSetCardLimit";
        public const string TxbxEnterEmountDeposit = "Deposit.Entry.Amount";

        public const string Filter = "Filter";
        public const string PeriodStart = "Date.Start";
        public const string PeriodEnd = "Date.End";
        public const string DateApply = "Dates.Apply";

    }

    public class User 
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}