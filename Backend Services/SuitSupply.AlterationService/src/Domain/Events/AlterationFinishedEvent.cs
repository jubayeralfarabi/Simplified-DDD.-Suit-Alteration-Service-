﻿namespace SuitSupply.AlterationService.Domain.Events
{
    using System;
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Core.Domain;

    /// <summary>Event for Alteration Creation.</summary>
    public class AlterationFinishedEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlterationCreatedEvent"/> class.
        /// </summary>
        public AlterationFinishedEvent(Guid alterationId, AlterationStatusEnum status, string CustomerId, Guid coorelationId)
        {
            this.AlterationId = alterationId;
            this.Status = status;
            this.CorrelationId = coorelationId;
            this.CorrelationId = coorelationId;
        }

        public Guid AlterationId { get; private set; }

        public string CustomerId { get; private set; }

        public AlterationStatusEnum Status { get; private set; }
    }
}