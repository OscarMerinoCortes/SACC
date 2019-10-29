using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SACC.Models.Catalogos
{
    public class PROVEEDORES_DA
    {
        public int ID_PROVEEDOR { get; set; }
        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }
        [Required]
        [StringLength(100)]
        public string DIRECCION { get; set; }
        [Required]
        [StringLength(30)]
        public string COLONIA { get; set; }
        [Required]
        [StringLength(30)]
        public string CIUDAD { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string CP { get; set; }
        [Required]
        [StringLength(13)]
        public string RFC { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string TELEFONO1 { get; set; }
        public string TELEFONO2 { get; set; }
        public string TELEFONO3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string NOTAS { get; set; }
        [Required]
        [StringLength(20)]
        public string ESTADO { get; set; }
        [Required]
        [StringLength(20)]
        public string PAIS { get; set; }
        [Required]
        [StringLength(100)]
        public string TRANS_BANCO { get; set; }
        [Required]
        [StringLength(100)]
        public string TRANS_DIRECCION { get; set; }
        [Required]
        [StringLength(30)]
        public string TRANS_CIUDAD { get; set; }
        public string TRANS_ROUTING { get; set; }
        [Required]
        [StringLength(100)]
        public string TRANS_CUENTA { get; set; }
        public string TRANS_CLAVE_SWIFT { get; set; }
        public string ELIMINADO { get; set; }
        [Required]
        [StringLength(1)]
        public string ALMACEN1 { get; set; }
        [Required]
        [StringLength(1)]
        public string ALMACEN2 { get; set; }
        [Required]
        [StringLength(1)]
        public string ALMACEN3 { get; set; }
    }
}