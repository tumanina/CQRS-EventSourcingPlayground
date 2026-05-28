using DigitalWallet.Api.Commands;
using DigitalWallet.Api.Dispatchers;
using DigitalWallet.Api.Models;
using DigitalWallet.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWallet.Api.Controllers
{
    [ApiController]
    [Route("wallets")]
    public class WalletsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : ControllerBase
    {
        private readonly ICommandDispatcher _commanDispatcher = commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

        [HttpGet("{walletId}")]
        public async Task<IActionResult> GetUserWallet(Guid walletId)
        {
            var result = await _queryDispatcher.Send<GetWalletByIdQuery, WalletView?>(new GetWalletByIdQuery(walletId));

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost(Name = "CreateWallet")]
        public async Task<IActionResult> CreateWallet(CreateWalletCommand command)
        {
            var result = await _commanDispatcher.Send<CreateWalletCommand, Guid>(command);
            return Ok(result);
        }

        [HttpPost("{walletId}/deposit")]
        public async Task<IActionResult> Deposit(Guid walletId, [FromBody] DepositMoneyCommand command)
        {
            await _commanDispatcher.Send<DepositMoneyCommand, bool>(command with { WalletId = walletId });
            return Ok();
        }

        [HttpPost("{walletId}/withdraw")]
        public async Task<IActionResult> Withdraw(Guid walletId, [FromBody] WithdrawMoneyCommand command)
        {
            await _commanDispatcher.Send<WithdrawMoneyCommand, bool>(command with { WalletId = walletId });
            return Ok();
        }
    }
}
