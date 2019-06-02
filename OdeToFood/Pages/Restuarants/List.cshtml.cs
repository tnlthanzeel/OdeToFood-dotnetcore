using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restuarants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;

        public ListModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = configuration["Message"];
        }
    }
}