using AutoMapper;
using BookingWebApp.BusinessLogic.BusinessLogicClasses;
using BookingWebApp.BusinessLogic.Interfaces;
using BookingWebApp.BusinessLogic.Models;
using BookingWebApp.DataAccess.Interfaces;

namespace BookingWebApp.BusinessLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public void CreateUser(Client user)
        {
            user.PasswordHash = HashProvider.GetHash(user.PasswordHash!);
            _clientRepository.Create(_mapper.Map<DataAccess.Entities.Client>(user));
            _clientRepository.Save();
        }

        public void UpdateUser(Client user)
        {
            _clientRepository.Update(_mapper.Map<DataAccess.Entities.Client>(user));
            _clientRepository.Save();
        }

        public Client? AuthenticateUser(string email, string password)
        {
            DataAccess.Entities.Client clientEntity = _clientRepository.Find(client => client.EMail.Equals(email));
            if (clientEntity == null)
                return null;
            if (clientEntity.PasswordHash == HashProvider.GetHash(password))
                return _mapper.Map<Client>(clientEntity);
            else
                return null;
        }

        public void ChangePassword(Client client, string newPassword)
        {
            client.PasswordHash = HashProvider.GetHash(newPassword);
            _clientRepository.Update(_mapper.Map<DataAccess.Entities.Client>(client));
            _clientRepository.Save();
        }

        public bool IsEmailUnique(string email)
        {
            return _clientRepository.Find(client => client.EMail == email) == null;
        }
    }
}
