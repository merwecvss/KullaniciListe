using KullaniciListe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KullaniciListe.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly DataContext _context;
        public KullaniciController(DataContext context)
        {
            _context = context;
        }
        // KullanıcıController sınıfı, kullanıcı işlemlerini yönetir.

        public async Task<IActionResult> Index()
        {
            var kullanicilar = await _context.kullanicilar.ToListAsync();
            return View(kullanicilar);
        }
        // Kullanıcı listesini görüntülemek için Index metodu.


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kullanici model)
        {
            _context.kullanicilar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //kullanıcı eklemek için Create metodu. bu kısmı ekstra olarak ekledim.


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Kullanici = await _context.kullanicilar.FindAsync(id);
            if (Kullanici == null)
            {
                return NotFound();
            }
            return View(Kullanici);
        }
        //kullanıcı detaylarını görüntülemek için Details metodu.

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Kullanici = await _context.kullanicilar.FindAsync(id);
            if (Kullanici == null)
            {
                return View(Kullanici);
            }
            return View(Kullanici);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Kullanici model)
        {
            if (id != model.KullaniciId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.kullanicilar.Any(k => k.KullaniciId == model.KullaniciId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // kullanıcı bilgilerini düzenlemek için Edit metodu. Bu kısmı da ekstra olarak ekledim.

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Kullanici = await _context.kullanicilar.FindAsync(id);
            if (Kullanici == null)
            {
                return NotFound();
            }
            return View(Kullanici);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Kullanici = await _context.kullanicilar.FindAsync(id);
            if (Kullanici == null)
            {
                return NotFound();
            }
            _context.kullanicilar.Remove(Kullanici);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // kullanıcı silmek için Delete metodu.
    }
}