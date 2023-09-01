using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Core.dto.Authentication
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="kanishka",Password="kanishka@1234",Role="Admin"},
                    new UserModel(){ Username="Riya",Password="Riya@234",Role="Developer"}
            };
    }
}
