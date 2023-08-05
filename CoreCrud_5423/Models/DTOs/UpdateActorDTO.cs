using CoreCrud_5423.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.DTOs
{
    public class UpdateActorDTO
    {
        // Oluştrduğumuz DTO larla iş yaparken bazı kurallar koyup çalıştığımız dto nun bizim için gerçerli (validate) olmasını isteriz. Bunun için daha bilgileri frontta yani ön yüzü kontrol eden , arkaya hemen göndermeyen DataAnnotations kütiphanesini kullanarak bu kütüphanenin attributelerinden faydalanabiliriz.

        public int ID { get; set; }   //kullanıcı göremez değiştiremez sadece posta düşüldüğünde kişinin güncelleneceğinin bilmesi gerekiyor bu yüzden posta taşıdık


        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]                 // BOŞ BIRAKILAMZ
        [MinLength(3, ErrorMessage = "İsim en az 3 karakter olmalı")]         // MINIMUM KARAKTER SAYISI 
        [MaxLength(20, ErrorMessage = "İsim en fazla 20 karakter olmalı.")]   // MAXIMUM KARAKTER SAYISI
        public string FirtsName { get; set; }


        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]                 // BOŞ BIRAKILAMZ
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen tarih seçiniz.")]
        [CustomRangeAttribute(ErrorMessage = "Girilen tarih 18 yıl ve 110 yıl öncesi içinde olmalıdır.")]
        public DateTime BirthDate { get; set; }


    }
}
