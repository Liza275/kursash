using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using SchoolDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDAL.Implement
{
    public class ClientStorage : IClientStorage
    {
        private Client CreateModel(ClientBindingModel model, Client client, SchoolDataBase schoolDataBase)
        {
            User user = new User
            {
                Name = model.ClientName,
                Surname = model.ClientSurname,
                Patronymic = model.ClientPatronymic,
                DateBirth = model.DateBirth,
                Login = model.Login,
                Password = model.Password,
            };

            schoolDataBase.Users.Add(user);
            schoolDataBase.SaveChanges();
            client.UserId = user.Id;
            return client;
        }

        private ClientViewModel CreateViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
               ClientName = client.User.Name,
               ClientSurname = client.User.Surname,
               ClientPatronymic = client.User.Patronymic,
               DateBirth = client.User.DateBirth,
                Login = client.User.Login,
                Password = client.User.Password
            };
        }

        public List<ClientViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Clients
                    .Include(rec => rec.User)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var schoolDataBase = new SchoolDataBase())
            {
                var client = schoolDataBase.Clients
                   .Include(rec => rec.User)
                   .FirstOrDefault(rec => rec.User.Login == model.Login ||
                   rec.UserId == model.Id);

                return client != null ? CreateViewModel(client) : null;
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (var schoolDataBase = new SchoolDataBase())
            {
                schoolDataBase.Clients.Add(CreateModel(model, new Client(), schoolDataBase));
                schoolDataBase.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClientBindingModel model)
        {
            throw new NotImplementedException();
        }
        
    }
}
