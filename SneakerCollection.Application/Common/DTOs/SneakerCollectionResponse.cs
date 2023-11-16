using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application.Common.DTOs
{
    public  class SneakerCollectionResponse
    {
        public List<SneakerResponse> sneakers { get; set; } = null!;
    }
    public class SneakerResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Size { get; set; }
        public int Year { get; set; }
        public int Rate { get; set; }
        public string UserId { get; set; }
    }
}
