using EM.Foundation;
using EM.GameKit.UI;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class BlackoutDiContainerExtensions
{
	public static IDiContainer BindBlackout(this IDiContainer container,
		LifeTime lifeTime)
	{
		container.Bind<BlackoutRouter>()
			.SetLifeTime(lifeTime)
			.To<BlackoutRouter>()
			.AsSingle();

		container.Bind<BlackoutViewModel>()
			.SetLifeTime(lifeTime)
			.To<BlackoutViewModel>();

		return container;
	}
}

}