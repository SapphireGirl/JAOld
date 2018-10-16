using System;

namespace JA.MS.Data.SQL
{
    public interface IRepository
    {


    }

    public class IEntity
    {
        public int Id;
    }

    public interface IRepository<T> where T : IEntity
    {

    }
}
