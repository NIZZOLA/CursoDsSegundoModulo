using ConsoleAppAulaObj.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;

namespace ConsoleAppAulaObj
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestarStrings();
            TestarDatas();
            
        }

        private static void TestarDatas()
        {
            var inicio = DateTime.Now;
            Console.Write("Digite uma data: dd/mm/yyyy ");
            var strData = Console.ReadLine();
            var fim = DateTime.Now;

            DateTime minhaData = Convert.ToDateTime(strData);

            string texto = $" A data é: {minhaData.ToShortDateString()} Completa:{minhaData.ToString()}" +
                           $"\n Dia: {minhaData.Day} Mês: {minhaData.Month} Ano: {minhaData.Year} Dia da semana: {minhaData.DayOfWeek} ";

            Console.WriteLine(texto);

            Console.WriteLine("Inicio:" + inicio + " Termino:" + fim + " Diferença:" + fim.Subtract(inicio). );

        }

        private static void TestarStrings()
        {
            Console.Write("Digite uma string");
            string frase = Console.ReadLine();

            // tudo em maiúsculas

            Console.WriteLine("Maiúsculas:" + frase.ToUpper());

            Console.WriteLine("Minúsculas:" + frase.ToLower());

            Console.WriteLine("A frase tem:" + frase.Length + " caracteres ");

            Console.WriteLine("A frase ao contrário é:" + new string(frase.Reverse().ToArray()));

            Console.WriteLine("Trocando palavras:" + frase.Replace("PALMEIRAS", "CORINTHIANS"));

            Console.WriteLine("Cortando os 10 primeiros caracteres:" + frase.Substring(0, 10));

            var nomes = frase.Split(' ');
            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Primeiro nome:" + nomes[0] + " Sobrenome:" + nomes[nomes.Length - 1]);


            Console.WriteLine("Tem silva:" + frase.IndexOf("SILVA"));

            Console.WriteLine($"frase normal ({frase}) sem espaços depois ({frase.Trim()})");

            if (frase == frase.Trim())
            {
                Console.Write("Iguais");
            }
            else
            {
                Console.Write("Diferentes");
            }

            var frase2 = string.Join("/", nomes);
            Console.Write("Novamente agrupado:" + frase2);

        }


        private static void TestarClassesEListas()
        {
            string resposta;
            List<Pessoa> lista = new List<Pessoa>();
            bool continua = true;


            do
            {
                Pessoa pes = new Pessoa();

                Console.Write("Digite o nome da pessoa:");
                pes.Nome = Console.ReadLine();

                Console.Write("Email:");
                pes.Email = Console.ReadLine();

                Console.Write("Sexo (M/F):");
                pes.Sexo = Convert.ToChar(Console.ReadLine());


                do
                {
                    Console.Write("Deseja receber mais pessoas (S/N) ?");
                    resposta = Console.ReadLine();
                    if (resposta.ToUpper() == "N")
                        continua = false;

                } while (resposta.ToUpper() != "S" && resposta.ToUpper() != "N");

                lista.Add(pes);  // adiciona uma pessoa à lista
                //lista.Add(new Pessoa() { Nome = pes.Nome, Email = pes.Email });

            } while (continua);

            Console.WriteLine($"Recebemos : {lista.Count} pessoas ");

        }


        /*
        private static char ReceberPergunta( string opcoes, string frase )
        {
            string resposta;
            do
            {
                Console.Write( frase + "(" + opcoes + ")" );
                resposta = Console.ReadLine();

            } while (resposta.ToUpper() != "S" && resposta.ToUpper() != "N");


        }*/
    }
}
