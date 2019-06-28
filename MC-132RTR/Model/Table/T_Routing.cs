using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Table
{
    class T_Routing
    {
        private static T_Routing Instance = null;

        public static T_Routing GetInstance()
        {
            if (Instance == null)
                Instance = new T_Routing();

            return Instance;
        }
    }
}
