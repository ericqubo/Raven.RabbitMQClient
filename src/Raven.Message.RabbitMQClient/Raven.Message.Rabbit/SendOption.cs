﻿namespace Raven.Message.RabbitMQ
{
    public class SendOption
    {
        /// <summary>
        /// 优先级（3.5.0开始支持）,默认为0，最小0，最大9
        /// </summary>
        public byte Priority { get; set; }
        /// <summary>
        /// 消息标识
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// 关联Id，回复消息时此字段表示原始消息标识
        /// </summary>
        public string CorrelationId { get; set; }
        /// <summary>
        /// 回复队列名
        /// </summary>
        public string ReplyQueue { get; set; }
        /// <summary>
        /// 是否发送延迟消息
        /// </summary>
        public bool Delay { get; set; }
    }
}