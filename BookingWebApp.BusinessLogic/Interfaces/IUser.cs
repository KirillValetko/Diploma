using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Interfaces
{
    public interface IUser<T> where T : class
    {
        void CreateUser(T user);
        void UpdateUser(T user);
        T? AuthenticateUser(string email, string password);
        void ChangePassword(T user, string newPassword);
        bool IsEmailUnique(string email);
    }
}
