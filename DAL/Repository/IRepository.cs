using DAL.DAO;

namespace DAL.Repository
{
    public interface IRepository
    {
        List<Team> GetMaleTeams();
        List<Team> GetFemaleTeams();
        void SaveLanguageAndGender(string language, string gender, string path);
        string[] LoadLanguageAndGender(string path);
        void SaveFavoriteTeam(string favoriteTeam, string path);
    }
}
