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
            ClienteService servico = new ClienteService();
            servico.Processar();

        }
    }
}
