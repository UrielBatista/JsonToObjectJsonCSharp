using oneTwoTree.ConvertJsonToObject;
using System.Reflection;

namespace ConversorJsonToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var CurrentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var newCurrentDirectory = CurrentDirectory.Replace("\\bin\\Debug\\netcoreapp3.1", "\\ConvertJsonToObjectCSharp");
            JsonToObjectCSharp.Executor(newCurrentDirectory);
        }
    }
}
