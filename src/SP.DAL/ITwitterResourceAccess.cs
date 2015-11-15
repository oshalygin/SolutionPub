using System.Collections;
using System.Collections.Generic;
using SP.Entities;

namespace SP.DAL
{
    public interface ITwitterResourceAccess
    {
        IEnumerable<Tweet> Get();        
    }
}
