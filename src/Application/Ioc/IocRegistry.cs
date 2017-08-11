using StructureMap;

namespace Mmu.Ddws.Application.Ioc
{
    public class IocRegistry : Registry
    {
        public IocRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly(); // Scan this assembly
                    scan.WithDefaultConventions();
                });
        }
    }
}