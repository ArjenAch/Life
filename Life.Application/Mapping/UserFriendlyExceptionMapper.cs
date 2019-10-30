using Life.Application.Mapping.DTO;
using Life.Application.Services.Interfaces.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Life.Application.Mapping
{
    public class UserFriendlyExceptionMapper : IUserFriendlyExceptionMapper
    {
        public readonly IDictionary ErrorMappings = new Dictionary<Type, string>()
        {
            { typeof(DbUpdateException), "sorry 1" },
            { typeof(DbUpdateConcurrencyException), " sorry 2" },
            { typeof(SqlException), " sorry 3" }
        };

        public OperationResponse Map (Exception exception)
        {
            if(exception.InnerException != null)
            {
                return Map(exception.InnerException);
            } else
            {
                if(ErrorMappings.Contains(exception.GetType()))
                {
                    var message = ErrorMappings[exception.GetType()];
                    return new OperationResponse(false, message.ToString());
                }
                else
                {
                    return new OperationResponse(false, "Sorry! something went wrong...");
                }
            }
        }
    }
}
