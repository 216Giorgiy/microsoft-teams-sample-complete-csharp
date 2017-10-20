﻿using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using Microsoft.Teams.TemplateBotCSharp.Properties;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using Microsoft.Teams.TemplateBotCSharp.Utility;
using System.Globalization;

namespace Microsoft.Teams.TemplateBotCSharp.Dialogs
{
    /// <summary>
    /// This is PopUp SignIn Dialog Class. Main purpose of this class is to Display the PopUp SignIn Card
    /// </summary>

    [Serializable]
    public class PopupSigninCardDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            //Set the Last Dialog in Conversation Data
            context.UserData.SetValue(Strings.LastDialogKey, Strings.LastDialogPopUpSignIn);

            var message = context.MakeMessage();
            var attachment = GetPopUpSignInCard();

            message.Attachments.Add(attachment);

            await context.PostAsync((message));

            context.Done<object>(null);
        }

        private static Attachment GetPopUpSignInCard()
        {
            var heroCard = new HeroCard
            {
                Title = Strings.PopUpSignInCardTitle,
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.Signin, Strings.PopUpSignInCardButtonTitle, value: "https://6ec1bbac.ngrok.io/popUpSignin.html"),
                }
            };

            return heroCard.ToAttachment();
        }
    }
}