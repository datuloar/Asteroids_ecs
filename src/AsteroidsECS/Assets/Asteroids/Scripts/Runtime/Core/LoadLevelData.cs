using UnityEngine.SceneManagement;

namespace Asteroids.Core.Scene
{
    public class LoadLevelData
    {
        public LoadLevelData(string name, LoadSceneMode loadMode)
        {
            Name = name;
            LoadMode = loadMode;
        }

        public string Name { get; }
        public LoadSceneMode LoadMode { get; }
    }
}
