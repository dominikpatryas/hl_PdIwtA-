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
    public class RemoveModel : PageModel
    {
        public HelpLocallyContext _context { get; set; }
        public Offer Offer{ get; set; }
        public RemoveModel(HelpLocallyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            Offer = await _context.Offers.FirstOrDefaultAsync(x => x.Id == id && x.IsSold == false);

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Offer = await _context.Offers.FirstOrDefaultAsync(x => x.Id == id && x.IsSold == false);

            if (Offer != null)
            {
                Offer.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}