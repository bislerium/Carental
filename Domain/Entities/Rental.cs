﻿using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rental: AuditableEntity
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public int CarId { get; set; }

        public Car Car { get; set; } = null!;

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Pending;

        public bool IsCancelled { get; set; }

        public bool IsReturned { get; set; }
    }
}