using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos.Entity
{
    public class Provincia : EntityBase
    {
        [Required(ErrorMessage = "El Código IGM es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public required string IGM_Id { get; set; }
        public string NombreProvincia { get; set; } = string.Empty;
    }
}
