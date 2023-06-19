namespace EM.GameKit.Context
{

using IoC;
using Foundation;

public static class StorageDiContainerExtensions
{
	public static IDiContainer BindStorage(this IDiContainer diContainer,
		LifeTime lifeTime)
	{
		diContainer.Bind<Storage>()
			.SetLifeTime(lifeTime)
			.To<Storage>()
			.AsSingle();

		return diContainer;
	}
}

}