using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminControl
{
    /// <summary>
    /// 模式配置
    /// </summary>
    class ModeConfig
    {
        /// <summary>
        /// 获取或设置模式名
        /// </summary>
        public string ModeName { get; set; }

        /// <summary>
        /// 获取或设置继电器
        /// </summary>
        public string Relays { get; set; }

        /// <summary>
        /// 获取或设置投影机1
        /// </summary>
        public string ProjectorOne { get; set; }

        /// <summary>
        /// 获取或设置投影机2
        /// </summary>
        public string ProjectorTwo { get; set; }

        /// <summary>
        /// 获取或设置矩阵
        /// </summary>
        public string Matrix { get; set; }

        /// <summary>
        /// 获取或设置镜头
        /// </summary>
        public string Camera { get; set; }
    }
}
