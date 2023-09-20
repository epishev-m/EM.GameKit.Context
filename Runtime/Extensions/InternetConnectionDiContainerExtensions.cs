using EM.Foundation;
using EM.GameKit.UI;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class InternetConnectionDiContainerExtensions
{
	public static IDiContainer BindInternetConnection<TConfigProvider>(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Local)
		where TConfigProvider : class, IInternetConnectionConfigProvider
	{
		container.Bind<InternetConnection>()
			.SetLifeTime(lifeTime)
			.To<InternetConnection>()
			.AsSingle();

		container.Bind<InternetConnectionRouter>()
			.SetLifeTime(lifeTime)
			.To<InternetConnectionRouter>()
			.AsSingle();

		container.Bind<InternetConnectionViewModel>()
			.SetLifeTime(lifeTime)
			.To<InternetConnectionViewModel>();

		container.Bind<IInternetConnectionConfigProvider>()
			.InLocal()
			.To<TConfigProvider>()
			.AsSingle();

		return container;
	}
}

}