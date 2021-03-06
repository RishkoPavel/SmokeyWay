﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime BirthDate { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        public string CommunicationLanguage { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public UserRole Role { get; set; }

        public IList<OnlineTableReservation> OnlineTableReservations { get; set; }
    }
}
