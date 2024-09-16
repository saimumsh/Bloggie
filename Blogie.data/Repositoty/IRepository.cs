using Blogie.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogie.data.Repositoty
{
    public interface IRepository<T> where T : class
	{
		List<T> GetAll();
		T GetById(int id);
		void Delete(T entity);
		void Update(T entity);
		void DeleteAll(List<T> entity);
		void Add(T entity);
	}
}
