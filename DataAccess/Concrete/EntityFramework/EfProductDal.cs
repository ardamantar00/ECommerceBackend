using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                var adddedEntity = contex.Entry(entity); //veri kaynağı ile ilişkilendir
                adddedEntity.State = EntityState.Added; //ekleme işlemi yapılacak
                contex.SaveChanges(); //işlemi kaydet

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                var deletedEntity = contex.Entry(entity); 
                deletedEntity.State = EntityState.Deleted; 
                contex.SaveChanges(); 

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context  = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context  =new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() :
                    context.Set<Product>().Where(filter).ToList();    
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                var updatedEntity = contex.Entry(entity); 
                updatedEntity.State = EntityState.Modified; 
                contex.SaveChanges(); 

            }
        }
    }
}
