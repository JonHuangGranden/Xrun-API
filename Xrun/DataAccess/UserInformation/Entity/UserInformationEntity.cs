using System;
namespace Xrun.DataAccess.UserInformation.Entity
{
	public class UserInformationEntity
	{
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string NHINumber { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegistrationTime { get; set; } = DateTime.UtcNow.AddHours(8);          
    }
}
