﻿using Raven.Message.RabbitMQ.Abstract;
using Raven.Message.RabbitMQ.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Message.RabbitMQ
{
    internal class Factory
    {
        static Dictionary<string, FacilityManager> _facilities = new Dictionary<string, FacilityManager>();
        static Dictionary<string, ChannelManager> _channels = new Dictionary<string, ChannelManager>();

        internal static Consumer CreateConsumer(ILog log, BrokerConfiguration brokerConfig)
        {
            Consumer consusmer = new Consumer();
            consusmer.BrokerConfig = brokerConfig;
            consusmer.Log = log;
            consusmer.Facility = CreateFacility(log, brokerConfig);
            consusmer.Channel = CreateChannel(log, brokerConfig);
            return consusmer;
        }

        internal static Producer CreateProducer(ILog log, BrokerConfiguration brokerConfig)
        {
            Producer producer = new Producer();
            producer.BrokerConfig = brokerConfig;
            producer.Log = log;
            producer.Facility = CreateFacility(log, brokerConfig);
            producer.Channel = CreateChannel(log, brokerConfig);
            return producer;
        }

        static FacilityManager CreateFacility(ILog log, BrokerConfiguration brokerConfig)
        {
            if (!_facilities.ContainsKey(brokerConfig.Name))
            {
                lock (_facilities)
                {
                    if (!_facilities.ContainsKey(brokerConfig.Name))
                    {
                        FacilityManager facility = new FacilityManager(log, brokerConfig);
                        _facilities.Add(brokerConfig.Name, facility);
                    }
                }
            }
            return _facilities[brokerConfig.Name];
        }

        static ChannelManager CreateChannel(ILog log, BrokerConfiguration brokerConfig)
        {
            if (!_channels.ContainsKey(brokerConfig.Name))
            {
                lock (_channels)
                {
                    if (!_channels.ContainsKey(brokerConfig.Name))
                    {
                        ChannelManager channel = new ChannelManager(log, brokerConfig);
                        _channels.Add(brokerConfig.Name, channel);
                    }
                }
            }
            return _channels[brokerConfig.Name];
        }
    }
}
