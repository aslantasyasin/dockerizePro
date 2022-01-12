using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Basket.API.Services.Log
{
    public class LogAction : ILogAction
    {
        public void InsertLog(Exception ex, string value)
        {
            var logs = new List<string>();

            logs.Add(value);
        }

        public void InsertLog(string value, string message = "")
        {
            var logs = new List<string>();

            logs.Add(value);
        }
    }
}
