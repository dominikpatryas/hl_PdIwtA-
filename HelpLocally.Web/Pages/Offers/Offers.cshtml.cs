using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HelpLocally.Web
{
    public class OffersModel : PageModel
    {
        public HelpLocallyContext _context { get; set; }
        public List<Offer> Offer { get; set; }
        public OffersModel(HelpLocallyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet()
        {
            Offer = await _context
                            .Offers
                            .Where(x =>
                                x.IsSold == false &&
                                x.IsDeleted == false).ToListAsync();

            return Page();
        }
    }
}