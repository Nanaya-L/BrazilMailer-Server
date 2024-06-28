using System.Text;
using System.Text.Json;

namespace Services
{
    public class MailerService: IMailerService
    {
        private readonly HttpClient httpClient = new();
        private readonly string mailerURL = ReturnMailerUrl();
        private string token = ReturnMailerCredentials();


        public void SendMail(SendMailDTO options)
        {
            var sendMailURL = mailerURL + "transporter-emails";
            var emails = options.emails;

            var data = new { token, emails }; 

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(sendMailURL, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Envio de email não pode ser realizada. Erro: " + response.Content.ToString());
            }
        }


        //Fiz desta maneira pra implementar melhoras práticas de retorno de variáveis no futuro pois sei que deixar fixo no código é má prática
        private static string ReturnMailerUrl()
        {
            string url = "http://localhost:8080/";

            return url;
        }

        private static string ReturnMailerCredentials()
        {
            string token = "Insira seu token válido aqui";

            return token;
        }    
    }
        public interface IMailerService {
            public void SendMail(SendMailDTO options);
        }
}
