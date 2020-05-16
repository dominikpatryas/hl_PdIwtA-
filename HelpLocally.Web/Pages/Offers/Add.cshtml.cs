using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Domain.FormInputs;
using HelpLocally.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HelpLocally.Web
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public OfferAddInput input { get; set; }
        private readonly HelpLocallyContext _context;

        public AddModel(HelpLocallyContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (input != null)
            {
                var userId = HttpContext.Request.Cookies["userId"];

                var type = await _context.OfferTypes.FirstOrDefaultAsync(x => x.Id == input.TypeId);

                var company = await _context.Companies.FirstOrDefaultAsync(x => x.OwnerId == Int32.Parse(userId));

                if (company == null)
                    return null;

                _context.Offers.Add(new Offer(input.Name, type, input.Description, company, input.Price));

                await _context.SaveChangesAsync();

                return Page();
            }

            return Redirect("/error");
        }
    }
}