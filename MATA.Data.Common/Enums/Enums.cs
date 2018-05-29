using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Common.Enums
{
    public enum ContactTypes
    {
        UNDEFINED,
        MAIL,
        TELEPHONE
    }

    public enum CurrencyCodeTypes
    {
        UNDEFINED,
        TRY,
        USD
    }

    public enum MailStateTypes
    {
        UNDEFINED,
        WAITING,
        SENDING,
        SENT,
        ERROR
    }

    public enum AttachmentTypes
    {
        UNDEFINED,
        FORM,
        INVOICE
    }

    public enum IssueStateTypes
    {
        WAITING,
        APPROVED,
        ASSIGNED,
        INPROGRESS,
        COMPLETED,
        REJECTED
    }
}
