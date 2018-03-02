using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JXHotel.DataObject
{
    /// <summary>
    /// 用户
    /// </summary>
    
   [DataContract]
   public  class UserDataObject
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember(Order =1)]
        [Display(Name ="账号")]
        [Required(ErrorMessage ="请输入账号",AllowEmptyStrings =false)]
        [MaxLength(20)]
        public string Name { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        [DataMember(Order = 2)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码", AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string PassWord { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember(Order = 3)]
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "请输入邮箱", AllowEmptyStrings = false)]
        [MaxLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember(Order = 4)]
        [Display(Name = "联系人")]
        public string ContactName { get; set; }


        /// <summary>
        /// 电话
        /// </summary>
        [DataMember(Order = 5)]
        [Display(Name = "电话")]
        public string Phone { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [DataMember(Order = 6)]
        public AddressDataObject ContactAddress { get; set; }

         

      
    }
}
