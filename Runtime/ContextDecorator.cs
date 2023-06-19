namespace EM.GameKit.Context
{

using UnityEngine;
using IoC;

public abstract class ContextDecorator : MonoBehaviour
{
	public abstract void Initialize(IDiContainer container);

	public abstract void Configure(IDiContainer container);

	public abstract void Release(IDiContainer container);
}

}