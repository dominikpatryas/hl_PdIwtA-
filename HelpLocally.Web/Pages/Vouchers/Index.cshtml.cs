using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLocally.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpLocally.Domain.ViewModels;

namespace HelpLocally.Web
{
    public class IndexModel : PageModel
    {
        private readonly HelpLocallyContext _context;
        public List<VoucherViewModel> Vouchers = new List<VoucherViewModel>();

        public IndexModel(HelpLocallyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
           var userId = HttpContext.Request.Cookies["userId"];
           
            if (userId != null)
            {
                Vouchers = await _context
                    .Vouchers
                    .Where(x => x.OwnerId == Int32.Parse(userId))
                    .Select(x =>
                    new VoucherViewModel
                    {
                        Id = x.Id,
                        CompanyName = x.Company.Name,
                        ExpirationDate = x.ExpirationDate,
                        StartAmount = x.StartAmount,
                        CurrentAmount = x.CurrentAmount,
                        CompanyId = x.CompanyId,
                    }).ToListAsync();
            }

            return Page();
        }
    }
}