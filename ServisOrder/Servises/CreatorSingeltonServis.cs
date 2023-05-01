using Microsoft.Extensions.DependencyInjection;
using ServisOrder.Interface;
using ServisOrder.Model;

namespace ServisOrder.Servises
{
    public class CreatorSingeltonServis
    {
        private readonly IServiceScopeFactory _factory;

        public CreatorSingeltonServis(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public async void CreateUserCashe(int id)
        {
            using (var scope = _factory.CreateScope())
            {
                var servis = scope.ServiceProvider.GetService<ICasheRepository<UserCashe>>();

                await servis.CreateEnity(id);
            }
        }
    }
}
