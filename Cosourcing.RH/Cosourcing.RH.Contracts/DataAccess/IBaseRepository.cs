﻿using System;
using Cosourcing.RH.Domain;

namespace Cosourcing.RH.Contracts.DataAccess
{
	public interface IBaseRepository
	{
		public Task<int> Commit();

		public void Add<T>(T obj) where T : BaseModel;

        public void Delete<T>(Guid id) where T : BaseModel;

        public ValueTask<T?> GetById<T>(Guid id) where T : BaseModel;
    }
}

