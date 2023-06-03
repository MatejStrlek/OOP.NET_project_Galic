using DAL.DAO;
using System.Net;

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
            if(language == null || gender == null)
                throw new ArgumentNullException();

            List<string> linesToWrite = new()
            {
                $"{language};{gender}"
            };

            File.WriteAllLines(path, linesToWrite);
        }

        public string[] LoadLanguageAndGender(string path)
        {
            if (!File.Exists(path))
            File.Create(path);

            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        public void SaveFavoriteTeam(string favoriteTeam, string path)
        {
            string[] lines = favoriteTeam.Split(" (");
            string teamName = lines[0];
            string teamCode = lines[1].Replace(")", "");

            List<string> linesToWrite = new()
            {
                $"{teamName};{teamCode}"
            };

            File.WriteAllLines(path, linesToWrite);
        }
    }
}
