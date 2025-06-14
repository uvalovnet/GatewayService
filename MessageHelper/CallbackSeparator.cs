using Entities;
using Entities.Interfaces;
using Entities.Requests;
using Entities.Responses;
using Entities.Responses.Account;
using Entities.Responses.Game;
using Microsoft.Extensions.Logging;
using static Entities.Interfaces.ICallbackSeparator;

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
            //_consumerGateway.onMessage += CallbackMethod;

        }
        public async Task Subscribe()
        {
            new Task(async () => await _consumerGateway.StartAsync<Task, RegistrationResponse>(Topics.UserRegistrationResponse.ToString(), Registration)).Start();
            //_consumerGateway.StartAsync<Task, AuthenticateResponse>(Topics.UserRegistrationResponse.ToString(), Authentication);
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

        //public async Task CallbackMethod(GeneralResponse receivedData)
        //{
        //    switch (receivedData.OperationType)
        //    {
        //        case OperationTypes.Auth:
        //            Authentication(receivedData.Authentication);
        //            break;

        //        case OperationTypes.Reg:
        //            Registration(receivedData.Registration);
        //            break;

        //        case OperationTypes.GetGames:
        //            GetGames(receivedData.GetGames);
        //            break;

        //        case OperationTypes.AddToTable:
        //            AddToTable(receivedData.AddToTable);
        //            break;

        //        case OperationTypes.RemoveFromTable:
        //            RemoveFromTable(receivedData.RemoveFromTable);
        //            break;

        //        case OperationTypes.TakeAction:
        //            TakeAction(receivedData.PlayerAction);
        //            break;
        //    }
        //}

        async Task Authentication(AuthenticateResponse separatedData)
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
        async Task Registration(RegistrationResponse separatedData)
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
        async Task GetGames(GetGamesResponse separatedData)
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
        async Task AddToTable(AddToTableResponse separatedData)
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
        async Task RemoveFromTable(RemoveFromTableResponse separatedData)
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
        async Task TakeAction(PlayerActionResponse separatedData)
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
