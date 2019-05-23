using AsyncWebApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsyncWebApp
{
    public partial class ProcessTheRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            FileCreation fc = new FileCreation();
            var asy = new AsynLibo();
            fc.ReadWrite("Main Thread Started");
            Response.Write("Main Thread Started");
            Maker mk = new Maker();
            Func<string, Task> webre= mk.MakeWebCallAsync;
            var s=asy.GenericAsyncCall<string, Task>(webre, "Chandu");


            Func<string, string> func = new Maker().Greetings;

            var t = asy.GenericAsyncCall<string, string>(func, "Chandu");
            Func<int, int> func2 = new Maker().GreetingsMoring;
            var t2 = asy.GenericAsyncCall<int, int>(func2, 786445);
            fc.ReadWrite("Main Thread Ended");
            Response.Write("Main Thread Ended");
            
            Thread.Sleep(2000);
            Response.Redirect("ProcessingMessage.aspx",false);
        }
    }
}