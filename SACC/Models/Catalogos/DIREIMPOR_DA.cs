using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SACC.Models.Catalogos
{
    public class DIREIMPOR_DA
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("NOMBRE")]
        public string NOMBRE { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("DIRECCIÓN")]
        public string DIRECCION { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("CIUDAD")]
        public string CD { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string TEL1 { get; set; }
        public string TEL2 { get; set; }
        [Required]
        [DisplayName("ESTATUS")]
        public string STATUS { get; set; }
    }
}