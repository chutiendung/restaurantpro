﻿using System.Data.Entity.ModelConfiguration;
using RestaurantPro.Core.Domain;

namespace RestaurantPro.Infrastructure.EntityConfigurations
{
    public class PurchaseOrderLinesConfiguration : EntityTypeConfiguration<PurchaseOrderLine>
    {
        public PurchaseOrderLinesConfiguration()
        {
            HasKey(table => new
            {
                table.PurchaseOrderId,
                table.SupplierId,
                table.RawMaterialId
            });

            Property(p => p.LeadTime)
                .IsOptional();

            Ignore(a => a.SupplierStringTemp);
            Ignore(a => a.RawMaterialStringTemp);
        }
    }
}