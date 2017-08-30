using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    /// <summary>
    /// Report file sending common helper
    /// </summary>
    public class MailSenderHelper
    {
        #region Properties

        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string ReceiverMail2 { get; set; }
        public string ServerSmtp { get; set; }
        private List<Attachment> Attachments { get; set; }
        public string ProcessedFolder { get; set; }
        public string ProcessedSentFolder { get; set; }

        #endregion

        /// <summary>
        /// Sends a mail with .rpt file(s) to relative recipient(s).
        /// </summary>
        public bool SendMail()
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(SenderMail),

                    Subject = Subject,
                    SubjectEncoding = System.Text.Encoding.UTF8,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    Body = Body
                };

                ProcessReceivers(ReceiverMail, message);

                if (!string.IsNullOrEmpty(ReceiverMail2))
                    ProcessReceivers(ReceiverMail2, message);

                if (Attachments != null)
                {
                    foreach (var item in Attachments)
                    {
                        message.Attachments.Add(item);
                    }
                }

                /* smtp taken from configuration file */
                var server = new SmtpClient();
                server.Send(message);

                /* Dispose attachements */
                if (Attachments != null)
                {
                    foreach (var item in Attachments)
                    {
                        item.Dispose();
                        if (File.Exists(ProcessedSentFolder + "\\" + item.Name))
                        {
                            File.Delete(ProcessedSentFolder + "\\" + item.Name);
                        }
                        File.Move(ProcessedFolder + "\\" + item.Name, ProcessedSentFolder + "\\" + item.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                // If send has failed write in the log
                return false;
            }
            return true;
        }

        /// <summary>
        /// Processes the receivers email addresses and adds them to message.
        /// </summary>
        /// <param name="receivers">The receivers email addresses.</param>
        /// <param name="message">The message.</param>
        private static void ProcessReceivers(string receivers, MailMessage message)
        {
            //remove duplicate and empty emails
            var receiverDistinct = string.Join(",", receivers.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).Distinct().ToArray());
            var receiversList = receiverDistinct.Split(',').ToList();

            foreach (var emailAddress in receiversList)
            {
                if (!message.To.Any(m => m.Address.Equals(emailAddress)))
                    message.To.Add(new MailAddress(emailAddress));
            }
        }

        /// <summary>
        /// Adds attachments to the mail to be sent.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public void AddAttachments(List<Attachment> attachments)
        {
            if (Attachments == null)
                Attachments = new List<Attachment>();
            Attachments.AddRange(attachments);
        }

        /// <summary>
        /// Selects the attachments to be added to the email.
        /// </summary>
        /// <returns>The attachments.</returns>
        public List<Attachment> SelectAttachments()
        {
            return Attachments ?? (Attachments = new List<Attachment>());
        }
    }
}
