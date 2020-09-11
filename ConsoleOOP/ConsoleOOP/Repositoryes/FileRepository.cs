using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleOOP.Repositoryes
{
    public static class FileRepository
    {
        public static void Gravar(string nomeDoArquivo, string dados )
        {
            using (StreamWriter file = new StreamWriter(nomeDoArquivo, true))
            {
                file.WriteLine(dados);
                file.Close();
            }
        }

        public static List<string> Ler( string nomeDoArquivo)
        {
            // foi criada uma lista de strings vazia
            List<string> retorno = new List<string>();
            try
            {
                using (var reader = new StreamReader(nomeDoArquivo)) // abre o arquivo
                {
                    var line = reader.ReadLine();  // lê 1 linha
                    while (line != null)           // executa a repetição enquanto a linha for diferente de nulo (condição fim)
                    {
                        retorno.Add(line);         // adiciona a linha na lista de retorno
                        line = reader.ReadLine();  // lê uma nova linha
                    }
                    return retorno;                // devolve a lista de linhas lidas
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Houve erro na abertura do seu arquivo !" + erro.Message.ToString());
                return null;
            }

        }


    }
}
