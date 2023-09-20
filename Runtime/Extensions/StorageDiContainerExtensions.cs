using EM.Foundation;
using EM.IoC;

namespace EM.GameKit.Context
{

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