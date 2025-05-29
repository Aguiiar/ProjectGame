using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Services;
using ProjectGame.Models;

namespace ProjectGame.Services
{
 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AutoCompleteServices : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetGameName(string prefixText, int count)
        {
            return MemoryBank.games.Where(g => g.Name.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).Select(g => g.Name).Take(count).ToList();
        }
    }
}
