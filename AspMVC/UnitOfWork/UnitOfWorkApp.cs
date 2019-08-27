using AspMVC.Data;
using AspMVC.Models;
using AspMVC.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMVC.UnitOfWork
{
    public class UnitOfWorkApp : DbContext
    {
        ContextApp context = new ContextApp();
        Repository<Product> productRepository;

        public Repository<Product> ProductRepository
        {
            get
            {
                //o singleton valida se já foi instanciada 1 vez
                if(productRepository == null)
                {
                    productRepository = new Repository<Product>(context);
                }
                return productRepository;
            }

        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
