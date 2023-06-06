//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RotFrontApplication.HelperClass
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipment()
        {
            this.Reject = new HashSet<Reject>();
        }
    
        public int id { get; set; }
        public int Supplier_id { get; set; }
        public System.DateTime Date { get; set; }
        public int Product_id { get; set; }
        public double Count { get; set; }
        public int Ns_id { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public int ToAccept { get; set; }
        public byte Status { get; set; }
    
        public virtual Ns Ns { get; set; }
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reject> Reject { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        public virtual Users Users { get; set; }
    }
}
