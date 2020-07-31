using Google.Apis.Auth.OAuth2;
using Google.Cloud.Dialogflow.V2;
using Grpc.Auth;

namespace ConsoleApp1
{
    class DialogConfig
    {
        public void Credentials()
        {
            var query = new QueryInput
            {
                Text = new TextInput
                {
                    Text = "Olá",
                    LanguageCode = "pt-br"
                }
            };

            var sessionId = "123456";
            var agent = "bancocarrefourbot-brcx";
            var creds = GoogleCredential.FromJson("{./credentialDialog.json}");
            var channel = new Grpc.Core.Channel(SessionsClient.DefaultEndpoint, creds.ToChannelCredentials());

            var client = SessionsClient.Create();

            var dialogFlow = client.DetectIntent(
                new SessionName(agent, sessionId),
                query
            );
            channel.ShutdownAsync();

        }

    }
}
