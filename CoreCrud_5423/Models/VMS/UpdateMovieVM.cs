using CoreCrud_5423.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud_5423.Models.VMS
{
    public class UpdateMovieVM
    {



        public UpdateMovieVM()
        {
            Actors = new List<ActorDTO>();  
        }

        //Movie
        public int MovieID { get; set; }


        [Required(ErrorMessage = "İsimsiz film olamaz")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Çıkış tarihi boş olamaz")]
        public DateTime PublishDate { get; set; }





        //Director
        [Required(ErrorMessage = "Yönetmen seçiniz.")]
        public int DirectorID { get; set; }


        public List<SelectListItem> Directors { get; set; }


        //Actor

        public List<ActorDTO> Actors { get; set; }




    }
}
