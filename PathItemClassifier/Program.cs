using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNSharp;

namespace PathItemClassifier
{
    class Program
    {
        static void Main(string[] args)
        {
            POEAPI_Wrapper.POEAPIAllStashQuery();
            Console.ReadLine();
        }
    }
}
