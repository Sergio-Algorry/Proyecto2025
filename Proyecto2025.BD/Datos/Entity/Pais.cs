using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos.Entity
{
    [Index(nameof(Alpha3Code), Name = "Pais_Alpha3Code_UQ", IsUnique = true)]
    public class Pais
    {
        public int Id { get; set; } //heredar

        [Required(ErrorMessage = "El codigo de país internacional es obligatorio")]
        [MaxLength(3,ErrorMessage ="Maxima cant. caracteres 3")]
        public required string Alpha3Code { get; set; }

        public string CodIndec { get; set; }

        public string CodLlamada { get; set; }

        public string NombrePais { get; set; }
    }
}
