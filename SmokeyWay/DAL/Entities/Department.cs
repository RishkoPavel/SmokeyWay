﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public IList<Employee> Employees { get; set; }

        public  IList<Table> Tables { get; set; }
    }
}
