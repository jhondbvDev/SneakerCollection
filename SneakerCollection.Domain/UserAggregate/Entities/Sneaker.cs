using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Domain.UserAggregate.Entities
{
    public sealed class Sneaker : Entity<SneakerId>
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public double Price { get; private set; }
        public int Size { get; private set; }
        public int Year { get; private set; }
        public int Rate { get; private set; }

        public UserId UserId { get; private set; }

        private Sneaker(SneakerId sneakerId, 
            string name,
            string brand,
            double price, 
            int size,
            int year,
            int rate,
            UserId userId)
            : base(sneakerId)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Size = size;
            Year = year;
            this.Rate = rate;
            this.UserId = userId;   
        }

        public void Update(string name,
            string brand,
            double price,
            int size,
            int year,
            int rate)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Size = size;
            Year = year;
            Rate = rate;
        }

        protected Sneaker()
        {

        }


        public static Sneaker Create(
            string name,
            string brand,
            double price, 
            int size, 
            int year,
            int rate,
            UserId userId)
        {
            return new Sneaker(
                SneakerId.CreateUnique(),
                name, 
                brand, 
                price, 
                size, 
                year, 
                rate,
                userId);

        }
    }
}
