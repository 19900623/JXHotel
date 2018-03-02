using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JXHotel.Infrastructure.Config
{
    /// <summary>
    /// jxHotelConfigSection配值信息
    /// </summary>
    public class JXHotelConfigSection   : ConfigurationSection
    {
        private  const string JXHotelConfigSectionSectionName = "jxHotelConfigSection";

        public static JXHotelConfigSection Instance
        {
            get
            {
                return  (JXHotelConfigSection)ConfigurationManager.GetSection(JXHotelConfigSectionSectionName);

            }
        }

       

        
        internal const string EmailClientPropertyName = "emailClient";   
        /// <summary>
        /// 邮件配置属性
        /// </summary>
        [ConfigurationProperty(EmailClientPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual EmailClient EmailClient
        {
            get
            {
                return ((EmailClient)(base[EmailClientPropertyName]));
            }
            set
            {
                base[EmailClientPropertyName] = value;
            }
        }
        

    }
}
