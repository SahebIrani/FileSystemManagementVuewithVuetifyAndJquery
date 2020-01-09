using System.Collections.Generic;

namespace Demo.SinjulMSBH.Repository
{
    public interface ISelectRepository<TModel>
    {
        TModel SelectOne(
            string id);

        IEnumerable<TModel> SelectMany(
            string id);
    }
}
