﻿namespace ProductWebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
