using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");

            // como se define variáveis de tipos diferentes com c#

            int numero;
            numero = 50;

            int numero2 = 100;

            double numero3 = 100.5;

            numero3 = 180.50;

            decimal numero4 = 100.5M;

            numero4 = 233.33M;

            char letra = 'A';

            bool resultado = true;
            resultado = false;

            string nome = "MARIA JOSE DA SILVA SANTOS";

            DateTime nascimento = DateTime.Parse("01/01/2000");

            // operações matemáticas  com tipos iguais  (int + int)
            numero = numero + numero2;

            // variável destino do tipo Int, requer operações matemáticas com conversão de tipos  (int + double )
            numero = numero + Convert.ToInt32(numero3);

            // conversão tipando a variável com Cast
            numero = numero + (int)numero3;

            // a variavel do tipo double aceita sem conversão (int + double)
            numero3 = numero + numero3;

            // variável destino do tipo Int, requer operações matemáticas com conversão de tipos (int + decimal)
            numero = numero + Convert.ToInt32( numero4);

            // a variavel do tipo decimal aceita sem conversão (int + decimal)
            numero4 = numero + numero4;

            // conversão de double para decimal
            numero4 = numero + (decimal) numero3;
            numero4 = numero + Convert.ToDecimal(numero3);

            // conversão de decimal para double
            numero3 = numero + (double) numero4;
            numero3 = numero + Convert.ToDouble(numero4);

            // concatenação de strings
            nome = nome + " " + numero3;
            Console.WriteLine(nome);
            
            var nome = "MARCIO ROGERIO NIZZOLA";

            var nota = 10;

            nota = nota / 3;

            Console.WriteLine("Nota:" + nota);
            */
            //ExercicioNotas();
            //      ExercicioTabuadaFor();
            //     ExercicioTabuadaDo();
            //    ExercicioTabuadaWhile();
            
            //Categorias();
            // ArrayNomes();
            ListaNomes();

            

        }


        private static void ArrayNomes()
        {
            string[] nomes = new string[] { "Marcio", "Júlia", "Ana Beatriz", "Douglas", "Stephanie", "José Ronário", "José Nazareno" };

            string[] nomes2 = new string[50];
            int quantidade;

            Console.Write("Digite a quantidade:");
            quantidade = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= quantidade; i++)
            {
                Console.Write($"Digite o {i}º nome:");
                nomes2[i-1] = Console.ReadLine();
            }

            nomes2[10] = "ETEC ITU";

            Console.ReadKey();

        }

        private static void ListaNomes()
        {
            List<string> listaNomes = new List<string>();

            int quantidade;
            Console.Write("Digite a quantidade:");
            quantidade = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= quantidade; i++)
            {
                Console.Write($"Digite o {i}º nome:");
                var nome = Console.ReadLine();
                listaNomes.Add( nome );
            }

            listaNomes.Remove("JOSÉ");

            foreach (var item in listaNomes)
            {
                Console.WriteLine($"==> {item} <== ");
            }
            
         //   listaNomes.Clear();
            
            Console.ReadKey();

        }



        private static void Categorias()
        {
            Console.WriteLine("Digite a Categoria");
            string cat = Console.ReadLine();

            switch (cat)
            {
                case "a":
                case "A":
                    Console.WriteLine("R$ 10,00");
                    break;
                case "B":
                    Console.WriteLine("R$ 12,00");
                    break;
                case "C":
                    Console.WriteLine("R$ 14,00");
                    break;
                default:
                    Console.WriteLine("R$ 20,00");
                    break;
            }
        }

        private static void ExercicioTabuadaDo()
        {
            int numero, resultado;

            Console.WriteLine("Digite o número:");
            numero = Convert.ToInt32(Console.ReadLine());

            // exemplo com do While (teste no final)
            int contador =1;
            do
            {
                Console.WriteLine(  $" {numero} x {contador} = { (numero * contador) } " );
                contador++;
            } while (contador <= 10);
        }

        private static void ExercicioTabuadaWhile()
        {
            int numero, resultado;

            Console.WriteLine("Digite o número:");
            numero = Convert.ToInt32(Console.ReadLine());

            // exemplo com do While (teste no final)
            int contador = 1;
            while (contador <= 10)
            {
                Console.WriteLine($" {numero} x {contador} = { (numero * contador) } ");
                contador++;
            }

      

        }

        private static void ExercicioTabuadaFor()
        {
            int numero;

            Console.WriteLine("Digite o número:");
            numero = Convert.ToInt32(Console.ReadLine());

            //exemplo com for
            for (int contador = 1; contador <= 10; contador++)
            {
                Console.WriteLine(numero + " x " + contador + " = " + (numero * contador));
            }
            Console.ReadKey();

        }

        private static void ExercicioNotas()
        {
            double nota1, nota2, nota3, media;
            string nome;

            Console.Write("Digite o nome do aluno:");
            nome = Console.ReadLine();

            Console.Write("Digite a 1ª nota:");
            nota1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite a 2ª nota:");
            nota2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite a 3ª nota:");
            nota3 = Convert.ToDouble(Console.ReadLine());

            media = (nota1 + nota2 + nota3) / 3;

            Console.WriteLine("A média do aluno:" + nome + " é:" + media.ToString("#0.00"));

            if (media < 5)
            {
                Console.WriteLine("Aluno reprovado ! Menção I");
                Console.WriteLine("Vai estudar mais !!!");
            }
            else if (media < 7)
                Console.WriteLine("Aluno aprovado ! Menção R");
            else if (media < 8.5)
                Console.WriteLine("Aluno aprovado ! Menção B");
            else
                Console.WriteLine("Aluno aprovado ! Menção MB");

            Console.ReadKey();

        }

    }
}
