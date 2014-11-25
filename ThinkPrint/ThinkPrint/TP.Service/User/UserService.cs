using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.EntityFramework.Models;
using TP.Repository;
using Webdiyer.WebControls.Mvc;


namespace TP.Service.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository,IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;

        }

        public AUT_User ValidateUser(string userNameOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(userNameOrEmail) || string.IsNullOrWhiteSpace(password))
                return null;
            return _userRepository.GetEntiny(u => u.Name == userNameOrEmail && u.Password == password);
        }

        public AUT_User GetUserByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;

            return _userRepository.GetEntiny(u => u.Name == userName);
        }

        public void InsertUser(AUT_User user)
        {
            if (user == null)
                throw new ArgumentNullException("Insert SYS_Module entity is Null");

            try
            {
                _userRepository.Add(user);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateUser(AUT_User user)
        {
            if (user == null)
                throw new ArgumentNullException("Update User entity is Null");
            try
            {

                _userRepository.Update(user);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteUser(AUT_User user)
        {
            if (user == null)
                throw new ArgumentNullException("Delete AUT_User entity is Null");
            try
            {
                user.IsDelete = true;
                UpdateUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public PagedList<AUT_User> GetUserList(int pageIndex, int pageSize, string searchKey = null)
        {
            var query = _userRepository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(u => u.Name.Contains(searchKey));
            }

            query = query.OrderByDescending(u => u.ModifiedDate);

            PagedList<AUT_User> userList = query.ToPagedList(pageIndex, pageSize);
            return userList;
        }


        public AUT_User GetUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }


        public AUT_User CheckExistUserByName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;
            var query = _userRepository.Filter(u => u.IsDelete == false && u.Name == userName).FirstOrDefault();
            return query;
        }

        public AUT_User CheckExistUserByName(int id, string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;
            var query = _userRepository.Filter(u => u.IsDelete == false && u.UserId != id && u.Name == userName).FirstOrDefault();
            return query; 
        }


        public void InsertUserRole(AUT_UserRole userRole)
        {
            if (userRole == null)
                throw new ArgumentNullException("Insert AUT_UserRole entity is Null");

            try
            {
                _userRoleRepository.Add(userRole);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateUserRole(AUT_UserRole userRole)
        {
            if (userRole == null)
                throw new ArgumentNullException("Update AUT_UserRole entity is Null");
            try
            {

                _userRoleRepository.Update(userRole);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RemoveUserRole(AUT_UserRole userRole)
        {
            if (userRole == null)
                throw new ArgumentNullException("Update AUT_UserRole entity is Null");
            try
            {

                _userRoleRepository.Delete(userRole);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public AUT_UserRole GetUserRole(int userId, int roleId)
        {
            return _userRoleRepository.GetEntiny(d => d.UserId == userId && d.RoleId == roleId);
        }
    }
}
