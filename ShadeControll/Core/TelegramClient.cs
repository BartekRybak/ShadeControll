using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

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
            Program.loger.Log(">> " + _text + Environment.NewLine);
            await botClient.SendTextMessageAsync(
                chatId: MY_ID_CHAT,
                text: _text
                );
        }

        public async void SendImage(string image,string caption)
        {
            Program.loger.Log(">> [SENDING IMAGE] " + caption + Environment.NewLine);
            await botClient.SendPhotoAsync(
                chatId: MY_ID_CHAT,
                photo: image,
                caption: caption
                );
        }

        public async void UploadFile(string file,string caption)
        {
            Program.loger.Log(">> [UPLOADING FILE] " + caption + Environment.NewLine);
            using (FileStream fs = System.IO.File.OpenRead(file))
            {
                InputOnlineFile inputOnlineFile = new InputOnlineFile(fs, file);
                await botClient.SendDocumentAsync(MY_ID_CHAT, inputOnlineFile,caption);
            }
        }

        public async void Bot_OnMessage(object sender, MessageEventArgs e){ NewMessage(e.Message.Text); }
    }
}
