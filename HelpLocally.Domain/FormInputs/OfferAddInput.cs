using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain.FormInputs
{
    public class OfferAddInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int TypeId { get; set; }
    }
}
