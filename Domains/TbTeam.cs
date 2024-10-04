using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbTeam
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage ="من فضلك ادحل الاسم")]
        public string Name { get; set; } = null!;

        public string? Email { get; set; } 
        [Required(ErrorMessage = "من فضلك ادحل رقم الجوال")]
        [Phone (ErrorMessage = "من فضلك ادخل رقم الجوال بالشكل الصحيح ارقام فقط")]
        public string Phone { get; set; } = null!;
        public string Image  ="";
    }
}
