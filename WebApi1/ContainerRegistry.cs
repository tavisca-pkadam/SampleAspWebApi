using WebApi1.Services;
using StructureMap;
using WebApi1.Data;

namespace WebApi1
{
    public class ContainerRegistry : Registry
    {
        public ContainerRegistry()
        {
            For<IService>().Use<UserService>();
            For<IData>().Use<UserData>();
        }
    }
}