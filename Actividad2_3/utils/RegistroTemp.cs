using Actividad2_3.Model;
using System.Linq;

namespace Actividad2_3.utils
{
    public class RegistroTemp
    {
        private static RegistroTemp _instance;
        private List<Temperatura> _temp;

        private RegistroTemp()
        {
            _temp = new List<Temperatura>();
        }

        public static RegistroTemp Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RegistroTemp();
                }
                return _instance;
            }
        }
        public void AddTemp(Temperatura temp)
        {
            _temp.Add(temp);
        }
        public List<Temperatura> GetTemp()
        {
            return _temp;
        }
        public List<Temperatura> GetTemp(int iot)
        {
            return _temp.Where(temperatura => temperatura.IOT == iot).ToList();
        }
    }
}
