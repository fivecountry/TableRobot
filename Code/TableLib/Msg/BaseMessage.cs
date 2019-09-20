using PENet;
using System;
using System.Collections.Generic;
using System.Text;

namespace TableLib.MsgAndSession
{
    [Serializable]
    public class BaseMessage : PEMsg
    {
        /// <summary>
        /// 回复指令（用于收到指令后的回复）
        /// </summary>
        public const string COMMAND_REPLY = "COMMAND_REPLY";

        /// <summary>
        /// 报告指令(用于在Agent刚启动时向服务器发送上线指令)
        /// </summary>
        public const string COMMAND_REPORT = "COMMAND_REPORT";

        /// <summary>
        /// Agent关机指令
        /// </summary>
        public const string COMMAND_SHUTDOWN = "COMMAND_SHUTDOWN";

        /// <summary>
        /// Agent重启指令
        /// </summary>
        public const string COMMAND_REBOOT = "COMMAND_REBOOT";

        /// <summary>
        /// 显示屏幕指令(用于Agent向Designer发送屏幕图像)
        /// </summary>
        public const string COMMAND_DISPLAYSCREEN = "COMMAND_DISPLAYSCREEN";

        /// <summary>
        /// 开始截屏指令(用于Designer向Agent发送启动屏幕图像发送进程)
        /// </summary>
        public const string COMMAND_STARTREMOTE = "COMMAND_STARTREMOTE";

        /// <summary>
        /// 停止截屏指令(用于Designer向Agent发送启动屏幕图像发送进程)
        /// </summary>
        public const string COMMAND_STOPREMOTE = "COMMAND_STOPREMOTE";

        /// <summary>
        /// 调试脚本指令(用于Designer向Agent不经过Server直接发送一段任务脚本来执行)
        /// </summary>
        public const string COMMAND_DEBUGSCRIPT = "COMMAND_DEBUGSCRIPT";

        /// <summary>
        /// 运行任务脚本指令（用于Server向Agent派发任务）
        /// </summary>
        public const string COMMAND_RUNTASKSCRIPT = "COMMAND_RUNTASKSCRIPT";

        /// <summary>
        /// 从
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 到
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 命令
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public object Tag { get; set; }
    }
}