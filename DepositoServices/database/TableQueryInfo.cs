using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServices.database
{
    public abstract class TableQueryInfo
    {
        
        abstract public string SelectString {
            get;
        }
        abstract public string InsertString {
            get;
        }

        abstract public int getId(object item);

        abstract public string duclicityString { get; }

        abstract public Dictionary<String, object> getDuplicityParameters(object obj);
    }
}
