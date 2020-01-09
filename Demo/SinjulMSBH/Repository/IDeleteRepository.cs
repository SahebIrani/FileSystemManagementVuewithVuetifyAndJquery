namespace Demo.SinjulMSBH.Repository
{
	public interface IDeleteRepository<TModel>
	{
		bool Delete(string id);
	}
}
