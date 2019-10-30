using Life.Application.Mapping.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Application.Services.Interfaces.Util
{
    public interface IUserFriendlyExceptionMapper
    {
        OperationResponse Map(Exception exception);
    }
}
