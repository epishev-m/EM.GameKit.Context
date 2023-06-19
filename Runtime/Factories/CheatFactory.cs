namespace EM.GameKit.Context
{

using Foundation;
using IoC;

public sealed class CheatFactory : ICheatFactory
{
	private readonly IDiContainer _diContainer;

	#region IGameLoopObjectFactory

	public Result<ICheat> Get<TCheat>()
		where TCheat : class, ICheat
	{
		var result = _diContainer.Resolve<TCheat>();

		if (result == null)
		{
			return new ErrorResult<ICheat>("Failed to create cheat");
		}

		return new SuccessResult<ICheat>(result);
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