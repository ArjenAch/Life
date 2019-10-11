using Life.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Exercise
{
    public abstract class BaseService
    {
        protected readonly LifeDbContext _context;

        public BaseService(LifeDbContext context)
        {
            this._context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
