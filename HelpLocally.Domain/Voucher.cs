using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain
{
    public class Voucher
    {
        public Voucher(User owner, double startAmount, Company company, DateTime expirationDate)
        {
            CurrentAmount = startAmount;
            Owner = owner;
            Company = company;
            StartAmount = startAmount;
            ExpirationDate = expirationDate;
        }
        Voucher() { }
        public int Id { get; private set; }
        public double StartAmount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int OwnerId { get; set; }
        public double CurrentAmount { get; set; }
        public User Owner { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
