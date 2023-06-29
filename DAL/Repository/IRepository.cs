using DAL.DAO;

namespace DAL.Repository
{
    public interface IRepository
    {
        List<Team> GetMaleTeams();
        List<Team> GetFemaleTeams();
        List<Player> GetFemalePlayers();
        List<Player> GetMalePlayers();
        void SaveLanguageAndGender(string language, string gender, string path);
        string[] LoadLanguageAndGender(string path);
        void SaveFavoriteTeam(string favoriteTeam, string path);
        string[] LoadFavoriteTeam(string path);
        void SaveFavoritePlayers(List<string> players, string path);
        string[] LoadFavoritePlayers(string path);
        List<Visitors> GetFemaleVisitorsStats();
        List<Visitors> GetMaleVisitorsStats();
        List<Event> GetFemalePlayersEvents();
        List<Event> GetMalePlayersEvents();
        void SaveScreenSize(string screenSize, string path);
        string[] LoadScreenSize(string path);
        List<Team> GetFemaleEnemyTeams(Team team);
        List<Team> GetMaleEnemyTeams(Team team);
        string GetFemaleResult(Team firstTeam, Team secondTeam);
        string GetMaleResult(Team firstTeam, Team secondTeam);
        Player GetOneFemalePlayer();
        Player GetOneMalePlayer();
    }
}
