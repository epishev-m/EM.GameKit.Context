namespace EM.GameKit.Context
{

using IoC;

public sealed class CheatFactory : ICheatFactory
{
	private readonly IDiContainer _diContainer;

	#region IGameLoopObjectFactory

	public ICheat Get<TCheat>()
		where TCheat : class, ICheat
	{
		return _diContainer.Resolve<TCheat>();
	}

	#endregion

	#region CheatFactory

	public CheatFactory(IDiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	#endregion
}

}