//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchases()
        {
            this.Arrival = new HashSet<Arrival>();
        }
    
        public long Id_Purchase { get; set; }
        public long Id_Supplier { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public long Id_Specialist { get; set; }
        public System.DateTime Order_date { get; set; }
        public long Id_Product { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arrival> Arrival { get; set; }
        public virtual Products Products { get; set; }
        public virtual Specialists Specialists { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
