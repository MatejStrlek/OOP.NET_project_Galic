using DAL.DAO;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Xml.Schema;

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
            JArray jsonFemalePlayersData = new();
            JArray jArrayForUnion = new();

            jsonFemalePlayersData = GetWebRequestAPIPlayersAndVisitors(API_URL_FEMALE_PLAYERS + $"{GetFifaCodeFemale()}");

            List<Player> femalePlayers = new();

            if (jsonFemalePlayersData[0]["home_team"].Value<string>("code") == GetFifaCodeFemale())
            {
                jArrayForUnion = new JArray((jsonFemalePlayersData[0]["home_team_statistics"]["starting_eleven"]).Union((JArray)jsonFemalePlayersData[0]["home_team_statistics"]["substitutes"]));
            }
            else
            {
                jArrayForUnion = new JArray((jsonFemalePlayersData[0]["away_team_statistics"]["starting_eleven"]).Union((JArray)jsonFemalePlayersData[0]["away_team_statistics"]["substitutes"]));
            }

            foreach (var player in jArrayForUnion)
            {
                femalePlayers.Add(new Player(
                    player.Value<string>("name"),
                    player.Value<int>("shirt_number"),
                    player.Value<string>("position"),
                    player.Value<bool>("captain")
                    ));
            }

            return femalePlayers;
        }    

        public List<Player> GetMalePlayers()
        {
            JArray jsonMalePlayersData = new();
            JArray jArrayForUnion = new();

            jsonMalePlayersData = GetWebRequestAPIPlayersAndVisitors(API_URL_MALE_PLAYERS + $"{GetFifaCodeMale()}");

            List<Player> malePlayers = new();

            if (jsonMalePlayersData[0]["home_team"].Value<string>("code") == GetFifaCodeMale())
            {
                jArrayForUnion = new JArray ((jsonMalePlayersData[0]["home_team_statistics"]["starting_eleven"]).Union((JArray)jsonMalePlayersData[0]["home_team_statistics"]["substitutes"]));
            }
            else
            {
                jArrayForUnion = new JArray((jsonMalePlayersData[0]["away_team_statistics"]["starting_eleven"]).Union((JArray)jsonMalePlayersData[0]["away_team_statistics"]["substitutes"]));
            }

            foreach (var player in jArrayForUnion)
            {
                malePlayers.Add(new Player(
                    player.Value<string>("name"),
                    player.Value<int>("shirt_number"),
                    player.Value<string>("position"),
                    player.Value<bool>("captain")
                    ));
            }

            return malePlayers;
        }

        private JArray GetWebRequestAPIPlayersAndVisitors(string API_URL)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(API_URL).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var json = JArray.Parse(content);

                return json;
            }
            catch (Exception)
            {
                throw new Exception("Error while loading API endpoint!");
            }
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

        private string GetFifaCodeMale()
        {
            try
            {
                if (File.Exists(FAVORITE_MALE_TEAM_PATH))
                {
                    string[] lines = File.ReadAllLines(FAVORITE_MALE_TEAM_PATH);

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

        private string GetFifaCodeFemale()
        {
            try
            {
                if (File.Exists(FAVORITE_FEMALE_TEAM_PATH))
                {
                    string[] lines = File.ReadAllLines(FAVORITE_FEMALE_TEAM_PATH);

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

        public void SaveFavoritePlayers(List<string> players, string path)
            => File.WriteAllLines(path, players);

        public string[] LoadFavoritePlayers(string path)
        {
            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        public List<Visitors> GetFemaleVisitorsStats()
        {
            JArray jsonFemaleVisitorsStats = new();
            List<Visitors> femaleVisitors = new();

            jsonFemaleVisitorsStats = GetWebRequestAPIPlayersAndVisitors(API_URL_FEMALE_PLAYERS + $"{GetFifaCodeFemale()}");

            foreach (var game in jsonFemaleVisitorsStats)
            {
                femaleVisitors.Add(new Visitors(
                        game.Value<string>("location"),
                        game.Value<int>("attendance"),
                        game.Value<string>("home_team_country"),
                        game.Value<string>("away_team_country")
                    ));
            }

            return femaleVisitors
                .OrderByDescending(x => x.Attendance)
                .ToList();
        }

        public List<Visitors> GetMaleVisitorsStats()
        {
            JArray jsonMaleVisitorsStats = new();
            List<Visitors> maleVisitors = new();

            jsonMaleVisitorsStats = GetWebRequestAPIPlayersAndVisitors(API_URL_MALE_PLAYERS + $"{GetFifaCodeMale()}");

            foreach (var game in jsonMaleVisitorsStats)
            {
                maleVisitors.Add(new Visitors(
                    game.Value<string>("location"),
                    game.Value<int>("attendance"),
                    game.Value<string>("home_team_country"),
                    game.Value<string>("away_team_country")
                 ));
            }

            return maleVisitors
                .OrderByDescending(x => x.Attendance)
                .ToList();
        }

        public List<Event> GetFemalePlayersEvents()
        {
            JArray jsonFemalePlayersEvents = new();
            List<Event> femalePlayersEvents = new();

            jsonFemalePlayersEvents = GetWebRequestAPIPlayersAndVisitors(API_URL_FEMALE_PLAYERS + $"{GetFifaCodeFemale()}");

            foreach (JObject game in jsonFemalePlayersEvents)
            {
                JArray homeTeamEvents = (JArray)game["home_team_events"];
                JArray awayTeamEvents = (JArray)game["away_team_events"];

                if (game["home_team"].Value<string>("code") == GetFifaCodeFemale())
                {
                    foreach (JObject playerEvent in homeTeamEvents)
                    {
                        if (playerEvent.Value<string>("type_of_event") == "yellow-card"
                            || playerEvent.Value<string>("type_of_event") == "goal")
                        {
                            femalePlayersEvents.Add(new Event(
                                playerEvent.Value<string>("type_of_event"),
                                playerEvent.Value<string>("player")
                            ));
                        }
                    }
                }
                else
                {
                    foreach (JObject playerEvent in awayTeamEvents)
                    {
                        if (playerEvent.Value<string>("type_of_event") == "yellow-card"
                            || playerEvent.Value<string>("type_of_event") == "goal")
                        {
                            femalePlayersEvents.Add(new Event(
                                playerEvent.Value<string>("type_of_event"),
                                playerEvent.Value<string>("player")
                            ));
                        }
                    }
                }
            }

            return femalePlayersEvents;
        }

        public List<Event> GetMalePlayersEvents()
        {
            JArray jsonMalePlayersEvents = new();
            List<Event> malePlayersEvents = new();

            jsonMalePlayersEvents = GetWebRequestAPIPlayersAndVisitors(API_URL_MALE_PLAYERS + $"{GetFifaCodeMale()}");

            foreach (JObject game in jsonMalePlayersEvents)
            {
                JArray homeTeamEvents = (JArray)game["home_team_events"];
                JArray awayTeamEvents = (JArray)game["away_team_events"];

                if (game["home_team"].Value<string>("code") == GetFifaCodeMale()) 
                {
                    foreach (JObject playerEvent in homeTeamEvents)
                    {
                        if (playerEvent.Value<string>("type_of_event") == "yellow-card"
                            || playerEvent.Value<string>("type_of_event") == "goal")
                        {
                            malePlayersEvents.Add(new Event(
                                playerEvent.Value<string>("type_of_event"),
                                playerEvent.Value<string>("player")
                            ));
                        }
                    }
                }
                else
                {
                    foreach (JObject playerEvent in awayTeamEvents)
                    {
                        if (playerEvent.Value<string>("type_of_event") == "yellow-card"
                            || playerEvent.Value<string>("type_of_event") == "goal")
                        {
                            malePlayersEvents.Add(new Event(
                                playerEvent.Value<string>("type_of_event"),
                                playerEvent.Value<string>("player")
                            ));
                        }
                    }
                }
            }

            return malePlayersEvents;
        }

        private List<Event> ValidEvent(JToken playerEvent)
        {
            List<Event> validEvent = new();

            foreach (var pEvent in playerEvent)
            {
                if (pEvent.Value<string>("type_of_event") == "yellow-card"
                    || pEvent.Value<string>("type_of_event") == "goal")
                {
                    validEvent.Add(new Event(
                        pEvent.Value<string>("type_of_event"),
                        pEvent.Value<string>("player")
                        ));
                }
            }

            return validEvent;
        }
    }
}
