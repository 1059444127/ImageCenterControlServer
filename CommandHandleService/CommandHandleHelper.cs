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
        #region 获取继电器口控制指令
        /// <summary>
        /// 获取继电器口模式控制指令
        /// </summary>
        /// <param name="PortsOpen">要开启的口，如"1,2,3"</param>
        /// <param name="PortsClose">要关闭的口，如"4,5,6"</param>
        /// <returns></returns>
        public string GetRelayCommand(string PortsOpen, string PortsClose)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=RelayCtl ON={0} OFF={1} CRC=7d8f\r\n", PortsOpen, PortsClose);

            return Command;
        }
        #endregion

        #region 获取投影机控制指令
        /// <summary>
        /// 获取投影机控制指令
        /// </summary>
        /// <param name="ProjectorCount">投影机数量</param>
        /// <param name="PowerStatus">投影机电源状态</param>
        /// <returns></returns>
        public string GetProjectorCommand(string PowerStatus)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=ProjectorCtl Power={0} CRC=1582\r\n", PowerStatus);

            return Command;
        }
        #endregion

        #region 获取矩阵控制指令
        /// <summary>
        /// 获取矩阵控制指令
        /// </summary>
        /// <param name="MatrixIn">矩阵输入，如"1,2,3,4"</param>
        /// <param name="MatrixOut">矩阵输出，如"1,3,2,4"</param>
        /// <returns></returns>
        public string GetMatrixCommand(string MatrixIn, string MatrixOut)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=VideoCtl VideoIn={0} VideoOut={1} CRC=1256\r\n", MatrixIn, MatrixOut);

            return Command;
        }
        #endregion

        #region 获取镜头控制指令
        /// <summary>
        /// 获取镜头控制指令
        /// </summary>
        /// <param name="PowerStatus">电源状态</param>
        /// <param name="EnlargeLevel">缩放等级</param>
        /// <returns></returns>
        public string GetCameraCommand(string PowerStatus, string EnlargeLevel)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=CameraCtl Power={0} EnlargeLevel={1} CRC=1582\r\n", PowerStatus, EnlargeLevel);

            return Command;
        }
        #endregion
    }
}
