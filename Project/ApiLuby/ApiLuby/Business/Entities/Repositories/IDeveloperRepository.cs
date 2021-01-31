namespace ApiLuby.Business.Entities.Repositories
{
   public interface IDeveloperRepository
    {
        void Add(Developer developer);
        void Commit();
        Developer GetDeveloper(string login);
    }
}
