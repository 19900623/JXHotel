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
    /// 酒店评价
    /// </summary>
    [DataContract]
    public class HotelCommentDataObject
    {
        //public HotelComment()
        //{
        //    SubComments = new HashSet<HotelComment>();
        //}
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid HotelId { get; set; }

        [DataMember]
        [Display(Name ="内容")]
        [Required(ErrorMessage ="请输入内容",AllowEmptyStrings =false)]
        public string Content { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        [DataMember]
        [Display(Name ="评分")]
        [Required(ErrorMessage ="请输入评分",AllowEmptyStrings =false)]
        public Decimal Scope { get; set; }

        /// <summary>
        /// 父评论
        /// </summary>
        [DataMember]
        public Guid ParentId { get; set; }

        // public virtual Hotel Hotel { get; set; }

        [DataMember]
        public HotelCommentDataObject ParentComment { get; set; }

        [DataMember]
        public  List<HotelCommentDataObject> SubComments { get; set; }
    }
}
