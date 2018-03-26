using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Threading;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    [LuisModel("61e3e091-1eb4-48ab-ba2c-0d42b7d09052", "33758521eb9944d2aa5e7696c53b81d5")]
    public class LuisDialog : LuisDialog<object>
    {
        [LuisIntent("greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string message = $"Xin chào quý khách. Stupid Bot sẵn sàng phục cmn vụ";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
       
        }
        //public Task StartAsync(IDialogContext context)
        //{
        //    context.Wait(MessageReceivedAsync);

        //    return Task.CompletedTask;
        //}

        //private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        //{
        //    var activity = await result as IMessageActivity;

        //    // TODO: Put logic for handling user message here

        //    context.Wait(MessageReceivedAsync);
        //}
    }
}