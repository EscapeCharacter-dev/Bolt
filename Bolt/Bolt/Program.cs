using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Shell;
using System;

namespace Bolt
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("IBolt>");
                string input = Console.ReadLine();
                input.TrimStart();
                input.TrimEnd();
                if (input.StartsWith("__pythonc__:"))
                {
                    ScriptEngine engine = Python.CreateEngine();
                    string pinput = input.Substring(input.IndexOf(':') + 1);
                    try
                    {
                        engine.Execute(pinput);
                    }
                    catch (Exception e)
                    {
                        ConsoleColor old = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Python: " + e.Message + "; (Line inserted) = " + pinput);
                        Console.ForegroundColor = old;
                    }
                }
            }
        }
    }
}
