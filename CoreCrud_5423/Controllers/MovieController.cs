using CoreCrud_5423.Infrastructure.Interfaces.Concrete;
using CoreCrud_5423.Models.Concrete;
using CoreCrud_5423.Models.DTOs;
using CoreCrud_5423.Models.VMS;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace CoreCrud_5423.Controllers
{
    public class MovieController:Controller
    {
        private readonly IMovieRepo _mRepo;
        private readonly IDirector _dRepo;
        private readonly IActorRepo _aRepo;
       //bir sınıf başkka bir sınıfa ihtiyaç duyuyorsa sınıfın ctorunda enjeksiyonla kullanmam lazım.ben senin soyut halin olan interface IMovieRepo tipinden birşey istiyorum.sen bana movie reponun sınıf halini vermen lazım. interface neyi nasıl yapacağını bilmez.bunun kodunu unutmadan startupta söylemem lazım.ben bunun soyut halini istediğimde bana somut halini ver demem lazım bunu startupda söylüyorum
        public MovieController(IMovieRepo mRepo,IDirector dRepo, IActorRepo aRepo)
        {
            _mRepo=mRepo;
            _dRepo = dRepo;
            _aRepo = aRepo;
        }
        public IActionResult MakeFilm()
        {

            // elinde olan tüm aktörleri yönetmenleri öncce göstermem lazım. çünkü belki veritabanında ekleyeceğim yok.  tek bir sınıfın verisini taşımıyorsa başka sınıftanda veriler gelecekse VM yapmam lazım. dto bir sınıfın traşlanması gibi düşünebilirsin

            //CreateMovieVM nesnesi oluşturmam lazım.

            CreateMovieVM vm =new CreateMovieVM()
            {
                Directors=_dRepo.GetByDefaults
                ( selector: a => new SelectListItem() { Text=a.FullName,Value=a.ID.ToString()},
                      expression : a=> a.IsActive
                    ),
                 Actors = _aRepo.GetByDefaults
                 (
                   selector: a=> new ActorDTO() { ActorId=a.ID,FullNAme=a.FullName,IsSelected=false},
                   expression: a=> a.IsActive

                     
                 )


            };

            return View(vm);
        }



        [HttpPost]

        public IActionResult MakeFilm(CreateMovieVM vM)
        {
            if (ModelState.IsValid )
            {
                Movie movie = new Movie()
                {
                    Name = vM.Name,
                    PublishDate = vM.PublishDate,
                    DirectorId = vM.DirectorID,
                    Director =_dRepo.GetDefault(a=>a.ID==vM.DirectorID)
                };




                foreach (var item in vM.Actors.Where(a=>a.IsSelected)) //secili actor dto dönülecek
                { 
                  MovieActor movieActor=new MovieActor()   //önce ara tablo elemanlarını oluşturdun
                  {
                      ActorId =item.ActorId,
                      Actor=_aRepo.GetDefault(a=>a.ID==item.ActorId), 
                      Movie = movie
                  };

                    movie.MovieActors.Add(movieActor);//movie ekledin
                }



                _mRepo.Create(movie);
                return RedirectToAction("List");

            }

            //negatif senaryoda geri döndürmeden önce tekrardan doldurmam lazım
            

            vM.Directors = _dRepo.GetByDefaults
                ( selector: a=> new SelectListItem() { Text=a.FullName,Value= a.ID.ToString()},
                expression: a=> a.IsActive
                );
            vM.Actors =_aRepo.GetByDefaults
                (selector: a => new ActorDTO() { ActorId = a.ID, FullNAme = a.FullName,IsSelected = false },
                expression: a => a.IsActive
                );

            return View(vM);
        }        

        public IActionResult List()
        {
            return View(_mRepo.GetDefaults(a => a.IsActive));


        }

        public IActionResult Edit(int id)

        //kimi güncelleyeceğim bulmam lazım
        {
            Movie movie = _mRepo.GetDefault(a => a.ID == id);   /// güncellenecek lsite

            UpdateMovieVM vM = new UpdateMovieVM()
            {
                MovieID = movie.ID,
                Name = movie.Name,
                PublishDate = movie.PublishDate,
                DirectorID = movie.DirectorId,
                Directors = _dRepo.GetByDefaults(selector:a=> new SelectListItem() { Text=a.FullName,Value=a.ID.ToString()},
                expression: a=>a.IsActive) //sahip olduğum tüm direktörleride göndereceğim
            };


            //tüm aktif aktörlemi dön diyorum
            foreach ( var item in _aRepo.GetDefaults(a=> a.IsActive)) //sahip olduğun aktörler
            {

                // VM üzerine aktif her oyuncuyu seçilmemiş olarak ekledim 

                vM.Actors.Add(new ActorDTO() {ActorId=item.ID,FullNAme=item.FullName,IsSelected=false });


                foreach (var actor in movie.MovieActors) // film üzerindeki  seçili movieactor nesneleri dönüyoruz
                {
                    if (actor.ActorId==item.ID)//  bu actor zaten seçilmiştir onun isSelected falce değil true yapalım
                    {
                        vM.Actors.Find(a => a.ActorId == actor.ActorId).IsSelected = true;

                    }
                }

            }

            return View(vM);
        }

        [HttpPost]

        public IActionResult Edit(UpdateMovieVM vM)
        {
            if (ModelState.IsValid && vM.Actors.Any(a=> a.IsSelected))
            {
                Movie updatedMovie = _mRepo.GetDefault(a => a.ID == vM.MovieID);

                updatedMovie.Name= vM.Name;
                updatedMovie.PublishDate = vM.PublishDate;
                updatedMovie.DirectorId = vM.DirectorID;
                updatedMovie.Director = _dRepo.GetDefault(a => a.ID == vM.DirectorID);



                updatedMovie.MovieActors.RemoveAll(a => a.MovieId == vM.MovieID);  // filmin üzerindeki tüm oyuncular movie actor nesneleri silinir


                foreach (var item in vM.Actors.Where(a=>a.IsSelected)) // vm üzerindeki sedece seçili actorDTO dönüldü
                {

                    updatedMovie.MovieActors.Add(new MovieActor()   // mevcuttaki güncelenecek movie üzerine eklendi
                    {
                        Movie = updatedMovie,
                        MovieId = updatedMovie.ID,
                        ActorId = item.ActorId,
                        Actor = _aRepo.GetDefault(a => a.ID == item.ActorId)
                    });
                }


                _mRepo.Update(updatedMovie);

                return RedirectToAction("List");

            }
               vM.Directors = _dRepo.GetByDefaults

               (selector: a => new SelectListItem() { Text = a.FullName, Value = a.ID.ToString() },
               expression: a => a.IsActive
               );


            
             //1. seçenek

            foreach (var item in _aRepo.GetDefaults(a=> a.IsActive)) // aktif oyuncuları tek tek gez
            {
                foreach (var actor in vM.Actors)
                {
                    
                    {
                        if (actor.ActorId == item.ID) actor.FullNAme = item.FullName;
                    }

                }
            }



            // 2. seçenek
            //vM.Actors.Clear();


            //foreach (var item in _aRepo.GetDefaults(a=> a.IsActive))  // veritabanıdanki tüm aktif aktörleri alma
            //{
            //    vM.Actors.Add(new ActorDTO() { ActorId = item.ID, FullNAme = item.FullName, IsSelected = false });

            //    foreach (var actor in _mRepo.GetDefault(a=> a.ID == vM.MovieID).MovieActors) // benim filkm üzerinedki movieActor listesini aldık
            //    {

            //        {
            //            if (actor.ActorId == item.ID) vM.Actors.Find(a => a.ActorId == actor.ActorId).IsSelected = true;
            //        }

            //    }

            //}

            return View(vM);

        }



        public IActionResult Delete(int id)  // silme işlemeleri
        {

            Movie movie = _mRepo.GetDefault(a => a.ID == id);
            _mRepo.Delete(movie);
            return RedirectToAction("List");   // list isimli actiona yönelndiriyor

        }


        public IActionResult Details(int id) 
               
        {
            Movie movie = _mRepo.GetDefault(a => a.ID == id);
            return View(movie);
        }

    }
}
