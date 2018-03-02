using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Event
{
    /// <summary>
    /// Represents that the event handlers applied with this attribute
    /// will handle the events in a asynchronous process.
    /// </summary>
    /// <remarks>This attribute is only applicable to the message handlers and will only
    /// be used by the message buses or message dispatchers. Applying this attribute to
    /// other types of classes will take no effect.
    /// 事件异步处理特性详情参见:http://www.cnblogs.com/daxnet/archive/2013/01/05/2846085.html</remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class HandlesAsynchronouslyAttribute : Attribute
    {

    }
}
