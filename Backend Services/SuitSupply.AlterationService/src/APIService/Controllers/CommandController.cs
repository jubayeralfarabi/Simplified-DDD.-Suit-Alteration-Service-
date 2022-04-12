namespace Suit.AlterationService.APIService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Suit.AlterationService.Application.Commands;
    using Suit.Platform.Infrastructure.Core;
    using Suit.Platform.Infrastructure.Core.Commands;

    [ApiController]
    [Route("[controller]/[action]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> logger;
        private readonly IDispatcher dispatcher;

        public CommandController(ILogger<CommandController> logger, IDispatcher dispatcher)
        {
            this.logger = logger;
            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// API to create alteration.
        /// </summary>
        /// <param name="command"><see cref="CreateAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAlteration([FromBody] CreateAlterationCommand command)
        {
            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            return CheckResponse(response);
        }

        /// <summary>
        /// API to start processing Alteration.
        /// </summary>
        /// <param name="command"><see cref="StartProcessingAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> StartProcessing([FromBody] StartProcessingAlterationCommand command)
        {
            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            return CheckResponse(response);
        }

        /// <summary>
        /// API to Finish Alteration.
        /// </summary>
        /// <param name="command"><see cref="FinishAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> FinishAlteration([FromBody] FinishAlterationCommand command)
        {
            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            return CheckResponse(response);
        }

        private IActionResult CheckResponse(CommandResponse response)
        {
            if (!response.ValidationResult.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public string Ping()
        {
            return "Server is running";
        }
    }
}