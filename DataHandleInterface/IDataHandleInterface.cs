using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandleInterface
{
    /// <summary>
    /// 数据处理接口
    /// </summary>
    public interface IDataHandleInterface
    {
        /// <summary>
        /// 获得继电器控制指令
        /// </summary>
        /// <param name="PortsOpen"></param>
        /// <param name="PortsClose"></param>
        /// <returns></returns>
        string GetRelayCommand(string PortsOpen, string PortsClose);

        /// <summary>
        /// 获得投影机控制指令
        /// </summary>
        /// <param name="ProjectorID"></param>
        /// <param name="PowerStatus"></param>
        /// <returns></returns>
        string GetProjectorCommand(string ProjectorID, string PowerStatus);

        /// <summary>
        /// 获得矩阵控制指令
        /// </summary>
        /// <param name="MatrixIn"></param>
        /// <param name="MatrixOut"></param>
        /// <returns></returns>
        string GetMatrixCommand(string MatrixIn, string MatrixOut);

        /// <summary>
        /// 获得镜头控制指令
        /// </summary>
        /// <param name="PowerStatus"></param>
        /// <param name="EnlargeLevel"></param>
        /// <returns></returns>
        string GetCameraCommand(string PowerStatus, string EnlargeLevel);

        /// <summary>
        /// 获得CRC校验码
        /// </summary>
        /// <param name="RawData"></param>
        /// <returns></returns>
        string GetCRCCode(string RawData);

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        bool CheckData(string Data);
    }
}
