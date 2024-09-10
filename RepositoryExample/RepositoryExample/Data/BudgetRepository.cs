using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        public List<Budget> GetAll()
        {
            throw new NotImplementedException();
        }

        public Budget GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Budget budget)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();
                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente",  budget.Client);
                cmd.Parameters.AddWithValue("@vigencia", budget.Expoiration);
                SqlParameter param = new SqlParameter("@id", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int budgetId = Convert.ToInt32(param.Value);
                int detailId = 1;
                foreach (DetailBudget detail in budget.Details)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetail.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@detalle", detailId);
                    cmdDetail.Parameters.AddWithValue("@producto", detail.Product.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.Price);
                    cmdDetail.Parameters.AddWithValue("@subtotal", detail.SubTotal());
                    cmdDetail.ExecuteNonQuery();
                    detailId++;
                }

                t.Commit();

            }
            catch (Exception ex) {
                if (t != null)
                {
                    t.Rollback();
                    return false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
