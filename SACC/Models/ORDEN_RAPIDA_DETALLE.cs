//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SACC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDEN_RAPIDA_DETALLE
    {
        public Nullable<int> ID_ORDEN_RAPIDA { get; set; }
        public string ID_PRODUCTO { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public Nullable<double> SUBTOTAL { get; set; }
        public Nullable<double> CANTIDAD { get; set; }
        public double IVA { get; set; }
        public Nullable<double> TOTAL { get; set; }
        public double IVARETENIDO { get; set; }
        public double ISR { get; set; }
        public double IVADIEZ { get; set; }
        public double ISR2 { get; set; }
        public int NO_PROD { get; set; }
        public string SURTIDO { get; set; }
        public int CAN_RECIBIDA { get; set; }
        public string FACTURA { get; set; }
        public string COMENTARIO_SALID { get; set; }
        public string TPIVA { get; set; }
        public Nullable<double> OTROS_IMP { get; set; }
    }
}
