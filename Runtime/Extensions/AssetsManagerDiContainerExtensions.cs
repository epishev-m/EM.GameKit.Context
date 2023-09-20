using EM.Foundation;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class AssetsManagerDiContainerExtensions
{
	public static IDiContainer BindAssetsManager(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
	{
		container.Bind<IAssetsManager>()
			.SetLifeTime(lifeTime)
			.To<AssetsManager>()
			.AsSingle();

		return container;
	}
}

}