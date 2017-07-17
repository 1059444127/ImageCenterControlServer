using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminControl
{
    /// <summary>
    /// 设备信息类
    /// </summary>
    class DeviceInformation
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="ConfigPath"></param>
        public DeviceInformation(string ConfigPath)
        {

        }

        /// <summary>
        /// 矩阵信息结构体
        /// </summary>
        public struct Mutrix
        {
            public string Name { get; set; }

            public byte[] PowerOn { get; set; }

            public byte[] PowerOff { get; set; }

            public byte[] ChangeMode { get; set; }
        }

        /// <summary>
        /// 投影机信息结构体
        /// </summary>
        public struct Projector
        {
            public string Name { get; set; }

            public byte[] PowerOn { get; set; }

            public byte[] PowerOff { get; set; }
        }

        /// <summary>
        /// 镜头信息结构体
        /// </summary>
        public struct Camera
        {
            public string Name { get; set; }

            public byte[] PowerOn { get; set; }

            public byte[] PowerOff { get; set; }
        }
    }
}
