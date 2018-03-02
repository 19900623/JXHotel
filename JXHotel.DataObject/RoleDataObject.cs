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
    /// 用户角色
    /// </summary>
    [DataContract]
  public class RoleDataObject
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [Display(Name ="名称")]
        [Required(ErrorMessage ="请输入名称",AllowEmptyStrings =false)]
        
        public string Name { get; set; }


        [DataMember]
        [Display(Name ="描述")]
        [Required(ErrorMessage = "请输入描述", AllowEmptyStrings = false)]
        public string Description { get; set; }




    }
}
