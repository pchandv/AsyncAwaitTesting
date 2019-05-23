using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynAwaitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var asy = new Extensions();
            Console.WriteLine("Main Thread Started");
            //new Maker().TriggerAsync("Hello");

            Func<string, string> func = new Maker().Greetings;

            var t = asy.GenericAsyncCall<string, string>(func, "Chandu");
            Func<int, int> func2 = new Maker().GreetingsMoring;
            var t2 = asy.GenericAsyncCall<int,int>(func2, 786445);
            
            Console.WriteLine("Main Thread Ended");
            Console.ReadKey();
        }

       
    }

    public class Extensions
    {
        public async Task<T2> GenericAsyncCall<T1, T2>(Func<T1,T2> GenericMethod, T1 input)
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
                    Console.WriteLine("Child Thread -1 Initiated");
                    var result = client.DownloadString("https://jsonplaceholder.typicode.com/comments");
                    Console.WriteLine("Child Thread -1 ended -Data Downloaded --Message: " + s);
                    Console.WriteLine("Child Thread -2 Initiated");
                    var result2 = client.DownloadString("https://jsonplaceholder.typicode.com/photos");
                    Console.WriteLine("Child Thread -2 ended -Data Downloaded --Message: "+s);
                }
            });
        }

        public string Greetings(string name)
        {
            Thread.Sleep(5000);
           
            Console.WriteLine( "Welcome " + name + " for Asyncornus Programming (Async and Await) in C# world");
           
            fc.ReadWrite(name);
            return "Welcome " + name + " for Asyncornus Programming (Async and Await) in C# world";
        }

        public int GreetingsMoring(int number)
        {
            Thread.Sleep(10000);
            Console.WriteLine("{0}: Numbe is print",number);
            fc.ReadWrite(string.Format("{0}: Numbe is print", number));
            return number;// "Welcome " + name + " for Asyncornus Programming (Async and Await) in C# world";
        }



    }






}
