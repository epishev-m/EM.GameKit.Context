namespace EM.GameKit.Context
{

using Foundation;
using IoC;

public static class CheatsDiContainerExtensions
{
	public static IDiContainer BindCheats(this IDiContainer container,
		LifeTime lifeTime)
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
		LifeTime lifeTime)
	{
		container.Resolve<Cheats>()
			.Add<CheatTest>(lifeTime);

		return container;
	}
}

}