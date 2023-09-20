using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using EM.Foundation;
using EM.IoC;
using UnityEngine;

namespace EM.GameKit.Context
{

[DisallowMultipleComponent]
public abstract class Context : MonoBehaviour
{
	[SerializeField]
	private List<ContextDecorator> _decorators;

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
		DiContainer.Unbind(LifeTime.Local);
	}

	#endregion

	#region Context

	protected static IDiContainer DiContainer
	{
		get;
		private set;
	}

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
		if (DiContainer != null)
		{
			return;
		}

		var reflector = new Reflector();
		DiContainer = new DiContainer(reflector);

		DiContainer.Bind<IReflector>()
			.InGlobal()
			.To(reflector);

		DiContainer.Bind<IDiContainer>()
			.InGlobal()
			.To(DiContainer);
	}

	#endregion
}

}