using MATA.BL.Impls;
using MATA.Data.Common.Constants;
using MATA.Data.Common.Enums;
using MATA.Data.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Batch.MailSender
{
    class Program
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            _Logger.Info("MailSender started at " + DateTime.Now);

            var sw = new Stopwatch();

            sw.Start();

            int mailCount = Convert.ToInt32(ConfigurationManager.AppSettings["MailCount"]);
            int maxTryCount = Convert.ToInt32(ConfigurationManager.AppSettings["MaxTryCount"]);

            try
            {
                using (var db = new MataDBEntities())
                {
                    var mailList = MailBL.GetList(maxTryCount, mailCount, db);

                    _Logger.Info(mailList.Count() + " mail(s) fetched to send");

                    foreach (var mail in mailList)
                    {
                        var mailAccounts = MailAccountBL.GetList(mail.ID, db);
                        var mailAttachments = MailAttachmentBL.GetList(mail.ID, db);

                        mail.TryCount++;

                        MailBL.UpdateState(mail.ID, MailStateTypes.SENDING, mail.TryCount, db);

                        try
                        {
                            SendMail(mail, mailAccounts, mailAttachments);
                        }
                        catch (Exception ex)
                        {
                            MailBL.UpdateState(mail.ID, MailStateTypes.ERROR, mail.TryCount, db);

                            _Logger.Error(ex, "Error occured while sending mail: " + mail.ID);
                        }

                        MailBL.UpdateState(mail.ID, MailStateTypes.SENT, mail.TryCount, db);
                    };
                }
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Error occured as fetching mails");
            }

            sw.Stop();

            _Logger.Info("MailSender finished in " + sw.Elapsed);
        }

        private static void SendMail(Mail mail, IEnumerable<vMailAccount> mailAccounts, IEnumerable<vMailAttachment> attachments)
        {
            _Logger.Info("Sending mail: " + mail.ID);

            var smtpClient = new SmtpClient();

            if (!string.IsNullOrWhiteSpace(smtpClient.PickupDirectoryLocation) && !Directory.Exists(smtpClient.PickupDirectoryLocation))
            {
                Directory.CreateDirectory(smtpClient.PickupDirectoryLocation);

                _Logger.Info("PickupDirectoryLocation created as " + smtpClient.PickupDirectoryLocation);
            }
            
            var message = new MailMessage();

            message.Subject = mail.Subject;
            message.SubjectEncoding = Encoding.UTF8;

            message.Body = mail.MailBody;
            message.IsBodyHtml = mail.IsBodyHtml;

            //using (var fs = File.OpenText(@"Templates\Template1.html"))
            //{
            //    var content = fs.ReadToEnd();
            //    message.Body = content.Replace("#HEADER#", "This is a sample header");
            //}

            message.Sender = new MailAddress("noreply@gmail.com");
            message.From = new MailAddress("noreply@gmail.com");

            foreach (var to in mailAccounts.Where(q => q.ToCcBcc == MailToCcBccTypes.TO))
            {
                message.To.Add(new MailAddress(to.Email, to.FullName));
            }

            foreach (var cc in mailAccounts.Where(q => q.ToCcBcc == MailToCcBccTypes.CC))
            {
                message.CC.Add(new MailAddress(cc.Email, cc.FullName));
            }

            foreach (var bcc in mailAccounts.Where(q => q.ToCcBcc == MailToCcBccTypes.BCC))
            {
                message.Bcc.Add(new MailAddress(bcc.Email, bcc.FullName));
            }

            foreach (var attachment in attachments)
            {
                message.Attachments.Add(new System.Net.Mail.Attachment(File.OpenRead(attachment.FilePath), attachment.FileName));
            }

            smtpClient.Send(message);

            _Logger.Info("Sent mail: " + mail.ID);
        }
    }
}
