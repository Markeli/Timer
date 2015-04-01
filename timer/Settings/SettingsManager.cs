using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Timer.Settings
{
    /// <summary>
    /// Менеджер настроек
    /// </summary>
    internal static class SettingsManager
    {
        /// <summary>
        /// Загружает настройки из файла
        /// </summary>
        /// <returns>Сохраненные настройки</returns>
        public static Settings LoadSettings()
        {
            var savingStream = new FileStream("Settings.bin", FileMode.Open);
            var bf = new BinaryFormatter();
            var settings = (Settings)bf.Deserialize(savingStream);
            savingStream.Close();
            return settings;
        }

        /// <summary>
        /// Сохраняет настройки в файл
        /// </summary>
        /// <param name="settings">Настройки приложения</param>
        public static void SaveSettings(Settings settings)
        {
            var savingStream = new FileStream("Settings.bin", FileMode.Create);
            var bf = new BinaryFormatter();
            bf.Serialize(savingStream, settings);
            savingStream.Close();
        }


        /// <summary>
        /// Возвращает стандартные настройки
        /// </summary>
        public static Settings GetDefaultSettings()
        {
            var settings = new Settings
            {
                SoundPath = @"Sounds\stop.wav",
                LoadRecentlyOpenedFileOnStart = false,
                LastOpenedListPath = String.Empty
            };
            return settings;
        }
    }
}
