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
        #region 获取继电器口单独控制指令
        /// <summary>
        /// 获取继电器口单独控制指令
        /// </summary>
        /// <param name="Port">继电器口编号</param>
        /// <param name="Status">开关状态</param>
        /// <returns></returns>
        public string GetIOPortCommand(int Port, bool Status)
        {
            string Command = string.Empty;

            if (Status)
            {

            }
            else
            {

            }

            return Command;
        }
        #endregion

        #region 获取继电器口模式控制指令
        /// <summary>
        /// 获取继电器口模式控制指令
        /// </summary>
        /// <param name="PortsOpen">要开启的口，如"1,2,3"</param>
        /// <param name="PortsClose">要关闭的口，如"4,5,6"</param>
        /// <returns></returns>
        public string GetModeIOPortCommand(string PortsOpen, string PortsClose)
        {
            string Command = string.Empty;

            return Command;
        }
        #endregion

        #region 获取投影机控制指令
        /// <summary>
        /// 获取投影机控制指令
        /// </summary>
        /// <param name="ProjectorID">投影机编号</param>
        /// <param name="PowerStatus">电源状态</param>
        /// <returns></returns>
        public string GetProjectorCommand(int ProjectorID, bool PowerStatus)
        {
            string Command = string.Empty;

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

            return Command;
        }
        #endregion
    }
}
