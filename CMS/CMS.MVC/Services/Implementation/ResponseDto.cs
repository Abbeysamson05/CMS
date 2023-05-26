
﻿namespace CMS.DATA.DTO
=======
﻿using CMS.DATA.DTO;

namespace CMS.MVC.Services.Implementation
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string DisplayMessage { get; set; }
        public T Result { get; set; }
        public List<string> ErrorMessages { get; set; }
        public ResetPassword Result { get; set; }
        public object ErrorMessages { get; set; }
    }
}