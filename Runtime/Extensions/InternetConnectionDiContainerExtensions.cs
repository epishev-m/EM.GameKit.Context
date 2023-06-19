namespace EM.GameKit.Context
{

using IoC;
using Foundation;

public static class InternetConnectionDiContainerExtensions
{
	public static IDiContainer BindInternetConnection<TConfigProvider>(this IDiContainer container,
		LifeTime lifeTime)
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