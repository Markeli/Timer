using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Timer.Models;

namespace Timer.SpeakerList
{
    /// <summary>
    /// 
    /// </summary>
    internal static class SpeakersManager
    {
        public static Speakers LoadSpeakers(object path)
        {
            var word = new Microsoft.Office.Interop.Word.Application();
            object miss = Missing.Value;
            object readOnly = false;
            var docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            docs.ActiveWindow.Selection.WholeStory();
            docs.ActiveWindow.Selection.Copy();
            var data = Clipboard.GetDataObject();

            var speakers = new Speakers();
            if (data != null)
            {
                var textLines = data.GetData(DataFormats.Text).ToString().Split('\r');
                var speakerCount = 0;
                for (var i = 0; i < textLines.Length; ++i)
                {
                    if (textLines[i] != "\n")
                    {
                        var speaker = GetSpeaker(textLines[i]);
                        if (null == speaker) { continue; }
                        speaker.Id = speakerCount++;
                        speakers.AddSpeaker(speaker);
                    }
                }
            }
            docs.Close(ref miss, ref miss, ref miss);
            word.Quit(ref miss, ref miss, ref miss);
            return speakers;
        }

        private static Speaker GetSpeaker(string speakerTextLine)
        {
            const string pattern = @" \d+";
            var regular = new Regex(pattern);
            try
            {
                speakerTextLine = speakerTextLine.Trim();
                if (speakerTextLine.Length != 0)
                {
                    var perfermance = regular.Match(speakerTextLine);
                    if (perfermance.Success)
                    {
                        CreateSpeaker(perfermance.Value, regular.Split(speakerTextLine));
                    }
                    else
                    {
                        const string trimmedPattern = @"\d+";
                        regular = new Regex(trimmedPattern);
                        perfermance = regular.Match(speakerTextLine);
                        if (perfermance.Success)
                        {
                            return CreateSpeaker(perfermance.Value, regular.Split(speakerTextLine));
                        }
                        return new Speaker(0, speakerTextLine.Trim(), "");
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        private static Speaker CreateSpeaker(string performanceDuration, string[] speakersInfo)
        {
            if (speakersInfo[0] == performanceDuration)
            {
                return new Speaker(0, "", performanceDuration.Trim());
            }
            return new Speaker(0, speakersInfo[0].Trim(), performanceDuration.Trim());
        }

        public static void SaveSpeakers(object path, Speakers speakers)
        {
            object missing = Missing.Value;
            var word = new Microsoft.Office.Interop.Word.Application();
            var doc = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            var paragraph = doc.Content.Paragraphs.Add(ref missing);
            for (var i = 0; i < speakers.Count(); ++i)
            {
                paragraph.Range.Text += speakers[i].Name + " " + speakers[i].PerfermanceStr;
            }
            paragraph.Range.InsertParagraphAfter();
            doc.SaveAs2(ref path, ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing,
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing, 
                                  ref missing);
            doc.Close();
            word.Quit(ref missing, ref missing, ref missing); 
        }
    }
}
