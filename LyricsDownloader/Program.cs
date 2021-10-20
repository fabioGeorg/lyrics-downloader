using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LyricsDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Aucun argument fourni: LyricsDownloader.exe {artiste} {titre}");
            }

            string m_Artiste = args[0];
            string m_Titre = args[1];
            string m_JsonStr = "";
            JObject m_JsonObject = new JObject();

            try
            {
                using (WebClient client = new WebClient())
                {                    
                    m_JsonStr = client.DownloadString($"https://api.lyrics.ovh/v1/{m_Artiste}/{m_Titre}");
                }

                m_JsonObject = JObject.Parse(m_JsonStr);

                string index = m_JsonStr.Contains("lyrics") ? "lyrics" : "error";
                if (index == "lyrics")
                {
                    using (StreamWriter sw = new StreamWriter($"{m_Artiste}-{m_Titre}.txt"))
                    {
                        sw.Write((string)m_JsonObject["lyrics"]);
                    }
                    Console.WriteLine("Done!");
                }
                else Console.WriteLine((string)m_JsonObject["error"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }
}
