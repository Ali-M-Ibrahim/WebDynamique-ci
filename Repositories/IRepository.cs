namespace USCJCI.Repositories
{
    public interface IRepository<T> where T : class    
    {
        // SELECT ALL
        Task<List<T>> getAllRows();
        // SELECT BY ID
        Task<T> GetRowById(int id);

        // TO CREATE
        Task AddRow(T obj);
        // TO UPDATE
        Task UpdateRow(T obj);

        //TO DELETE
        Task DeleteRow(int id);






    }
}
