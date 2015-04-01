using System.Collections.Generic;

namespace Timer.Models
{
    internal class Speakers
    {
        readonly List<Speaker> _speakers;

        public Speakers()
        {
            _speakers = new List<Speaker>();
        }

        public Speaker this[int i]
        {
            get { return _speakers[i]; }
            set { _speakers[i] = value; }
        }

        public int Count()
        {
            return _speakers.Count;
        }

        public void AddSpeaker(Speaker newSpeaker)
        {
            _speakers.Add(newSpeaker);
        }

        public void DeleteSpeaker(int speakerId)
        {
            foreach (var speaker in _speakers)
            {
                if (speaker.Id != speakerId) {continue;}
                for (var i = speaker.Id-1; i < _speakers.Count; ++i)
                {
                    --_speakers[i].Id;
                }
                _speakers.Remove(speaker);
                break;
            }
        }

        public void UpSpeaker(int speakerId)
        {
            SwapSpeakers(speakerId, speakerId - 1);
        }

        public void DownSpeakers(int speakerId)
        {
            SwapSpeakers(speakerId, speakerId+1);
        }

        public void SwapSpeakers(int firstSpeakerId, int secondSpeackerId)
        {
            var temp = _speakers[secondSpeackerId];
            _speakers[secondSpeackerId] = _speakers[firstSpeakerId];
            _speakers[firstSpeakerId] = temp;
            var tempId = _speakers[secondSpeackerId].Id;
            _speakers[secondSpeackerId].Id = _speakers[firstSpeakerId].Id;
            _speakers[firstSpeakerId].Id = tempId;
        }
    }
}
