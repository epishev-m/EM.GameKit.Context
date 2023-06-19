namespace EM.GameKit.Context
{

using IoC;
using Foundation;

public static class AssetsManagerDiContainerExtensions
{
	public static IDiContainer BindAssetsManager(this IDiContainer container,
		LifeTime lifeTime)
	{
		container.Bind<IAssetsManager>()
			.SetLifeTime(lifeTime)
			.To<AssetsManager>()
			.AsSingle();

		return container;
	}
}

}