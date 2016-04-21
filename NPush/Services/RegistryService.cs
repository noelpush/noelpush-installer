using System;

using Microsoft.Win32;
using NLog;


namespace NoelPush.Services
{
    static class RegistryService
    {
        public static string GetUserId()
        {
            const string registryKey = @"HKEY_CURRENT_USER\SOFTWARE\NoelPush";
            const string registyValue = "ID";

            try
            {
                var key = Registry.GetValue(registryKey, registyValue, 0) as string;
                return key ?? WriteUserId();
            }
            catch (Exception e)
            {
                LogManager.GetCurrentClassLogger().Error(e.Message);
            }

            return "Undefined";
        }

        private static string WriteUserId()
        {
            const string registryFirstKey = @"HKEY_CURRENT_USER\SOFTWARE\";
            const string registyFirstValue = "NoelPush";

            const string registrySecondKey = @"HKEY_CURRENT_USER\SOFTWARE\NoelPush";
            const string registySecondValue = "ID";

            var registyString = GenerateId();

            if (Convert.ToInt32(Registry.GetValue(registryFirstKey, registyFirstValue, 0)) != 0)
                return "Undefined";

            Registry.SetValue(registryFirstKey, registyFirstValue, 0, RegistryValueKind.String);
            Registry.SetValue(registrySecondKey, registySecondValue, registyString, RegistryValueKind.String);

            return registyString;
        }

        public static string GenerateId()
        {
            var random = new Random();
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var password = string.Empty;

            for (var i = 0; i < 32; i++)
            {
                password += alphabet[random.Next(0, alphabet.Length) - 1];
            }

            return password;
        }
    }
}
