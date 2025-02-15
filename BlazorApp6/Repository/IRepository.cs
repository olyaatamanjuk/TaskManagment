namespace BlazorApp6.Repository;


    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);              // Отримати запис за ID
        Task<IEnumerable<T>> GetAllAsync();        // Отримати всі записи
        Task AddAsync(T entity);                   // Додати запис
        void Update(T entity);                     // Оновити запис
        void Delete(T entity);                     // Видалити запис
    }
