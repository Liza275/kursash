using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class ClientLogic
    {
        private readonly IClientStorage _clientStorage;

        public ClientLogic(IClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClientViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            var client = _clientStorage.GetElement(new ClientBindingModel
            {
                Login = model.Login
            });
            if (client != null && client.Id != model.Id)
            {
                throw new Exception("Уже есть клиент с таким логином");
            }
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }

        public void Delete(ClientBindingModel model)
        {
            var client = _clientStorage.GetElement(new ClientBindingModel
            {
                Id = model.Id
            });
            if (client == null)
            {
                throw new Exception("Клиент не найден");
            }
            _clientStorage.Delete(model);
        }

        public ClientViewModel Login(ClientBindingModel model)
        {
            var client = _clientStorage.GetElement(
                new ClientBindingModel
                {
                    Login = model.Login
                });

            if (client == null || !client.Password.Equals(model.Password))
            {
                throw new Exception("Клиент не найден");
            }
            return client;
        }
    }
}
