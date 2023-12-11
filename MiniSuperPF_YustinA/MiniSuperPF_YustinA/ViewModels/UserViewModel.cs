using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MiniSuperPF_YustinA.Models;

namespace MiniSuperPF_YustinA.ViewModels
{

    public class UserViewModel : BaseViewModel

    {
        public Email MyEmail { get; set; }
        public RecoveryCode MyRecoveryCode { get; set; }
        public Service MyService { get; set; }

        public UserRole MyUserRole { get; set; }
        public UserStatus MyUserStatus { get; set; }
        public User MyUser { get; set; }
        public UserDTO MyUserDTO { get; set; }








        public UserViewModel()
        {
            MyUserRole = new UserRole();
            MyUserStatus = new UserStatus();
            MyUser = new User();
            MyUserDTO = new UserDTO();
            MyEmail = new Email();
            MyRecoveryCode = new RecoveryCode();
            MyService = new Service();

        }

        public async Task<UserDTO> GetUserData(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO user = new UserDTO();

                user = await MyUserDTO.GetUserData(pEmail);

                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<ObservableCollection<Service>> GetServiceList(int pUserID)
        {

            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Service> List = new ObservableCollection<Service>();

                MyService.UserId = pUserID;

                List = await MyService.GetServiceListByUser();


                if (List == null)
                {
                    return null;
                }
                else
                {
                    return List;
                }

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.LoginPassword = pPassword;

                bool R = await MyUser.ValidateLogin();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<List<UserRole>> GetUserRoles()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>();


                roles = await MyUserRole.GetAllUserRoleList();
                if (roles == null)
                {
                    return null;
                }
                else
                {
                    return roles;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddUser(string pEmail,
            string pName,
            string pIDNumber,
            string pPhoneNumber,
            string pAddress,
            string pPassword,
            int pUserRole,
            int pUserStatus = 3)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Name = pName;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.Address = pAddress;
                MyUser.CardId = pIDNumber;
                MyUser.LoginPassword = pPassword;


                MyUser.UserRoleId = pUserRole;
                MyUser.UserStatusId = pUserStatus;


                bool R = await MyUser.AddUser();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }




        }


        public async Task<bool> AddRecoveryCode(string pEmail)

        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyRecoveryCode.Email = pEmail;

                string RecoveryCode = "ABC123*";


                MyRecoveryCode.RecoveryCode1 = RecoveryCode;
                MyRecoveryCode.RecoveryCodeId = 0;

                bool R = await MyRecoveryCode.AddRecoveryCode();

                if (R)
                {
                    MyEmail.SendTo = pEmail;

                    MyEmail.Subject = "MiniSuperPF Código de recuperación de contraseña";

                    MyEmail.Message = string.Format("Su codigo de recuperacion es: {0}", RecoveryCode);

                    R = MyEmail.SendEmail();
                }


                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }




        }

        public async Task<bool> RecoveryCodeValidation(string pEmail, string pRecoveryCode)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyRecoveryCode.Email = pEmail;
                MyRecoveryCode.RecoveryCode1 = pRecoveryCode;


                bool R = await MyRecoveryCode.ValidateRecoveryCode();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


        public async Task<bool> UpdateUser(string pUser)

        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUserDTO = pUser;


                bool R = await MyUserDTO.UpdateUser();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }




        }

        internal async Task<bool> UpdateUser(UserDTO pUser)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUserDTO = pUser;


                bool R = await MyUserDTO.UpdateUser();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}












