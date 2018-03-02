using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 图片
    /// </summary>
  public   class Image :IEntity
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// 图片文字描述
        /// </summary>
        public string Description { get; set; }
    }
}
