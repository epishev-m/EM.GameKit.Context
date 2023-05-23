namespace EM.GameKit.Context
{

using Foundation;

public static class BlackoutContextExtensions
{
	public static Context BindBlackout(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<BlackoutRouter>()
			.SetLifeTime(lifeTime)
			.To<BlackoutRouter>()
			.ToSingleton();

		context.DiContainer
			.Bind<BlackoutViewModel>()
			.SetLifeTime(lifeTime)
			.To<BlackoutViewModel>();

		return context;
	}
}

}