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
    
    public partial class ENTRADA_PRODUCTO
    {
        public int ID { get; set; }
        public int ID_ENTRADA { get; set; }
        public string ID_PRODUCTO { get; set; }
        public Nullable<double> CANTIDAD { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public string MONEDA { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string ID_SUCURSAL { get; set; }
        public string CODIGO_BARAS { get; set; }
        public Nullable<int> NUM_ORDEN { get; set; }
        public string FACT_PROV { get; set; }
    }
}