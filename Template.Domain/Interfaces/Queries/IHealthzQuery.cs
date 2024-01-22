using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Interfaces.Queries
{
    public interface IHealthzQuery
    {
        Task<bool> Get();
    }
}
