﻿using Microsoft.Bot.Connector;
using System;
using System.Configuration;

namespace Microsoft.Teams.TemplateBotCSharp.Utility
{
    public static partial class Middleware
    {
        public static string TenantFilterSettingAny = "#ANY#";

        /// <summary>
        /// Here are below scenarios - 
        ///     #Scanerio 1 - Reject the Bot If Tenant is configured in web.config and doesn't match with Incoming request tenant
        ///     #Scenario 2 - Allow Bot for every Tenant if Tenant is not configured in web.config file and deafult value is #ANY#             
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="currentTenant"></param>
        /// <returns></returns>
        public static bool RejectBotBasedOnTenant(IMessageActivity activity, string currentTenant)
        {
            if (!String.Equals(ConfigurationManager.AppSettings["OFFICE_365_TENANT_FILTER"], TenantFilterSettingAny))
            {
                //#Scanerio 1
                return !string.Equals(ConfigurationManager.AppSettings["OFFICE_365_TENANT_FILTER"].ToString(), currentTenant);
            }
            else
            {
                //Scenario 2
                return false;
            }
        }

        public static IMessageActivity ConvertActivityTextToLower(IMessageActivity activity)
        {
            //Convert input command in lower case for 1To1 and Channel users
            if (activity.Text != null)
            {
                activity.Text = activity.Text.ToLower();
            }

            return activity;
        }
    }
}