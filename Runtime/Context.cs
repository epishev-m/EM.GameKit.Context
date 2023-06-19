namespace EM.GameKit.Context
{

using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;
using IoC;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class Context : MonoBehaviour
{
	[SerializeField]
	private List<ContextDecorator> _decorators;

	private static IDiContainer _diContainer;

	private readonly CancellationTokenSource _cts = new();

	#region MonoBehaviour

	private void Awake()
	{
		CreateContainer();
		InitializeDecorators();
		Initialize();
		ConfigureDecorators();
		Configure();
	}

	private void Start()
	{
		RunAsync().Forget();
	}

	private void OnDestroy()
	{
		_cts.Cancel();
		Release();
		ReleaseDecorators();
		_diContainer.Unbind(LifeTime.Local);
	}

	#endregion

	#region Context

	public IDiContainer DiContainer => _diContainer;

	protected abstract void Initialize();

	protected abstract void Configure();

	protected abstract void Release();

	protected abstract UniTask RunAsync(CancellationToken ct);

	private void InitializeDecorators()
	{
		foreach (var decorator in _decorators)
		{
			decorator.Initialize(DiContainer);
		}
	}

	private void ConfigureDecorators()
	{
		foreach (var decorator in _decorators)
		{
			decorator.Configure(DiContainer);
		}
	}

	private void ReleaseDecorators()
	{
		foreach (var decorator in _decorators)
		{
			decorator.Release(DiContainer);
		}
	}

	private async UniTask RunAsync()
	{
		await RunAsync(_cts.Token);
	}

	private static void CreateContainer()
	{
		if (_diContainer != null)
		{
			return;
		}

		var reflector = new Reflector();
		_diContainer = new DiContainer(reflector);

		_diContainer.Bind<IReflector>()
			.InGlobal()
			.To(reflector);

		_diContainer.Bind<IDiContainer>()
			.InGlobal()
			.To(_diContainer);
	}

	#endregion
}

}