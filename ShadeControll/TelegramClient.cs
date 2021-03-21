using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ShadeControll
{
    class TelegramClient
    {
        const string MY_ID_CHAT = "1623222858";

        static ITelegramBotClient botClient;
        static string Token = string.Empty;

        public delegate void NewMessageDelegate(string message);
        public event NewMessageDelegate NewMessage;

        public TelegramClient(string token)
        {
            Token = token;
        }

        public void CloseConnection()
        {
            botClient.StopReceiving();
        }

        public bool Connect()
        {
           try
           {
                botClient = new TelegramBotClient(Token);
                var me = botClient.GetMeAsync().Result;
                botClient.OnMessage += Bot_OnMessage;
                botClient.StartReceiving();
                return true;
           }
           catch
           {
                return false;
            }
        }

        public async void SendMessage(string _text)
        {
            await botClient.SendTextMessageAsync(
                chatId: MY_ID_CHAT,
                text: _text
                );
        }

        public async void Bot_OnMessage(object sender, MessageEventArgs e)
        {

                NewMessage(e.Message.Text);
        }
    }
}
