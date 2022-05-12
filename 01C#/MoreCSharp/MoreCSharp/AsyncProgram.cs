using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreCSharp
{
    internal class AsyncProgram
    {
        public void LongMethod()
        {
            Console.WriteLine("--Begin Long Method--");
            Thread.Sleep(5000);
            Console.WriteLine("--Ending Method--");
        }

        public async void CallMethod()
        {
            Console.WriteLine("--inside CallMethod");
            await Task.Run(new Action(LongMethod));
            Console.WriteLine("--CallMethod finished execution--");
        }
    }
}
