namespace Mmu.Ddws.Common.ApplicationSettings.Models
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";

        public MongoDbSettings MongoDbSettings { get; set; }
    }
}