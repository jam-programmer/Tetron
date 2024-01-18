using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Response
    {
        public  bool IsSuccess { set; get; }=false;
        public string? Message { set; get; }
        public object? Data { set; get; }

        #region Methods

        public static Response Fail(string? message = null)
        {
            return new Response { IsSuccess = false, Message = message };
        }

        public static Response Succeded(string? message = null)
        {
            return new Response { IsSuccess = true, Message = message };
        }

        #endregion
    }
}
