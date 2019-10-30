using Life.Application.Mapping.DTO;
using Life.Application.Services.Interfaces.Util;
using Life.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Exercise
{
    public abstract class BaseService
    {
        protected readonly LifeDbContext _context;
        protected readonly IUserFriendlyExceptionMapper _exceptionMapper;

        public BaseService(LifeDbContext context, IUserFriendlyExceptionMapper exceptionMapper)
        {
            this._context = context;
            this._exceptionMapper = exceptionMapper;
        }

        public async Task<OperationResponse> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return new OperationResponse(true, "Saved succesfully");
            }
            catch (Exception exception)
            {
                return _exceptionMapper.Map(exception);
            }
        }

    }
}
