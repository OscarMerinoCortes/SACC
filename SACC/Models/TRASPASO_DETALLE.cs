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
    
    public partial class TRASPASO_DETALLE
    {
        public int ID_TRASPASO_DETALLE { get; set; }
        public Nullable<int> ID_TRASPASO { get; set; }
        public string ID_PRODUCTO { get; set; }
        public Nullable<double> CANTIDAD { get; set; }
        public string ESTADO { get; set; }
    }
}
