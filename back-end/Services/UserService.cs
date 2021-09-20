using KudosShop.Models;
using KudosShop.Repository;
using KudosShop.Repository.Interfaces;
using KudosShop.Services.Interfaces;
using System;
using System.Collections.Generic;


namespace KudosShop.Services
{
    public class UserService : IUserService
    {

        private readonly IKudosRepository _kudosRepository;

        public UserService(IKudosRepository kudosRepository)
        {
            _kudosRepository = kudosRepository ?? throw new ArgumentNullException(nameof(kudosRepository));
        }

        public Kudos CheckUserBalance(int id)
        {
            return _kudosRepository.CheckUserBalance(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _kudosRepository.GetAllUsers();
        }

    }
}
