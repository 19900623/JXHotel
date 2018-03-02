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
    /// 地址
    /// </summary>
  [DataContract]
  public  class AddressDataObject
    {   
        [DataMember(Order =1)]
        [Display(Name ="国家")]
        [Required(ErrorMessage = "请输入国家", AllowEmptyStrings = false)]
        public string Country{ get; set; }


        [DataMember(Order = 2)]
        [Display(Name ="城市")]
        [Required(ErrorMessage = "请输入城市", AllowEmptyStrings = false)]
        public string City   { get; set; }

        [DataMember(Order = 3)]
        [Display(Name = "街道")]
        [Required(ErrorMessage = "请输入街道", AllowEmptyStrings = false)]
        public string Street { get; set; }

    }
}
