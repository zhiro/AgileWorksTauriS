using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgileWorksTauriS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string Description { get; set; } = "";
        public void OnGet()
        {

        }
        public void onPost()
        {
            Description = "";

            ModelState.Clear();
        }

    }
}
