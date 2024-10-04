using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "من فضلك ادخل الايميل")]
        [EmailAddress(ErrorMessage = "من فضلك ادخل الايميل بشكل صحيح")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور")]
        public string Password { get; set; } = null!;


    }
}
