using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Services
{
    public static class Funcoes
    {
        public static int ReceberNumero(string frase)
        {
            int numero = 0;
            bool sucesso = false;
            do
            {
                try
                {
                    Console.Write(frase);
                    numero = Convert.ToInt32(Console.ReadLine());
                    sucesso = true;
                }
                catch (Exception error)
                {
                    Console.WriteLine("Ocorreu um erro:" + error.Message.ToString());
                }
            } while (!sucesso);

            return numero;
        }

        public static decimal ReceberDecimal(string frase)
        {
            decimal numero = 0;
            bool sucesso = false;
            do
            {
                try
                {
                    Console.Write(frase);
                    numero = Convert.ToDecimal(Console.ReadLine());
                    sucesso = true;
                }
                catch (Exception error)
                {
                    Console.WriteLine("Ocorreu um erro:" + error.Message.ToString());
                }
            } while (!sucesso);

            return numero;
        }



        public static DateTime ReceberData(string frase)
        {
            DateTime data = new DateTime();
            bool sucesso = false;
            do
            {
                try
                {
                    Console.Write(frase);
                    data = Convert.ToDateTime(Console.ReadLine());
                    sucesso = true;
                }
                catch (Exception error)
                {
                    Console.WriteLine("Ocorreu um erro:" + error.Message.ToString());
                }
            } while (!sucesso);

            return data;
        }

    }
}
