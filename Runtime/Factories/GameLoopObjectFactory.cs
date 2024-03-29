﻿using System;
using EM.IoC;

namespace EM.GameKit.Context
{

public sealed class GameLoopObjectFactory : IGameLoopObjectFactory
{
	private readonly IDiContainer _diContainer;

	#region IGameLoopObjectFactory

	public IGameLoopObject Get(Type type)
	{
		return _diContainer.Resolve(type) as IGameLoopObject;
	}

	#endregion

	#region GameLoopObjectFactory

	public GameLoopObjectFactory(IDiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	#endregion
}

}