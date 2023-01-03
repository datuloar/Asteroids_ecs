using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

namespace Asteroids.Core.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask<BaseSceneView> LoadSceneAsync(string name, LoadSceneMode mode)
        {
            await SceneManager.LoadSceneAsync(name, mode);

            return GetBaseSceneView(name);
        }

        private BaseSceneView GetBaseSceneView(string name)
        {
            var scene = SceneManager.GetSceneByPath(name);
            var rootGameObject = scene.GetRootGameObjects()[0];
            var baseView = rootGameObject.GetComponent<BaseSceneView>();

            if (baseView == null)
                throw new Exception($"Base view in root object of {name} doesn't found");

            return baseView;
        }
    }
}
