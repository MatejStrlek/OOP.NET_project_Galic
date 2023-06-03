using DAL.DAO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class APIRepository : IRepository
    {
        private const string API_URL_MALE = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private const string API_URL_FEMALE = "https://worldcup-vua.nullbit.hr/women/teams/results";

        public List<Team> GetFemaleTeams()
        {
            List<Team> femaleTeams = new();

            femaleTeams = GetWebRequestAPI(API_URL_FEMALE);

            return femaleTeams;
        }

        public List<Team> GetMaleTeams()
        {
            List<Team> maleTeams = new();

            maleTeams = GetWebRequestAPI(API_URL_MALE);

            return maleTeams;
        }

        private static List<Team> GetWebRequestAPI(string API_URL)
        {
            List<Team> teams;
            var webRequest = WebRequest.Create(API_URL) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new System.IO.StreamReader(s))
                {
                    string teamsJson = sr.ReadToEnd();
                    teams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Team>>(teamsJson);
                    teams.ForEach(Console.WriteLine);
                }
            }

            return teams;
        }

        public void SaveLanguageAndGender(string language, string gender, string path)
        {
            List<string> lines = new()
            {
                $"{language};{gender}"
            };

            File.WriteAllLines(path, lines);
        }

        public string[] LoadLanguageAndGender(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            string[] lines = File.ReadAllLines(path);

            return lines;
        }
    }
}
