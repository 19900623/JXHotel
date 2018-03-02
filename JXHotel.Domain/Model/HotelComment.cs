using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 酒店评价
    /// </summary>
    public class HotelComment : IEntity
    {
        public HotelComment()
        {
            SubComments = new HashSet<HotelComment>();
        }

        public Guid Id { get; set; }


        public Guid HotelId { get; set; }


        public string Content { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public Decimal Scope { get; set; }

        /// <summary>
        /// 父评论
        /// </summary>
        public Guid ParentId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual HotelComment ParentComment { get; set; }

        public virtual ICollection<HotelComment> SubComments { get; set; }
    }
}
