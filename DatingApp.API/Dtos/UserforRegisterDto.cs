using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserforRegisterDto
    {
        //lézem
        [Required]
        public string Username { get; set; } 
        [Required] 
        //nombre de charactre avec max 8 ch et min 4
        [StringLength(8, MinimumLength=4 , ErrorMessage="zid thabet mli7 :p ")]  
        public string Password { get; set; }
    }
}