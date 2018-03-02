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
    /// 酒店分类
    /// </summary>
    [DataContract]
    public class HotelCategoryDataObject
    {


        //public HotelCategory()
        //{
        //    Hotels = new HashSet<Hotel>();
        //}

        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [DataMember]
        [Required(ErrorMessage ="请输入名称",AllowEmptyStrings =false)]
        [Display(Name ="名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        [Display(Name="描述")]
        public string Description { get; set; }

       // public virtual ICollection<Hotel> Hotels { get; set; }



    }
}
