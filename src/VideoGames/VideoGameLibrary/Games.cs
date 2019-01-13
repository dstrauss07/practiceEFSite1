using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace VideoGameLibrary
{
    public class Games
    {
        [Key]
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
