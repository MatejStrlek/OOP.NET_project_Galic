using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAL.DAO
{
    public class Team
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "alternate_name")]
        public string AlternateName { get; set; }

        [JsonProperty(PropertyName = "fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty(PropertyName = "wins")]
        public int Wins { get; set; }

        [JsonProperty(PropertyName = "draws")]
        public int Draws { get; set; }

        [JsonProperty(PropertyName = "losses")]
        public int Losses { get; set; }

        [JsonProperty(PropertyName = "games_played")]
        public int GamesPlayed { get; set; }

        [JsonProperty(PropertyName = "points")]
        public int Points { get; set; }

        [JsonProperty(PropertyName = "goals_for")]
        public int GoalsFor { get; set; }

        [JsonProperty(PropertyName = "goals_against")]
        public int GoalsAgainst { get; set; }

        [JsonProperty(PropertyName = "goal_differential")]
        public int GoalDifferential { get; set; }

        public override string ToString()
        => $"{Country} ({FifaCode})";
    }
}
