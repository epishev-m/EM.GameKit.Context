namespace EM.GameKit.Context
{

using BuildSystem;
using Foundation;
using IoC;
using Profile;

public static class ProfileDiContainerExtensions
{
	public static IDiContainer BindProfile(this IDiContainer container,
		LifeTime lifeTime)
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
			.To<Profile>()
			.AsSingle();

		return container;
	}

	public static IDiContainer ReleaseProfile(this IDiContainer container)
	{
		container.Resolve<IProfile>()
			.Unbind(LifeTime.Local);

		return container;
	}
}

}