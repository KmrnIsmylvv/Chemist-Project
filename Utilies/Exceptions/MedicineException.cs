using System;
using System.Collections.Generic;
using System.Text;

namespace Utilies.Exceptions
{

    public class MedicineException:Exception
    {
        public MedicineException(string message):base(message)
        {
            
        }
    }
}
