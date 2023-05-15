namespace EM.GameKit.Context
{

using Foundation;

public static class StorageContextExtensions
{
	public static Context AddStorage(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<Storage>()
			.SetLifeTime(lifeTime)
			.To<Storage>()
			.ToSingleton();

		return context;
	}
}

}