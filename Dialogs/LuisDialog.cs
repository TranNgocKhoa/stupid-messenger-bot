using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Threading;
using System.Collections.Generic;

namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    [LuisModel("61e3e091-1eb4-48ab-ba2c-0d42b7d09052", "33758521eb9944d2aa5e7696c53b81d5")]


    public class LuisDialog : LuisDialog<object>
    {

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            //string message = $"Xin lỗi, em còn ngu lắm, em không hiểu '{result.Query} là gì'. Gõ 'help' nếu quý khách cần người hỗ trợ.";

            // alternatively, you could forward to QnA Dialog if no intent is found

            //await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }


        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string message = $"Xin chào quý khách. Stupid Bot sẵn sàng phục cmn vụ";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
       
        }

        [LuisIntent("AvailableRoom")]
        public async Task AvailableRoom(IDialogContext context, LuisResult result)
        {
            string message = $"Ghi nhận yêu cầu lấy danh sách phòng trống";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
        public enum Selection
        {
            PhongDon, PhongDoi
        }
        [LuisIntent("RoomPrice")]
        public async Task RoomPrice(IDialogContext context, IAwaitable<Selection> result)
        {
            string message = $"Ghi nhận yêu cầu hỏi giá phòng";
            await context.PostAsync(message);
          

            var options = new Selection[] { Selection.PhongDon, Selection.PhongDoi };
            List<string> BotOptions = new List<string>();
            BotOptions.Add("Phòng đơn");
            BotOptions.Add("Phòng đôi");
            PromptDialog.Choice(context,
                resume: AfterChooseRoomType,
                options: options,
                prompt: "Vui lòng chọn",
                descriptions: BotOptions,
                promptStyle: PromptStyle.Auto);

        }

        public async Task AfterChooseRoomType(IDialogContext context, IAwaitable<Selection> argument)
        {
            
            var confirm = await argument;
            await context.PostAsync($"I see you want to order a {confirm}.");
            if (confirm == Selection.PhongDon)
            {
                await context.PostAsync("Ghi nhận yêu cầu hỏi giá phòng đơn");
            }
            else
            {
                await context.PostAsync("Ghi nhận yêu cầu hỏi giá phòng đôi");
            }

        }

    }
}