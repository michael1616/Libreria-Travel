using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Libro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sipnosis { get; set; }
        public string NPaginas { get; set; }
        public int? EditorialId { get; set; }

        public virtual Editoriale Editorial { get; set; }
    }
}
