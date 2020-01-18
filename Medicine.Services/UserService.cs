using Medicine.Common;
using Medicine.Entities;
using Medicine.Repository;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Services
{
    public class UserService
    {
        private UserUnitOfWork _userUnitOfWork;
        public UserService()
        {
            _userUnitOfWork = new UserUnitOfWork(new MedicineDbContext());
        }

        public bool Registration(User user)
        {
            try
            {
                var newUser = new User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = CustomCrypto.Hash(user.Password),
                    IsEmailVerified = true,
                    ActivationCode = Guid.NewGuid(),
                    UserRole = Role.NormalUser
                };
                _userUnitOfWork.UserRepository.Add(newUser);

                //Send Email to User
                //CustomEmail.SendVerificationLinkEmail(newUser.Email, newUser.ActivationCode.ToString(), DefaultValue.EmailTypes.VerifyAccount);

                var isSaved = _userUnitOfWork.Save();

                return isSaved;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _userUnitOfWork.UserRepository.GetAll().Where(x => x.UserRole != Role.Company && x.UserRole != Role.Pharmacy);
        }

        public User GetByEmail(string email)
        {
            return _userUnitOfWork.UserRepository.GetByEmail(email);
        }

        public bool EmailVerification(string code)
        {
            try
            {
                var user = _userUnitOfWork.UserRepository.Get(x => x.ActivationCode == new Guid(code)).FirstOrDefault();
                if (user != null)
                {
                    user.IsEmailVerified = true;
                    return _userUnitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool SendResetPasswordCode(string email)
        {
            try
            {
                var user = _userUnitOfWork.UserRepository.GetByEmail(email);
                if (user != null)
                {
                    user.ResetPasswordCode = Guid.NewGuid().ToString();
                    _userUnitOfWork.UserRepository.Update(user);

                    //CustomEmail.SendVerificationLinkEmail(user.Email, user.ResetPasswordCode, EmailType.ResetPassword);

                    return _userUnitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool IsResetPasswordCodeExist(string code)
        {
            try
            {
                var user = _userUnitOfWork.UserRepository.Get(x => x.ResetPasswordCode == code).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool ResetUserPassword(User user)
        {
            try
            {
                var existUser = _userUnitOfWork.UserRepository.Get(x => x.ResetPasswordCode == user.ResetPasswordCode).FirstOrDefault();
                if (existUser != null)
                {
                    existUser.Password = CustomCrypto.Hash(user.Password);
                    existUser.ResetPasswordCode = "";
                    _userUnitOfWork.UserRepository.Update(existUser);

                    return _userUnitOfWork.Save();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool IsEmailExist(string email)
        {
            return _userUnitOfWork.UserRepository.Get(x => x.Email.ToLower() == email.ToLower()).Any();
        }
    }
}
