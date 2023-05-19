﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class PeopleData : IPeopleData
	{
		private readonly ISqlDataAccess _db;

		public PeopleData(ISqlDataAccess db)
		{
			_db = db;
		}

		public Task<List<PersonModel>> GetPeople()
		{
			string sql = "select * from dbo.People";

			return _db.LoadData<PersonModel, dynamic>(sql, new { });
		}

		public Task InsertPerson(PersonModel person)
		{
			string sql = @"insert into dbo.People (FirstName, LastName, EmailAddress)
							values (@FirstName, @LastName, @EmailAddress);";

			return _db.SaveData(sql, person);
		}
	}
}
