using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameLibrary
{
    public class Games
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Publisher { get; set; }
        public int PublisherId { get; set; }
        public string Genre { get; set; }

        //Navigation Properties
        public int CompanyId { get; set; }
        public Company Company { get; set; } 
    }
}
