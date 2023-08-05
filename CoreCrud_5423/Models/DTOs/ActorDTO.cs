using System.ComponentModel.DataAnnotations;

namespace CoreCrud_5423.Models.DTOs
{
    public class ActorDTO
    {


        public string FullNAme { get; set; }  // kullanıcıya göstermek için



        public int ActorId { get; set; }  // ıd ile arka planta tutmak için


        public bool IsSelected { get; set; }  //Secilip secilmediğini anlamak için 

    }
}
