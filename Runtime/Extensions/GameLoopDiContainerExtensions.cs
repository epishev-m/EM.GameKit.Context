using EM.Foundation;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class GameLoopDiContainerExtensions
{
	public static IDiContainer BindGameLoop(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
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

	public static IDiContainer ReleaseGameLoop(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Local)
	{
		container.Resolve<IGameLoop>()
			.Unbind(lifeTime);

		return container;
	}
}

}