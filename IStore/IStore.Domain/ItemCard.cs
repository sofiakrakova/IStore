using System;
using System.Collections.Generic;

namespace IStore.Domain
{
    public class ItemCard
    {
        public string ImageBase64 { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DeliveryTime { get; set; }
        public List<Comment> Comments { get; set; }


        public ItemCard(string title, string description, double price, string imageBase64)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be less than 0", nameof(price));
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty", nameof(title));

            ImageBase64 = imageBase64;
            Price = price;
            Description = description;
            Title = title;
            
            Comments = new List<Comment>();
        }
    }
}
