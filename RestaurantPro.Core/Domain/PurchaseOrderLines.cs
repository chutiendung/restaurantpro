﻿namespace RestaurantPro.Core.Domain
{
    public class PurchaseOrderLines
    {

        public int PurchaseOrderId { get; set; }

        public int RawMaterialId { get; set; }

        public int SupplierId { get; set; }

        public float Quantity { get; set; }

        public string UnitOfMeasure { get; set; }


        #region Navigation Properties

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual RawMaterial RawMaterial { get; set; }

        public virtual Supplier Supplier { get; set; }

        #endregion
    }
}