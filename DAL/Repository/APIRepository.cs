using DAL.DAO;
using System.Net;

namespace DAL.Repository
{
    internal class APIRepository : IRepository
    {
        private const string API_URL_MALE_TEAMS = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private const string API_URL_FEMALE_TEAMS = "https://worldcup-vua.nullbit.hr/women/teams/results";
        private const string API_URL_MALE_PLAYERS = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
        private const string API_URL_FEMALE_PLAYERS = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";

        private static string LANGUAGE_AND_GENDER_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "language_and_gender.txt");
        private static string FAVORITE_MALE_TEAM_PATH = 
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_male_team.txt");
        private static string FAVORITE_FEMALE_TEAM_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_female_team.txt");

        public List<Team> GetFemaleTeams()
        {
            List<Team> femaleTeams = new();

            femaleTeams = GetWebRequestAPITeams(API_URL_FEMALE_TEAMS);

            return femaleTeams;
        }

        public List<Team> GetMaleTeams()
        {
            List<Team> maleTeams = new();

            maleTeams = GetWebRequestAPITeams(API_URL_MALE_TEAMS);

            return maleTeams;
        }

        public List<Player> GetFemalePlayers()
        {
            List <Player> femalePlayers = new();

            femalePlayers = GetWebRequestAPIPlayers(API_URL_FEMALE_PLAYERS + $"{GetFifaCode()}");

            return femalePlayers;
        }    

        public List<Player> GetMalePlayers()
        {
            List<Player> malePlayers = new();

            malePlayers = GetWebRequestAPIPlayers(API_URL_MALE_PLAYERS + $"{GetFifaCode()}");


            return malePlayers;
        }

        private List<Player> GetWebRequestAPIPlayers(string API_URL)
        {
            List<Player> malePlayers = new();

            var webRequest = WebRequest.Create(API_URL) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new System.IO.StreamReader(s))
                {
                    string playersJson = sr.ReadToEnd();
                    malePlayers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Player>>(playersJson);
                    malePlayers.ForEach(Console.WriteLine);
                }
            }

            return malePlayers;
        }

        private static List<Team> GetWebRequestAPITeams(string API_URL)
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
            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        public void SaveFavoriteTeam(string favoriteTeam, string path) 
            => File.WriteAllText(path, favoriteTeam);

        public string[] LoadFavoriteTeam(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        private string GetFifaCode() 
        {
            try
            {
                if (File.Exists(FAVORITE_MALE_TEAM_PATH))
                {
                    string[] lines = File.ReadAllLines(FAVORITE_MALE_TEAM_PATH); //Tunisia (TUN)

                    string[] split = lines[0].Split('(');
                    string[] fifaCode = split[1].Split(')');

                    return fifaCode[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
    }
}
