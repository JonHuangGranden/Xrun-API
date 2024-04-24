namespace 看課程.DataAccess.Identity.Entity
{
    public class UserDataToDB
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordToHash { get; set; }
        public string Salt { get; set; }
        public string CurrJTI { get; set; } 
    }
}
