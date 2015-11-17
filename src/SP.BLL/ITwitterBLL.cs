using System.Collections.Generic;
using SP.Entities;

namespace SP.BLL
{
    public interface ITwitterBLL
    {
        IEnumerable<Tweet> Get();
    }
}
