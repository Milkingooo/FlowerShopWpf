//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowerShop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdGood { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    
        public virtual Good Good { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
