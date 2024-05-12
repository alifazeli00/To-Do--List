using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFundException: Exception
    {                //koda entiti peydanashee  , kodma va ba kodom klid
       public NotFundException(string entityname,object key):
           base($"entity{entityname}with key {key} was not found.")
        {

        }
    }
}
