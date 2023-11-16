using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Domain.UserAggregate.Entities
{
    public sealed class Sneaker : Entity<SneakerId>
    {
        public string Name { get; }
        public string Brand { get; }
        public double Price { get; }
        public int Size { get; }
        public int Year { get; }
        public int rate { get; }

        private Sneaker(SneakerId sneakerId, 
            string name,
            string brand,
            double price, 
            int size,
            int year,
            int rate)
            : base(sneakerId)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Size = size;
            Year = year;
            this.rate = rate;
        }

        public static Sneaker Create(
            string name,
            string brand,
            double price, 
            int size, 
            int year,
            int rate)
        {
            return new Sneaker(
                SneakerId.CreateUnique(),
                name, 
                brand, 
                price, 
                size, 
                year, 
                rate);

        }
    }
}
