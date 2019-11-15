using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
