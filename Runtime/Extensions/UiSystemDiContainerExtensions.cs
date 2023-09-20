using EM.Foundation;
using EM.IoC;
using EM.UI;

namespace EM.GameKit.Context
{

public static class UiSystemDiContainerExtensions
{
	public static IDiContainer BindUiSystem(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
	{
		container.Bind<IUiRoot>()
			.SetLifeTime(lifeTime)
			.To<UiRoot>()
			.AsSingle();

		container.Bind<IViewModelFactory>()
			.SetLifeTime(lifeTime)
			.To<ViewModelFactory>()
			.AsSingle();

		container.Bind<IScreenSystem>()
			.SetLifeTime(lifeTime)
			.To<ScreenSystem>()
			.AsSingle();

		container.Bind<IPanelSystem>()
			.SetLifeTime(lifeTime)
			.To<PanelSystem>()
			.AsSingle();

		return container;
	}

	public static IDiContainer ConfigureUiSystem(this IDiContainer container,
		string id)
	{
		container.Resolve<IUiRoot>()
			.CreateRootTransform(id);

		return container;
	}

	public static IDiContainer ReleaseUiSystem(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Local)
	{
		container.Resolve<IScreenSystem>()
			.Unbind(lifeTime);

		container.Resolve<IUiRoot>()
			.UnloadPanelView(lifeTime);

		return container;
	}
}

}