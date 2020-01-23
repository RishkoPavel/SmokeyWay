﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsAvalialable { get; set; }

        public int TypeId { get; set; }

        public DishType DishType { get; set; }

        public List<OrderDish> OrdersDishes { get; set; }
    }
}
