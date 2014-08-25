using System;

namespace timer
{
    [Serializable]
    public class Settings
    {
        string soundsLocation;
        public string SoundsLoaction
        {
            get { return soundsLocation; }
            set
            {
                if (value != null)
                {
                    soundsLocation = value;
                }
            }
        }
        bool loadLastOpenedFileOnStart;
        public bool LoadRecentlyOpenedFileOnStart
        {
            get { return loadLastOpenedFileOnStart; }
            set { loadLastOpenedFileOnStart = value; }
        }
        string lastOpenedListLocation;
        public string LastOpenedListLocation
        {
            get { return lastOpenedListLocation; }
            set { lastOpenedListLocation = value; }
        }

        public Settings()
        {
            SoundsLoaction = null;
            LoadRecentlyOpenedFileOnStart = false;
            LastOpenedListLocation = null;
        }

        public void SetDefaultSettings()
        {
            SoundsLoaction = @"Sounds\stop.wav";
            LoadRecentlyOpenedFileOnStart = false;
            LastOpenedListLocation = "";
        }

        public bool CanLoadLastOpenedList()
        {
            return LoadRecentlyOpenedFileOnStart & LastOpenedListLocation != "";
        }
    }
}
