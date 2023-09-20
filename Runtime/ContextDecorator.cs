using EM.IoC;
using UnityEngine;

namespace EM.GameKit.Context
{

public abstract class ContextDecorator : MonoBehaviour
{
	public abstract void Initialize(IDiContainer container);

	public abstract void Configure(IDiContainer container);

	public abstract void Release(IDiContainer container);
}

}