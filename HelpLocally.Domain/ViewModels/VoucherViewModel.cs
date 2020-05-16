using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain.ViewModels
{
    public class VoucherViewModel
    {
        public int Id { get; set; }
        public double CurrentAmount { get; set; }
        public double StartAmount { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string Owner { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
