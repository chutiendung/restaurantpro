﻿using System;
using System.Collections.Generic;

namespace RestaurantPro.Core.Domain
{
    public class WorkCycle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        public bool Active { get; set; }

        public int UserId { get; set; }

        public string StatusId { get; set; }

        public IEnumerable<WorkCycleLines> Lines { get; set; }


        #region Navigation Properties

        public virtual User User { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        public virtual ICollection<WorkCycleLines> WorkCycleLines { get; set; }

        public virtual ICollection<WorkCycleAdjustments> WorkCycleAdjustments { get; set; }

        public virtual WcStatus Status { get; set; }

        #endregion
    }
}