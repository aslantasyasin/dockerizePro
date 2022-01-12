using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Catalog.API.Services.Log
{
    public interface ILogAction
    {
        void InsertLog(Exception ex, string value);
        void InsertLog(string value, string message = "");
    }
}
