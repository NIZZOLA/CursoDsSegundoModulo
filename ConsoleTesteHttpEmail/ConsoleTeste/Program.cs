using System;
using System.Threading.Tasks;

namespace ConsoleTeste
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string texto = "O Palmeiras não tem mundial!";

            

            Console.WriteLine(Funcoes.FormataMaiusculo(texto));

            Console.WriteLine("Pós:" + texto);


            Console.WriteLine(Funcoes.FormataMinusculo(texto));

        //    var resposta = await Funcoes.ConsultaCep("13300170");

        //    Console.WriteLine(resposta);


            var resposta2 = Funcoes.SendMail("marcionizzola@gmail.com", "Prof Nizzola", "marcio.nizzola@etec.sp.gov.br", "Nizzola Prof", "marcionizzola@gmail.com",
                  "Jedi#76#", "smtp.gmail.com", true, "E-MAIL TESTE DA AULA", "O Palmeiras não tem mundial!");

            if (resposta2)
                Console.WriteLine("Sucesso no envio!");
            else
                Console.WriteLine("Erro no envio!");
        }

        

    }

    
}
