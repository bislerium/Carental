﻿namespace Carental.Domain.Common
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        public BaseEntity() 
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
