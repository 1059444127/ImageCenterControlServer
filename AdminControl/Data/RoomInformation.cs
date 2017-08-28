using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminControl
{
    /// <summary>
    /// 房间类
    /// </summary>
    class RoomInformation
    {
        /// <summary>
        /// 房间ID
        /// </summary>
        public int RoomID { get; set; }

        /// <summary>
        /// 房间名
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 房间使用状态
        /// </summary>
        public bool RoomStatus { get; set; }
    }
}
