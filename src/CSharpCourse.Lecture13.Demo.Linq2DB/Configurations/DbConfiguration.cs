using LinqToDB.Configuration;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.Configurations
{
    public class DbConfiguration : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }
}