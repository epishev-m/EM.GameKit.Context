namespace EM.GameKit.Context
{

using IoC;
using Ecs;
using Foundation;
using Leopotam.EcsLite;

public static class EcsDiContainerExtensions
{
	public static IDiContainer BindEcs(this IDiContainer container,
		LifeTime lifeTime)
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
		LifeTime lifeTime)
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