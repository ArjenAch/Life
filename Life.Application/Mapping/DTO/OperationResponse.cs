using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Application.Mapping.DTO
{
    public class OperationResponse
    {
        public readonly bool Succes;
        public string Message { get; set; }

        public OperationResponse(bool succes, string message)
        {
            Succes = succes;
            Message = message;
        }

        public string ToString(string subjectname)
        {
            return $" Succes: {(Succes ? "True" : "False")}" +
                $" {(!string.IsNullOrEmpty(Message) ? "Message: " + Message : "")}" +
                $"For operation on: {subjectname}";
        }
    }
}
