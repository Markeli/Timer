namespace Timer.Models
{
    public class Speaker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Длительность выступления (в минутах)
        /// </summary>
        public int PerformanceDuration { get; set; }

        public string PerfermanceStr { get; set; }

        public Speaker(int id, string name, string perfermance)
        {
            Id = id;
            Name = name;
            PerfermanceStr = perfermance;
            int temp;
            if (!int.TryParse(perfermance, out temp))
            {
                PerformanceDuration = 0;
            }
            PerformanceDuration = 60 * temp;
        }
    }
}
