using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JXHotel.Infrastructure.Config
{
    /// <summary>
    /// 配置信息读取
    /// </summary>
    public sealed class ConfigurationReader
    {
        #region Private Fields
        private readonly JXHotelConfigSection configuration;
        private static readonly ConfigurationReader instance = new ConfigurationReader();
        #endregion

        #region Ctor
        static ConfigurationReader() { }

        private ConfigurationReader()
        {
            this.configuration = JXHotelConfigSection.Instance;
            if (this.configuration == null)
                throw new ConfigurationErrorsException("当前应用程序的配置文件中不存在与JXHotel相关的配置信息。");
        }
        #endregion

        #region Public Properties
       

        public string EmailHost
        {
            get { return configuration.EmailClient.Host; }
        }

        public int EmailPort
        {
            get { return configuration.EmailClient.Port; }
        }

        public string EmailUserName
        {
            get { return configuration.EmailClient.UserName; }
        }

        public string EmailPassword
        {
            get { return configuration.EmailClient.Password; }
        }

        public string EmailSender
        {
            get { return configuration.EmailClient.Sender; }
        }

        public bool EmailEnableSsl
        {
            get { return configuration.EmailClient.EnableSsl; }
        }
        /// <summary>
        /// 获取<c>ByteartRetailConfigurationReader</c>的单例类型。
        /// </summary>
        public static ConfigurationReader Instance
        {
            get { return instance; }
        }
        #endregion

        
    }
}
