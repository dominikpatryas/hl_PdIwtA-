using System;

namespace HelpLocally.Domain
{
    public class Company
    {
        public Company(string name, string nip, string bankAccountNumber)
        {
            Name = name;
            Nip = nip;
            BankAccountNumber = bankAccountNumber;
        }
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Nip { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}