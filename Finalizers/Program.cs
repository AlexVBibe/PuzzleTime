using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalizers
{
    class Program
    {
        public static int counter = 0;

        public class BaseClass
        {
            ~BaseClass()
            {
                counter++;
            }
        }

        public class DerrivedClass : BaseClass
        {
            ~DerrivedClass()
            {
                counter++;
                GC.SuppressFinalize(this);
            }
        }

        static void Main(string[] args)
        {
            BaseClass cls = new DerrivedClass();

            cls = null;
            GC.Collect();
        }
    }
}
