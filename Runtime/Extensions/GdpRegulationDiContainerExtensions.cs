using EM.Foundation;
using EM.GameKit.UI;
using EM.IoC;

namespace EM.GameKit.Context
{

public static class GdpRegulationDiContainerExtensions
{
	public static IDiContainer BindGdpRegulation<TConfigProvider>(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Local)
		where TConfigProvider : class, IGdpRegulationConfigProvider
	{
		container.Bind<GdpRegulationModel>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationModel>()
			.AsSingle();

		container.Bind<GdpRegulationSaver>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationSaver>()
			.AsSingle();

		container.Bind<GdpRegulationRouter>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationRouter>()
			.AsSingle();

		container.Bind<GdpRegulationViewModel>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationViewModel>();

		container.Bind<GdpRegulation>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulation>()
			.AsSingle();

		container.Bind<IGdpRegulationConfigProvider>()
			.InLocal()
			.To<TConfigProvider>()
			.AsSingle();

		return container;
	}
}

}