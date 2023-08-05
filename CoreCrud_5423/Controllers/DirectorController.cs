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
    public class DirectorController : Controller
    {
        private readonly IDirector _dRepo;

        public DirectorController(IDirector dRepo)
        {
            _dRepo = dRepo;
        }

        //önce boş bir form verilecek doldurup post edecğiz
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDirectorDTO dto)
        {
            if (ModelState.IsValid)
            {
                Director director = new Director() { FirtsName = dto.FirtsName, LastName = dto.LastName, BirthDate = dto.BirthDate };
                _dRepo.Create(director);

                return RedirectToAction("ListOfDirector");

            }
            return View(dto);
        }



        public IActionResult ListOfDirector() // sahip oldupum tüm aktif yönetmenleri görüntülemek
        {
            return View(_dRepo.GetDefaults(a => a.IsActive));

        }


        [HttpGet]

        public IActionResult Update(int id) //not asp-rote da hangi isimi verdiysek o isimi burada kullanamlıyız
        {

            Director director = _dRepo.GetDefault(a => a.ID == id);

            UpdateDirectorDTO dTO = new UpdateDirectorDTO() { ID = director.ID, LastName = director.LastName, FirtsName = director.FirtsName, BirthDate = director.BirthDate.Value };

            return View(dTO);
        }

        [HttpPost]

        public IActionResult Update(UpdateDirectorDTO entity)
        {
            if (ModelState.IsValid)
            {
                Director director = _dRepo.GetDefault(a => a.ID == entity.ID);
                director.FirtsName = entity.FirtsName;
                director.LastName = entity.LastName;
                director.BirthDate = entity.BirthDate;

                _dRepo.Update(director);
                return RedirectToAction("ListOfDirector");
            }
            return View(entity);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Director director = _dRepo.GetDefault(a => a.ID == id);
            return View(director);
                

        }
        [HttpPost] 

        public IActionResult Delete(Director director)
        {
            Director deletedDirector = _dRepo.GetDefault(a => a.ID == director.ID);
            _dRepo.Delete(deletedDirector);
            return RedirectToAction("ListOfDirector");
        }

    }
}
