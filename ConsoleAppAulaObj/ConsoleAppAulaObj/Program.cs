using ConsoleAppAulaObj.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO.Pipes;
using System.Linq;
using System.Net;

namespace ConsoleAppAulaObj
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestarStrings();
            //TestarDatas();
            //Parcelamento();
            //TestarClassesEListas();
            //MultiplosDe3();
            TesteHeranca();
        }

        private static void TesteHeranca()
        {
            Funcionario fun = new Funcionario();

            fun.Nome = "MARCIO";
            fun.EnderecoDeentrega.Rua = "ALAMEDA XPTO";


            Pessoa pes = new Pessoa();
            pes = fun;


            Empresa emp = new Empresa();
            emp.Funcionarios.Add( fun );

            

        }


        private static void MultiplosDe3()
        {
            
            for( var numero = 1; numero <= 100; numero ++ )
            {
                var result2 = numero - (Convert.ToInt32(numero / 3) * 3);
                
                var result = numero % 3;
                if( result == 0)
                    Console.WriteLine(numero);
            }


        }


        private static void Parcelamento()
        {
            Console.Write("Deseja calcular quantos meses ?");
            int meses = Convert.ToInt32( Console.ReadLine() );
            
            var hoje = DateTime.Now;

            for( var contador =1; contador <= meses; contador ++ )
            {
                var dia = hoje.Day;
                var mes = hoje.Month +1;
                var ano = hoje.Year;
                if ( mes == 13)
                {
                    mes = 1;
                    ano ++;
                }
                
                var novadata = DateTime.Parse(dia + "/" + mes + "/" + ano);
                hoje = novadata;

                Console.WriteLine($" {contador}º mês:" + hoje );
            }

        }


        private static void TestarDatas()
        {
            var inicio = DateTime.Now;
            Console.Write("Digite uma data: dd/mm/yyyy ");
            var strData = Console.ReadLine();
            var fim = DateTime.Now;

            DateTime minhaData = Convert.ToDateTime(strData);

            var diferenca = inicio.Subtract(minhaData);

            string texto = $" A data é: {minhaData.ToShortDateString()} Completa:{minhaData.ToString()}" +
                           $"\n Dia: {minhaData.Day} Mês: {minhaData.Month} Ano: {minhaData.Year} Dia da semana: {minhaData.DayOfWeek} " +
                           $"\n Idade dias: {diferenca.Days} meses: {diferenca.Days / 30} anos: {diferenca.Days / 365} ";


            Console.WriteLine(texto);

            Console.WriteLine("Inicio:" + inicio + " Termino:" + fim + " Diferença:" + fim.Subtract(inicio) );

            Console.WriteLine("Exibir com formatação dd/mm/yyyy " + inicio.ToString("dd/MM/yyyy") + " original:" + inicio.ToString() );
            Console.WriteLine("somente a data" + inicio.ToShortDateString() + " original:" + inicio.ToShortTimeString());

            Console.WriteLine("Adicionando 1 ano na data de hoje:" + inicio.AddYears(1));

            var dia = inicio.Day;
            var mes = inicio.Month;
            var ano = inicio.Year;
            var hora = inicio.Hour;
            var min = inicio.Minute;
            var sec = inicio.Second;



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

                //  Este código foi comentado para demonstrar a substituição realizada abaixo minimizando o numero de linhas
                // Console.Write("Sexo (M/F):");
                // pes.Sexo = Convert.ToChar(Console.ReadLine());
                pes.Sexo = ReceberPergunta("M/F", "Digite o sexo");
                
                char resposta2 = ReceberPergunta("S/N", "Deseja receber mais pessoas");
                if (resposta2 == 'N')
                    continua = false;
                
                
                /*  Este código foi comentado para demonstrar a substituição realizada acima minimizando o numero de linhas
                do
                {
                    Console.Write("Deseja receber mais pessoas (S/N) ?");
                    resposta = Console.ReadLine();
                    if (resposta.ToUpper() == "N")
                        continua = false;

                } while (resposta.ToUpper() != "S" && resposta.ToUpper() != "N");
                */
                lista.Add(pes);  // adiciona uma pessoa à lista
                //lista.Add(new Pessoa() { Nome = pes.Nome, Email = pes.Email });

            } while (continua);

            Console.WriteLine($"Recebemos : {lista.Count} pessoas ");

        }


        
        private static char ReceberPergunta( string opcoes, string frase )
        {
            string resposta;
            do
            {
                Console.Write( frase + "(" + opcoes + ") ? " );
                resposta = Console.ReadLine().ToUpper();
                if( resposta.Length > 1 )
                {
                    Console.WriteLine("Você deve digitar apenas 1 caractere !");
                }
                if( ! opcoes.Contains(resposta) )
                {
                    Console.WriteLine("Você deve digitar " + opcoes);
                }

            } while ( ! opcoes.Contains( resposta ) );
            return Convert.ToChar(resposta);
        }
    }
}
