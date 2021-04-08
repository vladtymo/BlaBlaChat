using Dal;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
   public class UserService 
   {
        IUnitOfWork _unitOfWork;


        /// methods for getting user info
        public User GetUserInfo (int Id)
        {
            return _unitOfWork.UsertRepository.GetById(Id);
        }

        public User GetByEmail(string email)
        {
            return _unitOfWork.UsertRepository.Get(x => x.Email == email).FirstOrDefault();
        }

        public User GetFullInfoUser(string email)
        {
            return _unitOfWork.UsertRepository.Get(x => x.Email == email, includeProperties: "Chats,MyContacts,Messages").FirstOrDefault();
        }
        public User GetChatsUser(string email)
        {
            return _unitOfWork.UsertRepository.Get(x => x.Email == email, includeProperties: "Chats").FirstOrDefault();
        }
        public User GetMyContactsUser(string email)
        {
            return _unitOfWork.UsertRepository.Get(x => x.Email == email, includeProperties: "MyContacts").FirstOrDefault();
        }
    
        public User GetMessagesUser(string email)
        {
            return _unitOfWork.UsertRepository.Get(x => x.Email == email, includeProperties: "Messages").FirstOrDefault();
        }

        public bool IsExistNickName(string NickName)
        {
            return _unitOfWork.UsertRepository.Get(x => x.Nickname == NickName).FirstOrDefault() != null;
        }
            
        /// methods for editing user info
        public void ChangeNickNameUser(int IdUser,string NewNickName)
        {

            if (!IsExistNickName(NewNickName))
            {
               var user = _unitOfWork.UsertRepository.GetById(IdUser);
               user.Nickname = NewNickName;
               _unitOfWork.UsertRepository.Update(user);
               _unitOfWork.Save();
                
            }


            
        }

        public void ChangeNameUser(int IdUser, string NewName)
        {
            var user = _unitOfWork.UsertRepository.GetById(IdUser);
            user.Name = NewName;
            _unitOfWork.UsertRepository.Update(user);
            _unitOfWork.Save();
        }
        public void ChangeSurnameUser(int IdUser, string NewSurname)
        {
            var user = _unitOfWork.UsertRepository.GetById(IdUser);
            user.Surname = NewSurname;
            _unitOfWork.UsertRepository.Update(user);
            _unitOfWork.Save();
        }
        public void ChangeAvatarLinkUser(int IdUser, string NewAvatrLink)
        {
            var user = _unitOfWork.UsertRepository.GetById(IdUser);
            user.AvatarLink = NewAvatrLink;
            _unitOfWork.UsertRepository.Update(user);
            _unitOfWork.Save();
        }


       /* public void ChangeBioUser(int IdUser, string NewBio)
         {
            var user = _unitOfWork.UsertRepository.GetById(IdUser);
            user.Bio = NewBio;
            _unitOfWork.UsertRepository.Update(user);
            _unitOfWork.Save();
        }*/





    }
}
