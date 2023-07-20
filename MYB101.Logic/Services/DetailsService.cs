using MYB101.Data;
using MYB101.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Logic.Services
{
    public class DetailsService
    {
        public ActionResponse EditDetails(string Avatar, int memberId, string name)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.DetailQueries.UpdateDetails(Avatar, memberId, name);
                }
                return new ActionResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
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