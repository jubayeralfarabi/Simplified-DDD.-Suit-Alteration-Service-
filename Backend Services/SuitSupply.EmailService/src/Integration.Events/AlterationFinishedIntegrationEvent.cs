﻿namespace SuitSupply.PaymentService.Integration.Events
{
    public class AlterationFinishedIntegrationEvent
    {
        public Guid AlterationId { get; set; }

        public string CustomerId { get; set; }
    }
}