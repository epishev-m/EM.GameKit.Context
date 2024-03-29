﻿using System;
using EM.IoC;
using EM.UI;

namespace EM.GameKit.Context
{

public sealed class ViewModelFactory : IViewModelFactory
{
	private readonly IDiContainer _diContainer;

	#region IViewModelFactory

	public TViewModel Get<TViewModel>()
		where TViewModel : class
	{
		return _diContainer.Resolve<TViewModel>();
	}

	public IViewModel Get(Type type)
	{
		return _diContainer.Resolve(type) as IViewModel;
	}

	#endregion

	#region ViewModelFactory

	public ViewModelFactory(IDiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	#endregion
}

}