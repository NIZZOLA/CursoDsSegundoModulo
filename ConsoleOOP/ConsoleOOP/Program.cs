using ConsoleOOP.Models;
using ConsoleOOP.Services;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            var mainService = new ServiceOrchestrator();
            mainService.TelaPrincipal();
            

        }
    }
}
