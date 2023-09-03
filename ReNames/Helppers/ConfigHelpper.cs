using System;
using System.IO;
using Newtonsoft.Json;
using ReNames.Models;

namespace ReNames.Helppers
{
    public class ConfigHelpper
    {
        private const string FileName = "ReNames.config";

        public static SettingsModel LoadConfig()
        {
            var config = new SettingsModel();
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory)) return config;
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + FileName)) return config;
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + FileName);
            if (!string.IsNullOrEmpty(json))
            {
                config = JsonConvert.DeserializeObject<SettingsModel>(json);
            }
            App.SetLanguague(config!.Language);
            return config;
        }

        public static void SaveConfig(SettingsModel settingsModel)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory);
            }
            string json = JsonConvert.SerializeObject(settingsModel, Formatting.Indented);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + FileName, json);
        }
    }
}
