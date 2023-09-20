using EM.Foundation;
using EM.GameKit.UI;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class SplashScreenDiContainerExtensions
{
	public static IDiContainer BindSplashScreen<TConfigProvider>(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Local)
		where TConfigProvider : class, ISplashScreenConfigProvider
	{
		container.Bind<SplashScreenModel>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenModel>()
			.AsSingle();

		container.Bind<SplashScreenRouter>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenRouter>()
			.AsSingle();

		container.Bind<SplashScreenViewModel>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenViewModel>();

		container.Bind<SplashScreen>()
			.SetLifeTime(lifeTime)
			.To<SplashScreen>()
			.AsSingle();

		container.Bind<ISplashScreenConfigProvider>()
			.InLocal()
			.To<TConfigProvider>()
			.AsSingle();

		return container;
	}
}

}