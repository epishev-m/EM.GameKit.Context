namespace EM.GameKit.Context
{

using Foundation;
using UI;

public static class UiSystemContextExtensions
{
	public static Context BindUiSystem(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;
		
		context.DiContainer
			.Bind<IUiRoot>()
			.SetLifeTime(lifeTime)
			.To<UiRoot>()
			.ToSingleton();

		context.DiContainer
			.Bind<IViewModelFactory>()
			.SetLifeTime(lifeTime)
			.To<ViewModelFactory>()
			.ToSingleton();

		context.DiContainer
			.Bind<IScreenSystem>()
			.SetLifeTime(lifeTime)
			.To<ScreenSystem>()
			.ToSingleton();

		context.DiContainer
			.Bind<IPanelSystem>()
			.SetLifeTime(lifeTime)
			.To<PanelSystem>()
			.ToSingleton();

		return context;
	}

	public static Context ConfigureUiSystem(this Context context,
		string id)
	{
		context.DiContainer
			.Resolve<IUiRoot>()
			.CreateRootTransform(id);

		return context;
	}

	public static Context ReleaseUiSystem(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Resolve<IScreenSystem>()
			.Unbind(lifeTime);

		context.DiContainer
			.Resolve<IUiRoot>()
			.UnloadPanelView(lifeTime);

		return context;
	}
}

}