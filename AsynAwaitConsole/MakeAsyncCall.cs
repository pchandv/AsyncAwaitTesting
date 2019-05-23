using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynAwaitConsole
{
    public class MakeAsyncCall<T1,T2>
    {
       
        public MakeAsyncCall()
        {

        }



            public  async Task<T2> GenericAsyncCall(Func<T1, T2> GenericMethod, T1 input)
            {
                var _output = await Task.Factory.StartNew(() => {
                    var output = GenericMethod.Invoke(input);
                    return output;
                });
                return (T2)_output;
            }
        public string ge2(string s) { return s; }
    }
}
