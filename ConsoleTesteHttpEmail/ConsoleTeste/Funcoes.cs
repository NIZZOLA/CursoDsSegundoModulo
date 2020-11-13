using ConsoleTeste.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleTeste
{
    public static class Funcoes
    {
        public static string FormataMaiusculo(string valor)
        {
            return valor.ToUpper().Trim();
        }
        public static string FormataMinusculo(string valor)
        {
            return valor.ToLower().Trim();
        }

        public async static Task<CepReponseModel> ConsultaCep(string cep)
        {
            HttpClient client = new HttpClient();
            CepReponseModel retorno = new CepReponseModel();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            try
            {
                HttpResponseMessage response = await client.GetAsync($"http://viacep.com.br/ws/{cep}/json/");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                retorno = JsonSerializer.Deserialize<CepReponseModel>(responseBody, options);
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return retorno;
        }

        public static bool SendMail( string fromEmail, string fromName , string toEmail, string toName , string senderEmail, string senderPassword , string host, bool sslEnable,
                            string subject, string messageBody )
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = host;
            client.EnableSsl = sslEnable;
            client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress(senderEmail, fromName);
            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(toEmail, toName));
            mail.Subject = subject;
            mail.Body = messageBody;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
                return true;
            }
            catch (System.Exception erro)
            {
                return false;
            }
        }

    }
}
