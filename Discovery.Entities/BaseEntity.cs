using System;
using System.Collections.Generic;
using System.Text;

namespace Discovery.Entities
{
    public class BaseEntity<TEntity> where TEntity : BaseEntity<TEntity>
    {
        public Guid Id { get; set; }
    }
}
