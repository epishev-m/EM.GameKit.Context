namespace EM.GameKit.Context
{

using IoC;
using Foundation;

public static class CurrencyTooltipDiContainerExtensions
{
	public static IDiContainer BindCurrencyTooltip(this IDiContainer container,
		LifeTime lifeTime)
	{
		container.Bind<IconTooltipRouter>()
			.SetLifeTime(lifeTime)
			.To<IconTooltipRouter>()
			.AsSingle();

		container.Bind<IconTooltipViewModel>()
			.SetLifeTime(lifeTime)
			.To<IconTooltipViewModel>();

		return container;
	}
}

}