<<<<<<< HEAD
using CMS.DATA.DTO;
=======

﻿namespace CMS.MVC.Services.ServicesInterface
{
    public interface IAuthService
    {

﻿using CMS.DATA.DTO;
>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
using CMS.MVC.Services.Implementation;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IAuthService
    {
        Task<ResponseDto<ResetPassword>> ResetPasswords(ResetPassword resetPassword);
    }
}