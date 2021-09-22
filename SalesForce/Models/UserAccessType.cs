namespace SalesForce.Models
{
    public partial struct UserAccessType
    {
        public const string SysAdmin = "Sys Admin";
        public const string Admin = "Admin";
        public const string ReadWrite = "Read Write";
        public const string ReadOnly = "Read Only";
        public const string Guest = "Guest";
    }
}