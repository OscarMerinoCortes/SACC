using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SACC.Models.Catalogos
{
    public class PRESENTACION_DA
    {
        public int IdPresentacion { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [DisplayName("FECHA REG.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression("(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d", ErrorMessage = "FORMATO INVALIDO (dd-MM-yyyy)")]
        public System.DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Estatus")]
        public int IdEstatus { get; set; }
    }
}