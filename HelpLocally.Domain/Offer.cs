using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain
{
    public class Offer
    {
        public Offer(string name, OfferType type, string description, Company company, double price)
        {
            Name = name;
            Type = type;
            Description = description;
            Company = company;
            Price = price;
        }
        Offer() { }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public int? TypeId { get; set; }
        public double Price { get; set; }
        public bool IsSold { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public OfferType Type { get; set; }
        public Company Company { get; set; }
    }
}
