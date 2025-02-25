﻿using System;
using Xrun.DataAccess.UserInformation.Entity;

namespace Xrun.DataAccess.UserInformation.Interface
{
	public interface IUserInformationDataAccess
	{
        Task<UserInformationEntity> GetUserByNHINumberAsync(string nhiNumber);

        Task<List<UserInformationEntity>> GetAllUserInformationAsync();

        Task InsertUserInformationAsync(UserInformationEntity userInformationEntity);       

    }
}


