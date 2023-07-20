using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MailChimp;
using MailChimp.Helper;
using MailChimp.Lists;
using MYB101.Logic.Models;

namespace MYB101.Logic
{
    public static class MailChimp
    {
        public static ActionResponse AddToList(MailChimpModel model, string apiKey, string listId)
        {
            
            try
            {
                if (!string.IsNullOrEmpty(listId))
                {
                    var mc = new MailChimpManager(apiKey);

                    var mcEmail = new EmailParameter()
                    {
                        Email = model.Email
                    };

                    var mergeVars = new MergeVar();
                    foreach (var item in model.MergeVars)
                    {
                        mergeVars.Add(item.Key, item.Value);
                    }

                    mc.Subscribe(listId, mcEmail, mergeVars, doubleOptIn: false);
                }
                else
                {
                    throw new NullReferenceException("List Id not found");
                }

                return new ActionResponse()
                {
                    Success = true
                };
            }
            catch(Exception ex)
            {
                return new ActionResponse()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}