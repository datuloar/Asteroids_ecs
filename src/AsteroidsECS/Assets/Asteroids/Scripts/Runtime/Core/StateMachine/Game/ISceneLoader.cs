using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Asteroids.Core.Scene
{
    public interface ISceneLoader
    {
        UniTask<BaseSceneView> LoadSceneAsync(string name, LoadSceneMode mode);
    }
}
