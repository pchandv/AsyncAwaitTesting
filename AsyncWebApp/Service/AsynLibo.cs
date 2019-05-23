using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AsyncWebApp.Service
{
    public class AsynLibo
    {
        public async Task<T2> GenericAsyncCall<T1, T2>(Func<T1, T2> GenericMethod, T1 input)
        {
            var _output = await Task.Factory.StartNew(() => {
                var output = GenericMethod.Invoke(input);
                return output;
            });

            return (T2)_output;
        }

    }

    public class Maker
    {
        FileCreation fc = new FileCreation();

        public async void TriggerAsync(string s)
        {
            await MakeWebCallAsync(s);// Task.Run(new Action(MakeWebCall));
                                      //MakeWebCall();
        }

        public Task MakeWebCallAsync(string s)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    fc.ReadWrite("Child Thread -1 Initiated");
                    var result = client.DownloadString("https://jsonplaceholder.typicode.com/comments");
                  //  fc.ReadWrite(result);
                    fc.ReadWrite("Child Thread -1 ended -Data Downloaded --Message: " + s);
                    fc.ReadWrite("Child Thread -2 Initiated");
                    var result2 = client.DownloadString("https://jsonplaceholder.typicode.com/photos");
                    //fc.ReadWrite(result2);
                    fc.ReadWrite("Child Thread -2 ended -Data Downloaded --Message: " + s);
                }
            });
        }

        public string Greetings(string name)
        {
            Thread.Sleep(30000);

            fc.ReadWrite("Welcome " + name + " for Asyncornus Programming (Async and Await) in C# world");

            //fc.Create(name);
            return "Welcome " + name + " for Asyncornus Programming (Async and Await) in C# world";
        }

        public int GreetingsMoring(int number)
        {
            Thread.Sleep(45000);
            fc.ReadWrite(string.Format("{0}: Number is print", number));
           // fc.Create(string.Format("{0}: Number is print", number));
            return number;// "Welcome " + name + " for Asyncornus Programming (Async and Await) in C# world";
        }



    }
}