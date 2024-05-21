using Entities.Interfaces;
using Entities.Queries;
using Entities.Queries.Account;
using Entities.Queries.Game;
using Microsoft.Extensions.Logging;

namespace MessageHelper
{
    public class CallbackSeparator : ICallbackSeparator
    {
        Consumer _consumerGateway;
        ILogger _logger;

        event ICallbackSeparator.AuthenticationDelegate onAuthentication;
        event ICallbackSeparator.RegistrationDelegate onRegistration;
        event ICallbackSeparator.GetGamesDelegate onGetGames;
        event ICallbackSeparator.AddToTableDelegate onAddToTable;
        event ICallbackSeparator.RemoveFromTableDelegate onRemoveFromTable;
        event ICallbackSeparator.TakeActionDelegate onTakeAction;

        public CallbackSeparator(ILogger logger, string kafkaServer)
        {
            _logger = logger;
            _consumerGateway = new Consumer(logger, kafkaServer);
            _consumerGateway.onMessage += CallbackMethod;

        }
        public async Task Subscribe()
        {
            _consumerGateway.StartAsync(new CancellationToken(), "Gateway");
        }
        public async Task Sub(ICallbackSeparator.AuthenticationDelegate method)
        {
            onAuthentication += method;
        }
        public async Task Sub(ICallbackSeparator.RegistrationDelegate method)
        {
            onRegistration += method;
        }
        public async Task Sub(ICallbackSeparator.GetGamesDelegate method)
        {
            onGetGames += method;
        }
        public async Task Sub(ICallbackSeparator.AddToTableDelegate method)
        {
            onAddToTable += method;
        }
        public async Task Sub(ICallbackSeparator.RemoveFromTableDelegate method)
        {
            onRemoveFromTable += method;
        }
        public async Task Sub(ICallbackSeparator.TakeActionDelegate method)
        {
            onTakeAction += method;
        }

        public async Task CallbackMethod(GeneralQuery receivedData)
        {
            switch (receivedData.OperationType)
            {
                case "Authentication":
                    Authentication(receivedData.Authentication);
                    break;

                case "Registration":
                    Registration(receivedData.Registration);
                    break;

                case "GetGames":
                    GetGames(receivedData.GetGames);
                    break;

                case "AddToTable":
                    AddToTable(receivedData.AddToTable);
                    break;

                case "RemoveFromTable":
                    RemoveFromTable(receivedData.RemoveFromTable);
                    break;

                case "TakeAction":
                    TakeAction(receivedData.PlayerAction);
                    break;
            }
        }

        async Task Authentication(AuthenticateQuery separatedData)
        {
            try
            {
                onAuthentication.Invoke(separatedData);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }
        async Task Registration(RegistrationQuery separatedData)
        {
            try
            {
                onRegistration.Invoke(separatedData);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }
        async Task GetGames(GetGamesQuery separatedData)
        {
            try
            {
                onGetGames.Invoke(separatedData);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }
        async Task AddToTable(AddToTableQuery separatedData)
        {
            try
            {
                onAddToTable.Invoke(separatedData);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }
        async Task RemoveFromTable(RemoveFromTableQuery separatedData)
        {
            try
            {
                onRemoveFromTable.Invoke(separatedData);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }
        async Task TakeAction(PlayerActionQuery separatedData)
        {
            try
            {
                onTakeAction.Invoke(separatedData);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }
    }
}
