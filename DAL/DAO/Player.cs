namespace DAL.DAO
{
    public class Player
    {
        public Player(string name, int dressNumber, string position, bool isCaptain, bool isFavorite)
        {
            Name = name;
            DressNumber = dressNumber;
            Position = position;
            IsCaptain = isCaptain;
            IsFavorite = isFavorite;
        }

        public string Name { get; set; }
        public int DressNumber { get; set; }
        public string Position { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsFavorite { get; set; }

        public string GetPlayerInfo()
        {
            return $"{Name} ({DressNumber}) - {Position} - {(IsCaptain ? "Captain" : "Player")}";
        }

        public string GetNameForCheckBox()
        => $"{Name} ({DressNumber})";
    }
}
