using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.ViewModels
{
    public class PersonViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é requerido")]
        [StringLength(70, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Email { get; set; }
        public string PhotoUpload { get; set; }
        public string Photo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string WhatsAppNumber { get; set; }
    }
}
