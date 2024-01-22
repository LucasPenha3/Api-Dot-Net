using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.Infra.Contexts;
using Template.Domain.Interfaces.Queries;

namespace template.Infra.Queries
{
    public class HealthzQuery : IHealthzQuery
    {
        private readonly DataContext _context;

        public HealthzQuery(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Get()
        {
            return await _context.Database.CanConnectAsync();
        }
    }
}
