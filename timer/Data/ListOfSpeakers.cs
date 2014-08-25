using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timer
{
    class ListOfSpeakers
    {
        List<Speaker> speakers;

        public ListOfSpeakers()
        {
            speakers = new List<Speaker>();
        }

        public Speaker this[int i]
        {
            get { return speakers[i]; }
            set { speakers[i] = value; }
        }

        public int Count()
        {
            return speakers.Count;
        }

        public void AddSpeaker(Speaker newSpeaker)
        {
            speakers.Add(newSpeaker);
        }

        public void DeleteSpeaker(int deletedSpeakerId)
        {
            foreach (Speaker speaker in speakers)
            {
                if (speaker.Id == deletedSpeakerId)
                {
                    for (int i = speaker.Id-1; i < speakers.Count; ++i)
                    {
                        --speakers[i].Id;
                    }
                    speakers.Remove(speaker);
                    break;
                }
            }
        }

        public void UpSpeaker(int speakersId)
        {
            SwapSpeakers(speakersId, speakersId - 1);
        }

        public void DownSpeakers(int speakersId)
        {
            SwapSpeakers(speakersId, speakersId+1);
        }

        public void SwapSpeakers(int currentId, int futureId)
        {
            Speaker temp = speakers[futureId];
            speakers[futureId] = speakers[currentId];
            speakers[currentId] = temp;
            int tempId = speakers[futureId].Id;
            speakers[futureId].Id = speakers[currentId].Id;
            speakers[currentId].Id = tempId;
        }
    }
}
