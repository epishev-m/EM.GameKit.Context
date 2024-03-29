﻿using System;
using EM.Foundation;
using EM.IoC;
using EM.Profile;

namespace EM.GameKit.Context
{

public sealed class StorageSegmentReceiverFactory : IStorageSegmentReceiverFactory
{
	private readonly IDiContainer _diContainer;

	#region IStorageSegmentReceiverFactory

	public Result<IStorageSegmentSaver> Get(Type type)
	{
		var saver = _diContainer.Resolve(type);

		if (saver is IStorageSegmentSaver result)
		{
			return new SuccessResult<IStorageSegmentSaver>(result);
		}

		return new ErrorResult<IStorageSegmentSaver>("Failed to create StorageSegmentSaver");
	}

	#endregion

	#region ReceiverFactory

	public StorageSegmentReceiverFactory(IDiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	#endregion
}

}