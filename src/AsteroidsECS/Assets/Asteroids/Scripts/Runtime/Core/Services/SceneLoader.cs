using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

namespace Asteroids.Core.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadSceneAsync(string name, LoadSceneMode mode) =>
            await SceneManager.LoadSceneAsync(name, mode);
    }
}
