using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelDTO
{
    public  class SignResponseModel
    {
        public bool Success { get; set; }

        public IdentityUser User { get; set; }
    }
}
