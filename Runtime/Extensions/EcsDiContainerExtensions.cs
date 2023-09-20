using EM.Foundation;
using EM.GameKit.Ecs;
using EM.IoC;
using Leopotam.EcsLite;

namespace EM.GameKit.Context
{

public static class EcsDiContainerExtensions
{
	public static IDiContainer BindEcs(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
	{
		container.Bind<EcsWorld>()
			.SetLifeTime(lifeTime)
			.To<EcsWorld>()
			.AsSingle();

		container.Bind<DebugEcsRunner>()
			.SetLifeTime(lifeTime)
			.To<DebugEcsRunner>()
			.AsSingle();

		return container;
	}

	public static IDiContainer ConfigureEcsDebug(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
	{
		var gameLoop = container.Resolve<IGameLoop>();

		gameLoop.Bind(typeof(DebugEcsRunner))
			.SetLifeTime(lifeTime)
			.To<DebugEcsRunner>();

		gameLoop.Run(typeof(DebugEcsRunner));

		return container;
	}
}

}