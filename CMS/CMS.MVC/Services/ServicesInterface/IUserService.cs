<<<<<<< HEAD

=======
>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
﻿using CMS.DATA.DTO;
using CMS.DATA.Enum;
using CMS.MVC.Services.Implementation;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IUserService
    {

       public Task<ResponseDto<bool>> DeleteUser(string userId);
     public Task<ResponseDto<bool>> SetActiveStatus(string userId, bool status);
<<<<<<< HEAD

      public Task<bool> RequestPermission(string userId);
     public Task<bool> GrantPermission(string userId, Permissions claims);


    }
}
=======
>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
