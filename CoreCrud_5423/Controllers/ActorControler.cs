using CoreCrud_5423.Infrastructure.Concrete;
using CoreCrud_5423.Infrastructure.Interfaces.Concrete;
using CoreCrud_5423.Models.Concrete;
using CoreCrud_5423.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Controllers
{
    public class ActorControler :Controller
    {
        private readonly IActorRepo _aRepo;

        public ActorControler(IActorRepo aRepo) 
        {
            _aRepo = aRepo;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateActorDTO dTO)
        {
            if (ModelState.IsValid)

            {
                Actor actor = new Actor() { FirtsName = dTO.FirtsName, LastName = dTO.LastName, BirthDate = dTO.BirthDate };
                _aRepo.Create(actor);
                return RedirectToAction("ListofActor");

            }
            return View(dTO);


        }

        public IActionResult ListofActor() // sahip oldupum tüm aktif aktörleri görüntülemek
        {
            return View(_aRepo.GetDefaults(a => a.IsActive));

        }

        [HttpGet]

        public IActionResult Update(int id) //not asp-rote da hangi isimi verdiysek o isimi burada kullanamlıyız
        {

            Actor actor = _aRepo.GetDefault(a => a.ID == id);

            UpdateActorDTO dTO = new UpdateActorDTO(){ ID = actor.ID, LastName = actor.LastName, FirtsName = actor.FirtsName, BirthDate = actor.BirthDate.Value };

            return View(dTO);
        }

        [HttpPost]

        public IActionResult Update(UpdateActorDTO entity)
        {
            if (ModelState.IsValid)
            {
                Actor actor = _aRepo.GetDefault(a => a.ID == entity.ID);
                actor.FirtsName = entity.FirtsName;
                actor.LastName = entity.LastName;
                actor.BirthDate = entity.BirthDate;

                _aRepo.Update(actor);
                return RedirectToAction("ListOfActor");
            }
            return View(entity);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Actor actor = _aRepo.GetDefault(a => a.ID == id);
            return View(actor);


        }
        [HttpPost]

        public IActionResult Delete(Actor actor)
        {
            Actor deletedActor = _aRepo.GetDefault(a => a.ID == actor.ID);
            _aRepo.Delete(deletedActor);
            return RedirectToAction("ListOfActor");
        }

        /*
         
        VİEWBAG  - VİEWDATA - TEMPDATA


        --Viewbag, viewdata, tempdata =>  transfer to view yapılardır, yani viewlar yeri taşıma için kullandığımız yapılardır. List, string, datetime vb yapıları taşıyabilri


        --Viewbag => viewdata ile yanı çalışma mantığına sahiptir. Abstract controllerBase tarafında oluşuturulmuşlardır. Dynamic type get boduna sahiptir


        --Viewdata => ViewDictionary (sözlük, yani anahtar değer işlemesi şeklinde çalışır) tipinde oluşmuş GET ve SET metdoduna sahiptir

        --Viewdata, viewbag den daha hızlıdır ve üsü olarak MVS 1.0 adn ileri sürümlerde vardır

        --Viewbag ile MVC 3.0 dan ileri sürümlerde vardır

        --Viewbag ve viewdata oluştuğu actionların viewlarıda kullanılır ancak başka bir actionların viawlarında çalışmaz, taşınamaz, action tetiklenip bu yapılar her yeniden oluştuğunda tekseferlik kullanablr hala gelir ancak ilgili action scope(süslü parantez) dışında yaşayamazlar

        -- Tempdata => diğerleri ile benzer mantıkdadır Ancak diğerleriden en büyük farkı oluşturduktan sonra oluştuğu actionın dışında tek seferliğe mahsus çalılabilir ancak başka acionda kullanıldığında aynı zamanda kendi actionunda da KULLANILAMAZ. Başka actionun viewında kullanılırsa o sayfa yenilendiğinde tempdata kaybolur çünkü yenilenemez. Bu anlamda sonuç olarak oluştuğu actionun viewında her yenilendiğinde kullanılabiliceği ancak kendi viewında kullılamaz olarak oluştuğu actionın viewında her yenilendiğinde kulllanılabileceği ancak kendi viweında kullanılmazsa başka viewda 1 kerekliğine kullanılabileceği söyleyebiliriz

         */

        public IActionResult CreateDataTransferToView()
        {
            TempData["weeklist"] = new List<string> { "pazartes", "salı", "çarşamba" };

            ViewBag.weeklist2 = new List<string> { "perşembe", "cuma" };

            ViewData["weeklist3"] = new List<string> { "cumartesi", "pazar" };

            TempData["bugün"]=DateTime.Now;

            return View();
        }


        public IActionResult Filter()
        {
            return View();

        }

    }
}
