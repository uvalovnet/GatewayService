using Entities.Commands.Account;
using Entities.Commands.Game;
using Entities.Commands.Pay;
using Entities.Interfaces;
using Microsoft.Extensions.Logging;

namespace MessageHelper
{
    public class Sender : ISender
    {
        Producer _producer;
        ILogger _logger;
        public Sender(ILogger logger, string kafkaServer)
        {
            _logger = logger;
            _producer = new Producer(logger, kafkaServer);
        }
        public async Task SendRegAndAuthAsync(RegAndAuthCommand accountData)
        {
            try
            {
 
                await _producer.SendAsync("Account", accountData);
                
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }

        public async Task SendGameAsync(GameActionCommand action)
        {
            try
            {
                await _producer.SendAsync("Game", action);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }

        public async Task SendGameAsync(BillActionCommand action)
        {
            try
            {
                await _producer.SendAsync("Pay", action);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }
    }
}
