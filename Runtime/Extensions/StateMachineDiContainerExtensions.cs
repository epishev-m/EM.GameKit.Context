namespace EM.GameKit.Context
{

using IoC;

public static class StateMachineDiContainerExtensions
{
	public static IDiContainer BindStateMachine(this IDiContainer container)
	{
		container.Bind<IGameStateFactory>()
			.InGlobal()
			.To<GameStateFactory>()
			.AsSingle();

		container.Bind<IGameStateMachine>()
			.InGlobal()
			.To<GameStateMachine>()
			.AsSingle();

		return container;
	}
}

}