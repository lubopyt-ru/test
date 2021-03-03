using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_3._1_Test
{
    public class Repository
    {
        public IEnumerable<Customers> GetBirthdayPeoples(DateTime date)
        {
            var ctx = new StoreContext();
            IEnumerable<Customers> retval = null;
            try {
                retval = ctx.Customers.Where(c => c.BirthDay == date).ToList();
            }
            catch {
                retval = null;
            }
            return retval;

        }


        public IEnumerable<Customers> GetLastBuyers(int days)
        {
            var ctx = new StoreContext();
            IEnumerable<Customers> retval = null;

            var delta = DateTime.Now.AddDays(-days);

            try
            {
                retval = ctx.Customers.Where(c => c.Registration >= delta).ToList();
            }
            catch
            {
                retval = null;
            }
            return retval;

        }

 public List<Category> GetCategories(Guid id)
        {
            var ctx = new StoreContext();

            List<string> cat = new List<string>();
            Category retval = new Category();
            List<Category> catList = new List<Category>();

            try
            {
                var purchases = ctx.Purchases.Where(p => p.CustomerId == id).ToList();
                var count = purchases.Count();
            foreach (Purchases p in purchases)
                {
                    var c = new Category();
                    var find = ctx.Products.Find(p.ProductId);

                    if (find != null) {
                        var category = find.Category;
                    cat.Add(category);
                    }
                   
                    
                  
                }

                var clearList = cat.Distinct().ToList();


                foreach (string c in clearList) 
                {
                    var maches = cat.Where(m => m.Contains(c)).Count();
                    var category = new Category();
                    category.category = c;
                    category.count = maches;
                    catList.Add(category);
                }

                    
                    }
            catch
            {
                catList = null;
            }
            return catList;

        }

    }
}
