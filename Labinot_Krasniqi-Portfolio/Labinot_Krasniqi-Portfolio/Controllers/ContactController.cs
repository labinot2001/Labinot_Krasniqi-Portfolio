using Labinot_Krasniqi_Portfolio.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Labinot_Krasniqi_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactServices _service;

        public ContactController(IContactServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contactDetails = await _service.GetByIdAsync(id);

            if (contactDetails == null) return View("NotFound");
            return View(contactDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactDetails = await _service.GetByIdAsync(id);

            if (contactDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
