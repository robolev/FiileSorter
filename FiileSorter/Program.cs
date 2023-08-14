using System;
using System.IO;
using FiileSorterApp;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSorterApp fileSorterApp = new();
            fileSorterApp.Initialize();
            fileSorterApp.Run();
        }
    }
}