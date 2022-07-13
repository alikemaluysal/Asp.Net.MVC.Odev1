using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Deneme.Models
{
    public class Uye
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz!"), StringLength(50)]
        public string Ad { get; set; }
        [Required, StringLength(50)]
        public string Soyad { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Telefon { get; set; }
        [Required]
        [Display(Name = "Tc Kimlik Numarası")]
        [MinLength(11, ErrorMessage = "Tc Kimlik Numarası En Az 11 Karakter Olmalıdır")]
        [MaxLength(11, ErrorMessage = "Tc Kimlik Numarası En Fazla 11 Karakter Olmalıdır")]
        public string TcKimlikNo { get; set; }
        [Display(Name = "Doğum Tarihi"), DisplayFormat(DataFormatString = "{0:dd.MM.yyy}"), DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre"), DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "{0} {2} karakterden uzun olmalı", MinimumLength = 5)]
        public string Sifre { get; set; }
        [Display(Name = "Şifrenizi Tekrar Giriniz"), DataType(DataType.Password)]
        [Compare("Sifre")]
        public string SifreTekrar { get; set; }
    }
}