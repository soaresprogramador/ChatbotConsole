using Google.Cloud.Dialogflow.V2;
using System;
using Telegram.Bot;

namespace ConsoleApp1
{
    class Program
    {
        static readonly TelegramBotClient BotClient = new TelegramBotClient("1322198246:AAF3vSNrhCdHw-3uO1PJBHQI0txFUAHAX_I");
        static void Main(string[] args)
        {
            BotClient.StartReceiving();
            BotClient.OnMessage += BotClient_OnMessage;

            Console.ReadLine();
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            DateTime tempo = DateTime.Now;
            string tempoSaudacao = "";

            if (tempo.Hour > 6 && tempo.Hour < 12)
            {
                tempoSaudacao = "Bom dia";
            }
            else if (tempo.Hour >= 12 && tempo.Hour < 18)
            {
                tempoSaudacao = "Boa tarde";
            }
            else
            {
                tempoSaudacao = "Boa noite";
            }            

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                BotClient.SendTextMessageAsync(e.Message.Chat.Id, $"{tempoSaudacao} {e.Message.Chat.Username}!\nSou o Bot do Banco Carrefour.\n Posso te ajudar tirando algumas dúvidas sobre os produtos do Banco Carrefour.\nNo que posso te ajudar?");               
            }

            /*protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            Activity respostaApp = ((Activity)turnContext.Activity).CreateReply();

            

            var card = new HeroCard()
            {
                Text = "**Lembre-se que você pode consultar seu limite, ter acesso a sua fatura e lan�amentos futuros pelo aplicativo do Banco Carrefour.**",
                Buttons = new List<CardAction>
                    {
                        new CardAction(ActionTypes.OpenUrl,"Veja as vantagens do App", value: "https://www.carrefoursolucoes.com.br/app")
                    },
            };

            var reply = MessageFactory.Attachment(card.ToAttachment());

            var welcomeText = $"{tempoSaudacao}! Sou o Bot do Banco Carrefour.\n Posso te ajudar tirando algumas d�vidas sobre os produtos do Banco Carrefour.\nNo que posso te ajudar?";

            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(reply, cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }

        }*/
        }
    }
}
