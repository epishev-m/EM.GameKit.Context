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
			.Bind<CurrencyTooltipRouter>()
			.SetLifeTime(lifeTime)
			.To<CurrencyTooltipRouter>()
			.ToSingleton();

		context.DiContainer
			.Bind<SimpleCurrencyTooltipViewModel>()
			.SetLifeTime(lifeTime)
			.To<SimpleCurrencyTooltipViewModel>();

		return context;
	}
}

}