using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Services
{
    public class MailerService: IMailerService
    {
        private readonly HttpClient httpClient = new();
        private readonly string mailerURL = ReturnMailerUrl();
        private readonly object credentials = ReturnMailerCredentials();
        private string mailerToken;

        public MailerService()
        {
            mailerToken = AuthenticateMailer();
        }

        public void SendMail(SendMailDTO options)
        {
            var sendMailURL = mailerURL + "transporter-emails";

            var json = JsonSerializer.Serialize(options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(sendMailURL, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Envio de email não pode ser realizada. Erro: " + response.Content.ToString());
            }
        }


        public string AuthenticateMailer()
        {
            var authURL = mailerURL + "auth/login";

            var json = JsonSerializer.Serialize(credentials);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(authURL, content).Result;

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Autenticação de serviço de email não pode ser realizada. Erro: " + response.Content.ToString());
            }

            var mailerAuth = response.Content.ReadFromJsonAsync<AuthenticationDTO>().Result;

            if (mailerAuth== null)
            {
                throw new Exception("Autenticação de serviço de email não pode ser realizada. Erro (retorno nulo): " + response.Content.ToString());
            }

            return mailerAuth.accessToken;
        }

        //Fiz desta maneira pra implementar melhoras práticas de retorno de variáveis no futuro pois sei que deixar fixo no código é má prática
        private static string ReturnMailerUrl()
        {
            string url = "http://localhost:8080/";

            return url;
        }

        private static object ReturnMailerCredentials()
        {
            string email = "admin@gmail.com";
            string password = "123123123";

            object credentials = new { email, password };

            return credentials;
        }    
    }
        public interface IMailerService {
            public string AuthenticateMailer();
            public void SendMail(SendMailDTO options);
        }
}
