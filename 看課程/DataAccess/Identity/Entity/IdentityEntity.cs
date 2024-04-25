namespace 看課程.DataAccess.Identity.Entity
{
    public class UserAccountToDB
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime RegistrationTime { get; set; } = DateTime.UtcNow.AddHours(8);  // 添加8小时以调整至台湾时间
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordToHash { get; set; }
        public string Salt { get; set; }
        public string CurrJTI { get; set; }
        public bool IsBlacklisted { get; set; } = false;

    }
}
