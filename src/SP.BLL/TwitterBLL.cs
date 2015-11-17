using System.Collections.Generic;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class TwitterBLL: ITwitterBLL
    {
        private readonly ITwitterResourceAccess _twitterResourceAccess;
        public TwitterBLL(ITwitterResourceAccess twitterResourceAccess)
        {
            _twitterResourceAccess = twitterResourceAccess;
        }


        public IEnumerable<Tweet> Get()
        {
            return _twitterResourceAccess.Get();
        }
    }
}
