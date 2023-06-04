namespace EM.GameKit.Context
{

using Foundation;

public static class CurrencyTooltipContextExtensions
{
	public static Context BindCurrencyTooltip(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<IconTooltipRouter>()
			.SetLifeTime(lifeTime)
			.To<IconTooltipRouter>()
			.ToSingleton();

		context.DiContainer
			.Bind<IconTooltipViewModel>()
			.SetLifeTime(lifeTime)
			.To<IconTooltipViewModel>();

		return context;
	}
}

}