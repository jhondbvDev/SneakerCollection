﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        public AggregateRoot(TId id):base(id) 
        {
                
        }


#pragma warning disable CS8618
        protected AggregateRoot()
        {

        }
#pragma warning restore CS8618
    }
}
