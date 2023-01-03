using Asteroids.Core.Scene;
using Asteroids.Core.Services;
using Asteroids.Core.Services.Assets;
using Zenject;

public class ServicesInstaller : Installer<ServicesInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        Container.Bind<IAssetsProvider>().To<AddressablesAssetsProvider>().AsSingle();
    }
}