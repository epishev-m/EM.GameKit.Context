using EM.Foundation;
using EM.GameKit.UI;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class CheatsDiContainerExtensions
{
	public static IDiContainer BindCheats(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
	{
		container.Bind<ICheatBinder>()
			.SetLifeTime(lifeTime)
			.To<CheatBinder>()
			.AsSingle();

		container.Bind<CheatsModel>()
			.SetLifeTime(lifeTime)
			.To<CheatsModel>()
			.AsSingle();

		container.Bind<Cheats>()
			.SetLifeTime(lifeTime)
			.To<Cheats>()
			.AsSingle();

		container.Bind<CheatTest>()
			.SetLifeTime(lifeTime)
			.To<CheatTest>()
			.AsSingle();

		container.Bind<CheatsRouter>()
			.SetLifeTime(lifeTime)
			.To<CheatsRouter>()
			.AsSingle();

		container.Bind<CheatsViewModel>()
			.SetLifeTime(lifeTime)
			.To<CheatsViewModel>();
		
		container.Bind<ICheatFactory>()
			.SetLifeTime(lifeTime)
			.To<CheatFactory>()
			.AsSingle();

		return container;
	}

	public static IDiContainer ConfigureTestCheats(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Local)
	{
		container.Resolve<Cheats>()
			.Add<CheatTest>(lifeTime);

		return container;
	}
}

}