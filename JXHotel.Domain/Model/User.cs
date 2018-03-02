using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 用户聚合根
    /// </summary>
   public  class User :AggregateRoot
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } 


        /// <summary>
        /// 密码
        /// </summary>
         public string PassWord { get; set; }

         /// <summary>
         /// 邮箱
         /// </summary>
         public string Email { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }


        /// <summary>
        /// 电话
        /// </summary>
         public string Phone { get; set; }

         /// <summary>
         /// 联系地址
         /// </summary>
         public Address ContactAddress { get; set; }

         

      
    }
}
