using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Infrastructure.Utils.Exceptions
{
    public class BusinessException: Exception
    {
        public BusinessException(): base()
        {

        }

        public BusinessException(string message): base(message)
        {

        }

        public BusinessException(string formatString, params object[] args): base(string.Format(formatString, args))
        {

        }

        public BusinessException(string message, Exception innerException): base(message, innerException)
        {

        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
