using System.ComponentModel;

namespace Movie.Login.API.Enums
{
    public enum RolesEnums
    {
        [Description("User")]
        User = 0,
        
        [Description("Admin")]
        Admin = 1,
        
        [Description("Employee")]
        Employee=2,
        
        none=3,
        
    }
}