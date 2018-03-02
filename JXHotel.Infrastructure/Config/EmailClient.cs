using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JXHotel.Infrastructure.Config
{
    /// <summary>
    /// email配置
    /// </summary>
   public class EmailClient :ConfigurationElement
    {
       
        public override bool IsReadOnly()
        {
            return false;
        }



        internal const string HostPropertyName = "host";    
        [ConfigurationProperty(HostPropertyName, IsRequired = true, IsKey = true, IsDefaultCollection = false)]
        public virtual string Host
        {
            get
            {
                return ((string)(base[HostPropertyName]));              
            }
            set
            {
                base[HostPropertyName] = value;
            }
        }



        internal const string PortPropertyName = "port";    
        [ConfigurationProperty(PortPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual int Port
        {
            get
            {
                return ((int)(base[PortPropertyName]));
            }
            set
            {
                base[PortPropertyName] = value;
            }
        }



        internal const string UserNamePropertyName = "userName";       
        [ConfigurationProperty(UserNamePropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual string UserName
        {
            get
            {
                return ((string)(base[UserNamePropertyName]));
            }
            set
            {
                base[UserNamePropertyName] = value;
            }
        }



        internal const string PasswordPropertyName = "password";
        [ConfigurationProperty(PasswordPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual string Password
        {
            get
            {
                return ((string)(base[PasswordPropertyName]));
            }
            set
            {
                base[PasswordPropertyName] = value;
            }
        }
       
        internal const string EnableSslPropertyName = "enableSsl";
        [ConfigurationPropertyAttribute(EnableSslPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual bool EnableSsl
        {
            get
            {
                return ((bool)(base[EnableSslPropertyName]));
            }
            set
            {
                base[EnableSslPropertyName] = value;
            }
        }
        

      
        internal const string SenderPropertyName = "sender";     
        [ConfigurationProperty(SenderPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual string Sender
        {
            get
            {
                return ((string)(base[SenderPropertyName]));
            }
            set
            {
                base[SenderPropertyName] = value;
            }
        }
        
    }
}
