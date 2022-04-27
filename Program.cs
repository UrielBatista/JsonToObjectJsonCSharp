using oneTwoTree.ConvertJsonToObject;
using System;

namespace ConversorJsonToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            string d = "ConvertJsonToObjectCSharp\\JsonData.json";
            JsonToObjectCSharp.Executor(d);
        }
    }
}
