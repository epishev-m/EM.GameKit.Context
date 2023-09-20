using System;
using EM.Foundation;
using EM.IoC;

namespace EM.GameKit.Context
{

public sealed class GameStateFactory : IGameStateFactory
{
	private readonly IDiContainer _diContainer;

	#region IStateFactory

	public Result<IGameState> Create(Type stateType)
	{
		var result = (IGameState) _diContainer.Resolve(stateType);

		if (result == null)
		{
			return new ErrorResult<IGameState>(GameStatesStringResources.FailedToGetInstance(this));
		}

		return new SuccessResult<IGameState>(result);
	}

	#endregion

	#region StateFactory

	public GameStateFactory(IDiContainer diContainer)
	{
		Requires.NotNullParam(diContainer, nameof(diContainer));

		_diContainer = diContainer;
	}

	#endregion
}

}