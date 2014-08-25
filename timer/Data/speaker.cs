using System;

namespace timer
{
    public class Speaker
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int perfermanceNum;
        public int PerfermanceNum
        {
            get { return perfermanceNum; }
            set { perfermanceNum = value; }
        }
        string perfermanceStr;
        public string PerfermanceStr
        {
            get { return perfermanceStr;}
            set { perfermanceStr = value; }
        }

        public Speaker(int newId, string newName, string newPerfermance)
        {
            Id = newId;
            Name = newName;
            PerfermanceStr = newPerfermance;
            if (!int.TryParse(newPerfermance, out perfermanceNum))
            {
                PerfermanceNum = 0;
            }
            PerfermanceNum *= 60;
        }
    }
}
