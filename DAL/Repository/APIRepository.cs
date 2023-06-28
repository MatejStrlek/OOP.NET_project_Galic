using DAL.DAO;
using Newtonsoft.Json.Linq;
using System;
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

        public void SaveScreenSize(string screenSize, string path)
            => File.WriteAllText(path, screenSize);

        public string[] LoadScreenSize(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        public List<Team> GetFemaleEnemyTeams(Team team)
        {
            JArray jsonFemaleEnemyTeams = new();
            JArray jsonFemaleTeamsData = new();
            List<string> teamsList = new();
            List<Team> enemyTeams = new List<Team>();

            jsonFemaleEnemyTeams = GetWebRequestAPIEnemyTeamsWPF(API_URL_FEMALE_PLAYERS + $"{GetFifaCodeFemale()}");

            foreach (var game in jsonFemaleEnemyTeams)
            {
                if (game.Value<string>("home_team_country") == team.Country)
                    teamsList.Add(game.Value<string>("away_team_country"));
                else
                    teamsList.Add(game.Value<string>("home_team_country"));
            }

            jsonFemaleTeamsData = GetWebRequestAPIEnemyTeamsWPF(API_URL_FEMALE_TEAMS);

            foreach (var teamName in teamsList)
            {
                foreach (var teamData in jsonFemaleTeamsData)
                {
                    if (teamData.Value<string>("country") == teamName)
                    {
                        enemyTeams.Add(new Team(
                            teamData.Value<int>("id"),
                            teamData.Value<string>("country"),
                            teamData.Value<string>("alternate_name"),
                            teamData.Value<string>("fifa_code"),
                            teamData.Value<int>("group_id"),
                            teamData.Value<char>("group_letter"),
                            teamData.Value<int>("wins"),
                            teamData.Value<int>("draws"),
                            teamData.Value<int>("losses"),
                            teamData.Value<int>("games_played"),
                            teamData.Value<int>("points"),
                            teamData.Value<int>("goals_for"),
                            teamData.Value<int>("goals_against"),
                            teamData.Value<int>("goal_differential")));
                    }
                }
            }

            return enemyTeams;
        }

        public List<Team> GetMaleEnemyTeams(Team team)
        {
            JArray jsonMaleEnemyTeams = new();
            JArray jsonMaleTeamsData = new();
            List<string> teamsList = new();
            List<Team> enemyTeams = new List<Team>();

            jsonMaleEnemyTeams = GetWebRequestAPIEnemyTeamsWPF(API_URL_MALE_PLAYERS + $"{GetFifaCodeMale()}");

            foreach (var game in jsonMaleEnemyTeams)
            {
                if (game.Value<string>("home_team_country") == team.Country)
                    teamsList.Add(game.Value<string>("away_team_country"));
                else
                    teamsList.Add(game.Value<string>("home_team_country"));
            }

            jsonMaleTeamsData = GetWebRequestAPIEnemyTeamsWPF(API_URL_MALE_TEAMS);

            foreach (var teamName in teamsList)
            {
                foreach (var teamData in jsonMaleTeamsData)
                {
                    if (teamData.Value<string>("country") == teamName)
                    {
                        enemyTeams.Add(new Team(
                            teamData.Value<int>("id"),
                            teamData.Value<string>("country"),
                            teamData.Value<string>("alternate_name"),
                            teamData.Value<string>("fifa_code"),
                            teamData.Value<int>("group_id"),
                            teamData.Value<char>("group_letter"),
                            teamData.Value<int>("wins"),
                            teamData.Value<int>("draws"),
                            teamData.Value<int>("losses"),
                            teamData.Value<int>("games_played"),
                            teamData.Value<int>("points"),
                            teamData.Value<int>("goals_for"),
                            teamData.Value<int>("goals_against"),
                            teamData.Value<int>("goal_differential")));
                    }
                }
            }

            return enemyTeams;
        }

        private JArray GetWebRequestAPIEnemyTeamsWPF(string API_URL)
        {
            try
            {
                var client = new HttpClient();
                var content = (client.GetAsync(API_URL).Result).Content.ReadAsStringAsync().Result;
                JArray jsonData = JArray.Parse(content);
                return jsonData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetFemaleResult(Team firstTeam, Team secondTeam)
        {
            JArray jsonFemaleResults = new();

            jsonFemaleResults = GetWebRequestAPIEnemyTeamsWPF(API_URL_FEMALE_PLAYERS + $"{GetFifaCodeFemale()}");

            foreach (var game in jsonFemaleResults)
            {
                if (game.Value<string>("home_team_country") == firstTeam.Country
                                       && game.Value<string>("away_team_country") == secondTeam.Country)
                    return $"{(game["home_team"]).Value<string>("goals")} : {(game["away_team"]).Value<string>("goals")}";

                else if (game.Value<string>("home_team_country") == secondTeam.Country
                                       && game.Value<string>("away_team_country") == firstTeam.Country)
                    return $"{(game["away_team"]).Value<string>("goals")} : {(game["home_team"]).Value<string>("goals")}";

                else
                    continue;
            }

            return "0 : 0";
        }

        public string GetMaleResult(Team firstTeam, Team secondTeam)
        {
            JArray jsonMaleResults = new();

            jsonMaleResults = GetWebRequestAPIEnemyTeamsWPF(API_URL_MALE_PLAYERS + $"{GetFifaCodeMale()}");

            foreach (var game in jsonMaleResults)
            {
                if (game.Value<string>("home_team_country") == firstTeam.Country
                                       && game.Value<string>("away_team_country") == secondTeam.Country)
                    return $"{(game["home_team"]).Value<string>("goals")} : {(game["away_team"]).Value<string>("goals")}";

                else if (game.Value<string>("home_team_country") == secondTeam.Country
                                       && game.Value<string>("away_team_country") == firstTeam.Country)
                    return $"{(game["away_team"]).Value<string>("goals")} : {(game["home_team"]).Value<string>("goals")}";

                else
                    continue;
            }

            return "0 : 0";
        }
    }
}
