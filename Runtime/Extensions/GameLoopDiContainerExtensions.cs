namespace EM.GameKit.Context
{

using IoC;
using Foundation;

public static class GameLoopDiContainerExtensions
{
	public static IDiContainer BindGameLoop(this IDiContainer container,
		LifeTime  lifeTime)
	{
		container.Bind<IGameLoopObjectFactory>()
			.SetLifeTime(lifeTime)
			.To<GameLoopObjectFactory>()
			.AsSingle();

		container.Bind<IGameLoop>()
			.SetLifeTime(lifeTime)
			.To<GameLoop>()
			.AsSingle();

		return container;
	}

	public static IDiContainer ConfigureGameLoop(this IDiContainer container)
	{
		container.Resolve<IGameLoop>()
			.CreateGameLoopComponent();

		return container;
	}

	public static IDiContainer ReleaseGameLoop(this IDiContainer container)
	{
		container.Resolve<IGameLoop>()
			.Unbind(LifeTime.Local);

		return container;
	}
}

}