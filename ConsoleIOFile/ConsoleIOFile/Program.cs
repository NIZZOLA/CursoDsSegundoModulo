using System;
using System.IO;

namespace ConsoleIOFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // GRAVA UMA SIMPLES LINHA CONTENDO O TEXTO
            /*            Console.WriteLine("Digite um texto:");
                        var texto = Console.ReadLine();
                        File.WriteAllText("teste1.txt", texto);

                        File.WriteAllText("teste1.txt", texto + " TENTATIVA 2");
            */

            string[] times = { "São Paulo", "Palmeiras", "Corintia", "Santos", "Ituano", "Ponte Preta", "Guarani" };
            File.WriteAllLines("teste2.txt", times);


            // realiza a abertura do arquivo utilizando um streamwriter e pode acrescentar várias linhas até dar o comando close.
            StreamWriter file = new StreamWriter("teste3.txt");

            file.WriteLine("RELAÇÃO DOS TIMES DE SP");

            int cont = 0;
            foreach (var item in times)
            {
                cont++;
                file.WriteLine(cont + " " + item);
            }
            // fecha o arquivo que estava aberto
            file.Close();

            // O Parâmetro true no streamWriter indica que vai complementar um arquivo já existente (append)
            StreamWriter file2 = new StreamWriter("teste2.txt", true);
            file2.WriteLine("TESTANDO MAIS UMA LINHA INSERIDA");
            file2.Close();


            using (StreamWriter file3 = new StreamWriter("teste4.txt"))
            {
                file3.WriteLine("TESTANDO GRAVAR COM USING");
            }

            StreamReader reader;
            // LEITURA DE ARQUIVOS TEXTO
            try
            {
                reader = new StreamReader("teste3.txt");
                string texto = "";
                var line = reader.ReadLine();
                while (line != null)
                {
                    texto += "\n" + line;
                    //Console.WriteLine(line);
                    line = reader.ReadLine();
                }
                reader.Close();
                Console.WriteLine(texto);
            }
            catch (Exception erro)
            {
                Console.WriteLine("Houve erro na abertura do seu arquivo !" + erro.Message.ToString());
            }


            

        }
    }
}
