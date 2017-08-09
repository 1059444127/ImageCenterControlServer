using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminControl
{
    /// <summary>
    /// 幕布配置
    /// </summary>
    class FilmConfig
    {
        /// <summary>
        /// 幕布名
        /// </summary>
        public string FilmName { get; set; }

        /// <summary>
        /// 幕布继电器配置
        /// </summary>
        public string RelayNumber { get; set; }
    }
}
