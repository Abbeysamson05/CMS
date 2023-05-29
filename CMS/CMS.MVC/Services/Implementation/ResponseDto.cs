<<<<<<< HEAD

namespace CMS.DATA.DTO

=======

﻿namespace CMS.DATA.DTO
=======
﻿using CMS.DATA.DTO;

namespace CMS.MVC.Services.Implementation
>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string DisplayMessage { get; set; }
<<<<<<< HEAD

        public T Result { get; set; }
        public List<string> ErrorMessages { get; set; }


=======
        public T Result { get; set; }
        public List<string> ErrorMessages { get; set; }
        public ResetPassword Result { get; set; }
        public object ErrorMessages { get; set; }
>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
    }
}