using Asteroids.Core.Configs;
using Asteroids.Core.Ecs;
using Asteroids.Core.Services.Factory;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_camera).AsSingle();
        Container.Bind<IECSRunner>().To<ECSRunner>().AsSingle();
        Container.Bind<IConfigProvider>().To<ConfigProvider>().AsSingle();
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

        ServicesInstaller.Install(Container);
    }
}
