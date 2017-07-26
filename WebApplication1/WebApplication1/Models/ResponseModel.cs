using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Model { get; set; }

        public ResponseModel(object model, bool isSuccess, string message)
        {
            Model = model;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}