﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommercesite.Entity
{
    public class Category
    {
        public int Id { get; set; }

        // Data annotations
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:25, ErrorMessage = "En fazla 25 karakter girebilirsiniz.")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }

    }
}