using System.Collections.Generic;

namespace Library.Models.ViewModels
{
    public class BookViewModel
    {
        public Libro Book { get; set; }

        public List<Autore> Autores { get; set; }
    }
}
