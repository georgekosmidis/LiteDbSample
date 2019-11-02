using LiteDB;

namespace LiteDbSample.LiteDb
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}