using EM.BuildSystem;
using EM.Foundation;
using EM.IoC;
using EM.Profile;

namespace EM.GameKit.Context
{

public static class ProfileDiContainerExtensions
{
	public static IDiContainer BindProfile(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
	{
		container.Bind<IStorageSegmentReceiverFactory>()
			.SetLifeTime(lifeTime)
			.To<StorageSegmentReceiverFactory>()
			.AsSingle();

		container.Bind<JsonSerializeConfig>()
			.SetLifeTime(lifeTime)
			.To<JsonSerializeConfig>()
			.AsSingle();

		container.Bind<IStorageSerializer>()
			.SetLifeTime(lifeTime)
			.To<JsonStorageSerializer>()
			.AsSingle();

		container.Bind<IStorageLocation>()
			.SetLifeTime(lifeTime)
			.To<FileStorageLocation>()
			.AsSingle();

		container.Bind<IVersionConfig>()
			.SetLifeTime(lifeTime)
			.ToFactory<VersionAddressableAssetFactory>()
			.AsSingle();

		container.Bind<ISaveConfig>()
			.SetLifeTime(lifeTime)
			.ToFactory<SaveAddressableAssetFactory>()
			.AsSingle();

		container.Bind<IProfile>()
			.SetLifeTime(lifeTime)
			.To<Profile.Profile>()
			.AsSingle();

		return container;
	}

	public static IDiContainer ReleaseProfile(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Local)
	{
		container.Resolve<IProfile>()
			.Unbind(lifeTime);

		return container;
	}
}

}