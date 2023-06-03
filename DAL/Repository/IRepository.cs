using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
