namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;


    public partial class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}