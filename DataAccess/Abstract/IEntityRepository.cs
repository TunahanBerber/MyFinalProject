using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    //generic constraint
    //class : referans tip olabilir demek
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : newlenebilir diyoruz
    //Bu kurallar ile backendimiz gerçekten veri tabanı nesneleri ile çalışabilir hale geldi
    public interface IEntityRepository <T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T,bool>>filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
