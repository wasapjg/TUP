using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Domain
{
    public class Budget
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public int Expoiration { get; set; }
        public List<DetailBudget> Details { get; set; }
        public Budget()
        {
            Details = new List<DetailBudget>();
        }
        public void Add(DetailBudget detail)
        {
            Details.Add(detail);
        }
        public void Delete(int index) {
            Details.RemoveAt(index);
        }
        public double Total()
        {
            double total = 0;
            foreach (DetailBudget detail in Details)
            {
                total += detail.SubTotal();
            }
            return total;
        }
    }
}
