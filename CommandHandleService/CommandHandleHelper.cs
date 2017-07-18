using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandleService
{
    /// <summary>
    /// 指令解析服务
    /// </summary>
    public class CommandHandleHelper
    {
        /// <summary>
        /// 获取灯光控制指令
        /// </summary>
        /// <param name="LightOpen">要开启的继电器口</param>
        /// <param name="LightClose">要关闭的继电器口</param>
        /// <returns></returns>
        public string GetLightsControlCommand(string LightOpen, string LightClose)
        {
            string LightCommand = string.Empty;

            LightCommand = string.Format("cmd=LightCtl ON={0} OFF={1} CRC=7d8f\r\n", LightOpen, LightClose);

            return LightCommand;
        }
    }
}
