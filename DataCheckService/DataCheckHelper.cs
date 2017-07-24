using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCheckService
{
    /// <summary>
    /// 数据校验服务
    /// </summary>
    public class DataCheckHelper
    {
        /// <summary>
        /// 获得CRC校验码
        /// </summary>
        /// <param name="Data">待校验的数据</param>
        /// <returns></returns>
        public ushort GetCRCCode(byte[] Data)
        {
            uint IX, IY;

            ushort CRCCode = 0xFFFF;

            int len = Data.Length;
            if (len <= 0)
            {
                CRCCode = 0;
            }
            else
            {
                len--;
                for (IX = 0; IX <= len; IX++)
                {
                    CRCCode = (ushort)(CRCCode ^ (Data[IX]));

                    for (IY = 0; IY <= 7; IY++)
                    {
                        if ((CRCCode & 1) != 0)
                        {
                            CRCCode = (ushort)((CRCCode >> 1) ^ 0xA001);
                        }
                        else
                        {
                            CRCCode = (ushort)(CRCCode >> 1);
                        }
                    }
                }
            }

            byte buf1 = (byte)((CRCCode & 0xff00) >> 8);//高位置
            byte buf2 = (byte)(CRCCode & 0x00ff); //低位置

            CRCCode = (ushort)(buf1 << 8);

            CRCCode += buf2;

            return CRCCode;
        }
    }
}
