using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models
{
    public class CustomJsonResult
    {
        public bool IsSuccess { get; private set; } = true;

        public string ErrorMessage { get; private set; }

        public void setError(string message)
        {
            this.ErrorMessage = message;
            this.IsSuccess = false;
        }
    }
}