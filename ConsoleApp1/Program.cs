using System;
using Telegram.Bot;

namespace ConsoleApp1
{
    class Program
    {
        //Autenticação do client
        static readonly TelegramBotClient BotClient = new TelegramBotClient("Insert Telegram Bot Token");
        static void Main(string[] args)
        {
            BotClient.StartReceiving();
            BotClient.OnMessage += BotClient_OnMessage;

            Console.ReadLine();
        }

        //Identificação do recebimento das mensagens
        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            //Verificação do horário para a saudação
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
             
            //Array com algumas dúvidas
            string[] duvidas = 
                { "Fechamento da fatura", "Vencimento do cartão", "Vencimento da fatura", "Fechamento", "Fatura", "Vencimento", "fechamento da fatura", 
                "vencimento do cartão", "vencimento da fatura", "fechamento", "fatura", "vencimento", "Parcele fácil", "parcele fácil", "parcelar", "Parcelar", "parcele", "Parcele", 
                "SMS", "sms", "SMS controle total", "Sms controle total", "Sms", "sms controle total", "App", "app", "App cartão Carrefour", "App Cartão Carrefour", "app cartão carrefour", "Aplicativo cartão Carrefour", "Aplicativo Cartão Carrefour", 
                "aplicativo cartão carrefour", "Aplicativo", "Aplicativo cartão", "Aplicativo Cartão", "aplicativo"};


            //Verificação se a mensagem é um texto
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text.Contains("/") || e.Message.Text == "Oi" || e.Message.Text == "oi" || e.Message.Text == "Bom dia" || e.Message.Text == "bom dia" || e.Message.Text == "Boa tarde" || e.Message.Text == "boa tarde" || e.Message.Text == "Boa noite" || e.Message.Text == "boa noite")
                {
                    var saudacao = $"{tempoSaudacao} {e.Message.Chat.Username}!\nSou o Bot do Banco Carrefour.\n Posso te ajudar tirando algumas dúvidas sobre os produtos do Banco Carrefour.\nDiga em poucas palavras no que posso te ajudar?";
                    BotClient.SendTextMessageAsync(e.Message.Chat.Id, saudacao);
                    BotClient.SendTextMessageAsync(e.Message.Chat.Id, "**Lembre-se que você pode consultar seu limite, ter acesso a sua fatura e lançamentos futuros pelo aplicativo do Banco Carrefour.***\nhttps://www.carrefoursolucoes.com.br/app");
                }

                //Verificação da dúvida com o array de dúvidas e sua respectiva resposta
                foreach (string fatura in duvidas)
                {
                    if (e.Message.Text == fatura)
                    {
                        if (fatura == "Fechamento da fatura" || fatura == "Vencimento do cartão" || fatura == "Vencimento da fatura" || fatura == "Fechamento" || fatura == "Fatura" || fatura == "Vencimento" || fatura == "fechamento da fatura" || fatura == "vencimento do cartão" || fatura == "vencimento da fatura" || fatura == "fechamento" || fatura == "fatura" || fatura == "vencimento" )
                        {
                            BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Caso você optou por receber a fatura por email, enviaremos dois avisos gratuitos via SMS.\nAvisaremos a data de fechamento da sua fatura. Assim você pode se programar e ter mais prazo para pagar suas compras.\n***Lembre-se que você pode consultar seu limite, ter acesso a sua fatura e lançamentos futuros pelo aplicativo do Banco Carrefour.***\nhttps://www.carrefoursolucoes.com.br/app");
                        }

                        if (fatura == "Parcele fácil" || fatura == "parcele fácil" || fatura == "parcelar" || fatura == "Parcelar" || fatura == "parcele" || fatura == "Parcele")
                        {
                            BotClient.SendTextMessageAsync(e.Message.Chat.Id, "**FATURA E TERMINAL DE AUTOATENDIMENTO**\nNesse Canal, você tem até 8 opções de parcelamento.\n\n1) Escolha uma das opções disponíveis.\n2) Pague o valor exato da entrada em um banco, lotérica ou em uma de nossas lojas até a data de vencimento.\n3) Pronto! parcelamento contratado.\n\n**SITE OU CENTRAL DE ATENDIMENTO**\n1) Simule a opção de parcelamento ideal para você. Caso as opções predefinidas não atendam a sua necessidade, você pode simular até chegar à melhor opção.\n2) Confirme a contratação do parcelamento.\n3) Se optar pelo plano com entrada, pague exatamente o valor escolhido em um banco, lotérica ou em nossas lojas até a data de vencimento.\n4) Pronto! parcelamento contratado..\n***Lembre-se que você pode consultar seu limite, ter acesso a sua fatura e lançamentos futuros pelo aplicativo do Banco Carrefour.***\nhttps://www.carrefoursolucoes.com.br/app");
                        }

                        if (fatura == "SMS" || fatura == "sms" || fatura == "SMS controle total" || fatura == "Sms controle total" || fatura == "Sms" || fatura == "sms controle total")
                        {
                            BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Acompanhe a movimentação do seu cartão de crédito Carrefour, ao receber um SMS, no seu celular, a cada transação efetuada. Assim, você tem segurança e controle de suas compras e dos seus adicionais.\n**QUAIS AS VANTAGENS DO SMS CONTROLE?**\nCom este serviço, você recebe mensagens com as principais informações sobre:\n\na) Transações de compras aprovadas em território nacional.\n\nb) Valor, hora e local que foi realizado um saque\n\nc) Transações de pagamentos efetuados.\n\nd) Informativo com o valor e data de vencimento da fatura, além da confirmação da efetivação do pagamento.\n\nVocê pode contratar o SMS Controle no Site, estandes das Lojas Carrefour, Central de Atendimento e Terminais de autoatendimento.");
                        }
                        if (fatura == "App" || fatura == "app" || fatura == "App cartão Carrefour" || fatura == "App Cartão Carrefour" || fatura == "app cartão carrefour" || fatura == "Aplicativo cartão Carrefour" || fatura == "Aplicativo Cartão Carrefour" || fatura == "aplicativo cartão carrefour" || fatura == "Aplicativo" || fatura == "Aplicativo cartão" || fatura == "Aplicativo Cartão" || fatura == "aplicativo")
                        {
                            BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Com o App Cartão Carrefour você pode consultar seu limite, ter acesso a sua fatura e lançamentos futuros pelo aplicativo do Banco Carrefour.\nInstale e aproveite os benefícios do App Cartão Carrefour.\nhttps://www.carrefoursolucoes.com.br/app");
                        }
                    }
                }
            }            
        }
    }
}
    
