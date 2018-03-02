using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace JXHotel.DataObject
{
    /// <summary>
    /// 收付款账号
    /// </summary>
    [DataContract]
  public   class BankAccountDataObject
    {   
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [Display(Name="账号")]
        public string Name { get; set; }

        /// <summary>
        /// 是否默认账号
        /// </summary>
        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        [Display(Name="是否默认")]
        public string IsDefaultText
        {
            get
            {
                return IsDefault ? "是" : "否";
            }
        }
    }
}
