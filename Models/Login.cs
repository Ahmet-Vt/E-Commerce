using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommercesite.Models
{
    public class Login
    {

        [Required (ErrorMessage ="Kullanıcı Adı boş olmamalıdır.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş olmamalıdır.")]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla") ]
        public bool RememberMe { get; set; }


    }
}