using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet 
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDıssposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext()) //C# a ait güzel bir özellik Garbage Collector bunu anında işi bitince atar yani sen bu hareketi yaparsan daha performanslı bir ürün geliştirmiş olursun
            {
                var addedEntity = context.Entry(entity);  //Burada eşleştir dedik ama eşleştirme yapamıyorsa gidip yenisini ekliyor
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); //statate = durum
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context =new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null   //Filtre Null'mı
                    ? context.Set<Product>().ToList()  //Nullsa bu çalışır
                    : context.Set<Product>().Where(filter).ToList(); //Değilse bu
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
