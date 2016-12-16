using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserTools;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                // Create a simple command system for testing out browsers
                string[] command = Console.ReadLine().Split(' ');

                switch(command[0])
                {
                    case "getCookies":
                        switch(command[1])
                        {
                            case "chrome":
                                GetCookiesFromBrowser(BrowserName.Chrome);
                                break;

                            case "opera":
                                GetCookiesFromBrowser(BrowserName.Opera);
                                break;

                            case "yandex":
                                GetCookiesFromBrowser(BrowserName.Yandex);
                                break;
                        }
                        break;

                    case "getLoginData":
                        switch (command[1])
                        {
                            case "chrome":
                                GetLoginDataFromBrowser(BrowserName.Chrome);
                                break;

                            case "opera":
                                GetLoginDataFromBrowser(BrowserName.Opera);
                                break;

                            case "yandex":
                                GetLoginDataFromBrowser(BrowserName.Yandex);
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        private static void GetLoginDataFromBrowser(BrowserName browser)
        {
            try
            {
                List<LoginData> loginData = new List<LoginData>();

                switch(browser)
                {
                    case BrowserName.Chrome:
                        loginData = Chrome.GetLoginData();
                        break;

                    case BrowserName.Opera:
                        loginData = Opera.GetLoginData();
                        break;

                    case BrowserName.Yandex:
                        loginData = Yandex.GetLoginData();
                        break;
                }

                foreach(var entry in loginData)
                {
                    Console.WriteLine($"Url={entry.Url};Username={entry.Username};Password={entry.Password}");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void GetCookiesFromBrowser(BrowserName browser)
        {
            try
            {
                List<Cookie> cookies = new List<Cookie>();

                switch(browser)
                {
                    case BrowserName.Chrome:
                        cookies = Chrome.GetCookies();
                        break;

                    case BrowserName.Opera:
                        cookies = Opera.GetCookies();
                        break;

                    case BrowserName.Yandex:
                        cookies = Yandex.GetCookies();
                        break;
                }

                foreach(var cookie in cookies)
                {
                    Console.WriteLine($"Name={cookie.Name};Value={cookie.Value}");
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
