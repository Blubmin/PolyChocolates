using System;

namespace PolyChocolates
{
    [Table(Name = "PRODUCT_ENTRY")]
    public class ProductEntry
    {
        [Column(isPrimaryKey = true)]
        public int productEntryID;
        [Column]
        public String lotCode;
        [Column]
        public int amountPackaged;
        [Column]
        public int amountProduced;
    }
}