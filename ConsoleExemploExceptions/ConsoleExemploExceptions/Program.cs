using System;

namespace ConsoleExemploExceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            int numero;
            DateTime dia;

            dia = ReceberData("Digite o seu nascimento:");

            numero = ReceberNumero("Digite um número:");
            


            Console.WriteLine("Seu número:" + numero);
        }

        static int ReceberNumero( string frase )
        {
            int numero = 0;
            bool sucesso = false;
            do
            {
                try
                {
                    Console.WriteLine(frase);
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

        static DateTime ReceberData(string frase)
        {
            DateTime data = new DateTime();
            bool sucesso = false;
            do
            {
                try
                {
                    Console.WriteLine(frase);
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
