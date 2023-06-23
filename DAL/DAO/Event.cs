using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class Event
    {
        public string TypeOfEvent { get; set; }
        public string Player { get; set; }

        public Event(string typeOfEvent, string player)
        {
            TypeOfEvent = typeOfEvent;
            Player = player;
        }
    }
}
