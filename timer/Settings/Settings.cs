using System;

namespace Timer.Settings
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    [Serializable]
    public class Settings
    {
        private string _soundLocation;
        private bool _loadLastOpenedFileOnStart;
        private string _lastOpenedListPath;

        /// <summary>
        /// Полный путь к звуковому файлу
        /// </summary>
        public string SoundPath
        {
            get { return _soundLocation; }
            set
            {
                if (value != null)
                {
                    _soundLocation = value;
                }
            }
        }

        /// <summary>
        /// Флаг загрузки последнего использованного списка при запуске приложения
        /// </summary>
        public bool LoadRecentlyOpenedFileOnStart
        {
            get { return _loadLastOpenedFileOnStart; }
            set { _loadLastOpenedFileOnStart = value; }
        }

        /// <summary>
        /// Путь к последнему использованному списку
        /// </summary>
        public string LastOpenedListPath
        {
            get { return _lastOpenedListPath; }
            set { _lastOpenedListPath = value; }
        }

        /// <summary>
        /// Настройки приложения
        /// </summary>
        public Settings()
        {
            SoundPath = String.Empty;
            LoadRecentlyOpenedFileOnStart = false;
            LastOpenedListPath = String.Empty;
        }
        
        /// <summary>
        /// Проверяет возможность загрузки последнего открытое списка
        /// </summary>
        /// <returns></returns>
        public bool CanLoadLastOpenedList()
        {
            return LoadRecentlyOpenedFileOnStart & LastOpenedListPath != "";
        }
    }
}
