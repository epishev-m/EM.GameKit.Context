using EM.Foundation;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class StateMachineDiContainerExtensions
{
	public static IDiContainer BindStateMachine(this IDiContainer container,
		LifeTime lifeTime)
	{
		container.Bind<IGameStateFactory>()
			.SetLifeTime(lifeTime)
			.To<GameStateFactory>()
			.AsSingle();

		container.Bind<IGameStateMachine>()
			.SetLifeTime(lifeTime)
			.To<GameStateMachine>()
			.AsSingle();

		return container;
	}
}

}