using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using JXHotel.Infrastructure.Config;
using log4net;

namespace JXHotel.Infrastructure
{
    /// <summary>
    /// 系统工具类
    /// </summary>
    public static class Utils
    {
        #region Private Fields
        private static readonly ILog log = LogManager.GetLogger("Logger");
        #endregion

        #region Public Static Methods
        /// <summary>
        /// 将指定的字符串信息写入日志。
        /// </summary>
        /// <param name="message">需要写入日志的字符串信息。</param>
        public static void Log(string message)
        {
            log.Info(message);
        }
        /// <summary>
        /// 将指定的<see cref="Exception"/>实例详细信息写入日志。
        /// </summary>
        /// <param name="ex">需要将详细信息写入日志的<see cref="Exception"/>实例。</param>
        public static void Log(Exception ex)
        {
            log.Error("Exception caught", ex);
        }

        /// <summary>
        /// 向指定的邮件地址发送邮件。
        /// </summary>
        /// <param name="to">需要发送邮件的邮件地址。</param>
        /// <param name="subject">邮件主题。</param>
        /// <param name="content">邮件内容。</param>
        public static void SendEmail(string to, string subject, string content)
        {
            MailMessage msg = new MailMessage(ConfigurationReader.Instance.EmailSender,
                to,
                subject,
                content);
            SmtpClient smtpClient = new SmtpClient(ConfigurationReader.Instance.EmailHost);
            smtpClient.Port = ConfigurationReader.Instance.EmailPort;
            smtpClient.Credentials = new NetworkCredential(ConfigurationReader.Instance.EmailUserName, ConfigurationReader.Instance.EmailPassword);
            smtpClient.EnableSsl = ConfigurationReader.Instance.EmailEnableSsl;
            smtpClient.Send(msg);
        }
        #endregion
    }
}
