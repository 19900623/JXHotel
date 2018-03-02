using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Application
{
  public  class QuerySpec
    {
        private bool _Verbose = false;

        public bool Verbose
        {
            get
            {
                return _Verbose;
            }
            set
            {
                _Verbose = value;
            }
        }

        /// <summary>
        /// 返回一个<c>QuerySpec</c>类型的值，该值表示仅查询
        /// 并构建聚合根的数据传输对象。
        /// </summary>
        public static readonly QuerySpec Empty = new QuerySpec
        {
            Verbose = false
        };

        /// <summary>
        /// 返回一个<c>QuerySpec</c>类型的值，该值表示需要查询并构建聚合根及其下各层的数据传输对象。
        /// </summary>
        public static readonly QuerySpec VerboseOnly = new QuerySpec
        {
            Verbose = true
        };
    }
}
