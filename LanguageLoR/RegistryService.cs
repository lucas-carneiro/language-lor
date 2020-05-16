﻿using System;
using Microsoft.Win32;

namespace LanguageLoR
{
    public static class RegistryService
    {
        private const string LorRegistryKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Riot Game bacon.live";
        private const string LorGamePathRegistryName = "InstallLocation";
        private const string LorProgramDataPathRegistryName = "DisplayIcon";

        public static string LorGamePathRegistryValue { get; private set; }
        public static string LorProgramDataPathRegistryValue { get; private set; }

        public static void Init()
        {
            LorGamePathRegistryValue = GetRegistryValue(LorGamePathRegistryName);
            LorProgramDataPathRegistryValue = GetRegistryValue(LorProgramDataPathRegistryName);
        }

        private static string GetRegistryValue(string registryName)
        {
            try
            {
                using (RegistryKey lorKey = Registry.CurrentUser.OpenSubKey(LorRegistryKey))
                {
                    if (lorKey != null)
                    {
                        object installPathObject = lorKey.GetValue(registryName);
                        return installPathObject as string;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}