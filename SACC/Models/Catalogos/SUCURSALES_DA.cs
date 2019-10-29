using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SACC.Models.Catalogos
{
    public class SUCURSALES_DA
    {
        public int ID_SUCURSAL { get; set; }
        [Required]
        public string NOMBRE { get; set; }
        [Required]
        public string CALLE { get; set; }
        [Required]
        public string COLONIA { get; set; }
        [Required]
        public string CIUDAD { get; set; }
        [Required]
        public string ESTADO { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string TELEFONO { get; set; }
        [StringLength(1)]
        public string ELIMINADO { get; set; }
        public string DISTINTIVO { get; set; }
        public Nullable<int> IVA { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public Nullable<int> CP { get; set; }
        [Required]
        public string APLICA_PROMO { get; set; }
    }
}