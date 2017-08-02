﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCheckService;

namespace CommandHandleService
{
    /// <summary>
    /// 指令解析服务
    /// </summary>
    public class CommandHandleHelper
    {
        #region 全局变量
        /// <summary>
        /// 数据校验实例
        /// </summary>
        private DataCheckHelper DataCheck;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public CommandHandleHelper()
        {
            DataCheck = new DataCheckHelper();
        }
        #endregion

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

            Command = string.Format("cmd=RelayCtl\tON={0}\tOFF={1}", PortsOpen, PortsClose);

            ushort CRCCode = DataCheck.GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode); 

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
        public string GetProjectorCommand(string ProjectorID, string PowerStatus)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=ProjectorCtl\tID={0}\tPower={1}", ProjectorID, PowerStatus);

            ushort CRCCode = DataCheck.GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode);

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

            Command = string.Format("cmd=VideoCtl\tVideoIn={0}\tVideoOut={1}", MatrixIn, MatrixOut);

            ushort CRCCode = DataCheck.GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode);

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

            Command = string.Format("cmd=CameraCtl\tPower={0}\tEnlargeLevel={1}", PowerStatus, EnlargeLevel);

            ushort CRCCode = DataCheck.GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode);

            return Command;
        }
        #endregion

        #region 解析客户端指令包
        /// <summary>
        /// 解析客户端指令包
        /// </summary>
        /// <param name="ClientCommand"></param>
        /// <returns></returns>
        public string GetClientCommand(string ClientCommand)
        {
            string Command = string.Empty;

            if (DataCheck.CheckData(ClientCommand))
            {
                Command = ClientCommand;
                return Command;
            }
            else
            {
                throw new Exception("接收到错误数据");
            }
        }
        #endregion
    }
}
