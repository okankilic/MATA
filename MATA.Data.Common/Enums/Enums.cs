using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Common.Enums
{
    

    //public enum CurrencyCodeTypes
    //{
    //    UNDEFINED,
    //    TRY,
    //    USD
    //}

    public enum AttachmentTypes
    {
        UNDEFINED,
        FORM,
        INVOICE
    }

    #region Projects
    public enum ProjectStates
    {
        WAITING,
        IN_PROGRESS,
        COMPLETED
    }
    #endregion

    #region Issues
    public enum IssueStateTypes
    {
        WAITING,
        APPROVED,
        ASSIGNED,
        INPROGRESS,
        COMPLETED,
        REJECTED
    }

    public enum IssueSourceTypes
    {
        [Display(Name = " ")]
        UNDEFINED,
        [Display(Name = "E-Mail")]
        MAIL,
        [Display(Name = "Telefon")]
        TELEPHONE
    }
    #endregion

    #region Mails
    public enum MailTypes
    {
        FORGOT_PASSWORD
    }

    public enum MailStateTypes
    {
        UNDEFINED,
        WAITING,
        SENDING,
        SENT,
        ERROR
    }
    #endregion

    #region Actions
    public enum ActionTypes
    {
        LOGIN,
        LOGOFF,
        CREATE,
        UPDATE,
        DELETE
    }
    #endregion
}
