﻿using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

using Suit.Platform.Infrastructure.Core.Events;
using System.Text.Json;

namespace Suit.AlterationService.Infrastructure.ServiceBus
{
    public class BusMessagePublisher : IBusMessagePublisher
    {
        private readonly BusSettings settings;

        public BusMessagePublisher(IOptions<BusSettings> busSettingsOptions)
        {
            this.settings = busSettingsOptions.Value;
        }

        public Task SendAsync(object @event)
        {
            var client = new ServiceBusClient(this.settings.ConnectionString);
            var sender = client.CreateSender(this.settings.TopicName);
            return sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(@event)));
        }
    }
}
