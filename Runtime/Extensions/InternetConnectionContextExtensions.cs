﻿namespace EM.GameKit.Context
{

using Foundation;

public static class InternetConnectionContextExtensions
{
	public static Context AddInternetConnection(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<InternetConnection>()
			.SetLifeTime(lifeTime)
			.To<InternetConnection>()
			.ToSingleton();

		context.DiContainer
			.Bind<InternetConnectionRouter>()
			.SetLifeTime(lifeTime)
			.To<InternetConnectionRouter>()
			.ToSingleton();

		context.DiContainer
			.Bind<InternetConnectionViewModel>()
			.SetLifeTime(lifeTime)
			.To<InternetConnectionViewModel>();

		return context;
	}
}

}