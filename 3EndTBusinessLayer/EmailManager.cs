using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3EndTDataLayer;
using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using System.Net.Mail;
using System.Net;
using System.Configuration;
namespace _3EndTBusinessLayer
{
    public class EmailManager
    {
        private static string _smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
        private static string _fromEmailId = ConfigurationManager.AppSettings["FromEmailId"];
        private static string _fromEmailName = ConfigurationManager.AppSettings["FromEmailName"];
        private static string _toEmailIds = ConfigurationManager.AppSettings["ToEmailIds"];
        private static string _toEmailName = ConfigurationManager.AppSettings["ToEmailName"];
        private static string _ccEmailIds = ConfigurationManager.AppSettings["CCEmailIds"];


        public static Enums.EmailSentStatus SendEmail(string EmailSubject, string EmailMessage, string AttachmentURLs,
            int BuildAttachmentRequestTimeOut, string FromEmailID = "", string FromEmailName = "",
            string ToEmailID = "", string ToEmailName = "", string CCEmailIDs = "", string BCCEmailIDs = "")
        {
            try
            {
                #region commented out
                /*if (!string.IsNullOrEmpty(_smtpHost) && !string.IsNullOrEmpty(_fromEmailId) && !string.IsNullOrEmpty(_emailPwd))
                {
                    if (string.IsNullOrEmpty(BCCEmailIDs))
                        BCCEmailIDs = "raj_ralhan@hotmail.com";
                    if (string.IsNullOrEmpty(FromEmailID))
                        FromEmailID = _fromEmailId;
                    MailMessage message = new MailMessage();
                    if (string.IsNullOrEmpty(FromEmailName))
                        FromEmailName = _fromEmailName;

                    message.From = new MailAddress(FromEmailName + "<" + FromEmailID + ">");
                    if (string.IsNullOrEmpty(ToEmailID))
                        ToEmailID = _toEmailId;
                    if (string.IsNullOrEmpty(ToEmailName))
                        message.To.Add(new MailAddress(ToEmailID));
                    else
                        message.To.Add(new MailAddress(ToEmailName + "<" + ToEmailID + ">"));
                    if (!string.IsNullOrEmpty(CCEmailIDs))
                        message.CC.Add(new MailAddress(CCEmailIDs));
                    if (!string.IsNullOrEmpty(BCCEmailIDs))
                        message.Bcc.Add(new MailAddress(BCCEmailIDs));
                    message.Subject = EmailSubject;
                    message.IsBodyHtml = true;
                    message.Body = EmailMessage;

                    if (!string.IsNullOrEmpty(AttachmentURLs))
                    {
                        string[] strArray = AttachmentURLs.Split(new char[] { ',' });
                        for (int i = 0; i <= strArray.Length; i++)
                        {
                            Attachment item = new Attachment(strArray[i].Trim());
                            message.Attachments.Add(item);
                        }
                    }
                    int hashCode = Enums.EmailSentStatus.Fail.GetHashCode();

                    NetworkCredential credential = new NetworkCredential();
                    credential.UserName = _fromEmailId;
                    credential.Password = _emailPwd;
                    // credential.Domain = "3endtshop.com.oak.arvixe.com";

                    SmtpClient smtpClient = new SmtpClient(_smtpHost);
                    smtpClient.Port = 26;
                    //smtpClient.Host = _smtpHost;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = false;

                    smtpClient.Credentials = credential;
                    smtpClient.Send(message);

                    return Enums.EmailSentStatus.Success;
                }
                if (!string.IsNullOrEmpty(_smtpHost) && !string.IsNullOrEmpty(_fromEmailId))
                {
                    if (string.IsNullOrEmpty(BCCEmailIDs))
                        BCCEmailIDs = "raj_ralhan@yahoo.com";

                    var message = new MailMessage();

                    if (string.IsNullOrEmpty(ToEmailID))
                        ToEmailID = _toEmailId;
                    if (string.IsNullOrEmpty(ToEmailName))
                        message.To.Add(ToEmailID);
                    else
                        message.To.Add(new MailAddress(ToEmailID, ToEmailName));

                    message.CC.Add("rajiv.ralhan@gmail.com,raj_ralhan@hotmail.com");

                    message.From = new MailAddress(_fromEmailId);
                    message.Subject = EmailSubject;
                    message.IsBodyHtml = true;
                    message.Body = EmailMessage;

                    var smtp = new SmtpClient(_smtpHost);
                    //smtp.Port = 25;
                    //smtp.EnableSsl = false;
                    //smtp.UseDefaultCredentials = true;

                    smtp.Send(message);

                    return Enums.EmailSentStatus.Success;
                }
                 */


                #endregion

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    var basicCredential = new NetworkCredential("noreply@3endt.com", "arvixe101");
                    using (MailMessage message = new MailMessage())
                    {
                        if (string.IsNullOrEmpty(ToEmailID))
                            ToEmailID = _toEmailIds;

                        if (string.IsNullOrEmpty(ToEmailName))
                            message.To.Add(ToEmailID);
                        else
                            message.To.Add(new MailAddress(ToEmailID, ToEmailName));

                        message.CC.Add(_ccEmailIds);                     

                        if (FromEmailName != null && FromEmailID != null)
                            message.From = new MailAddress(FromEmailID, FromEmailName);
                        else
                            message.From = new MailAddress(_fromEmailId, _fromEmailName);

                        message.Subject = EmailSubject;
                        message.IsBodyHtml = true;
                        message.Body = EmailMessage;

                        smtpClient.Host = "3endt.com";
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = basicCredential;

                        //smtpClient.Host = "m1.aspendora.com";
                        //smtpClient.Port = 2596;
                        //smtpClient.UseDefaultCredentials = false;

                        try
                        {
                            smtpClient.Send(message);
                            return Enums.EmailSentStatus.Success;
                        }
                        catch (Exception ex)
                        {
                            //Error, could not send the message
                            //Response.Write(ex.Message);
                        }
                    }
                }


                return Enums.EmailSentStatus.Fail;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
