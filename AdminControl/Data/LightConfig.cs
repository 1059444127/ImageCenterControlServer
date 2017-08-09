using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminControl
{
    /// <summary>
    /// 灯光配置
    /// </summary>
    class LightConfig
    {
        /// <summary>
        /// 灯光名
        /// </summary>
        public string LightName { get; set; }

        /// <summary>
        /// 灯光继电器配置
        /// </summary>
        public string RelayNumber { get; set; }
    }
}
