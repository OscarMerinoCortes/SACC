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
    
    public partial class DETALLE_PEDIDO
    {
        public int ID { get; set; }
        public string ID_PRODUCTO { get; set; }
        public Nullable<double> CANTIDAD { get; set; }
        public string ENTREGADO { get; set; }
        public Nullable<int> ID_PEDIDO { get; set; }
        public string DESCRIPCION { get; set; }
        public string ALMACEN { get; set; }
        public string MARCA { get; set; }
    }
}
