namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;


    public partial class Book
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

    }
}