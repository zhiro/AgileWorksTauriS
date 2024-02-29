using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgileWorksTauriS.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //string datetime1 = datetime.now.tostring("dd/mm/yyyy hh:mm");
            //datetime dateother = datetime.now;
            //viewdata["timestamp1"] = datetime1;
            //viewdata["timestamp2"] = dateother;
        }
    }

}
