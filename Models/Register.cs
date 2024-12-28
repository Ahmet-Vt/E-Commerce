using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommercesite.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Ad kısmı boş olmamalıdır.")]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad kısmı  boş olmamalıdır.")]
        [DisplayName("Soyad")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı boş olmamalıdır.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName{ get; set; }

        [Required]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "E-posta adresinizi düzgün formatta yazınız.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş olmamalıdır.")]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifreyi Onayla")]
        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor")]
        public string RePassword { get; set; }
    }
}