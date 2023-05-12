namespace EM.GameKit.Context
{

using IoC;

public interface IInstaller
{
	void InstallBindings(IDiContainer diContainer);
}

}