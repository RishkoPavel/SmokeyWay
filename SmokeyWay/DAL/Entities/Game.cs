﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LicenseBeginDate { get; set; }

        public DateTime LicenseEndDate { get; set; }
        
        public IList<GameConsoleToGame> GameConsolesGames { get; set; }
    }
}
