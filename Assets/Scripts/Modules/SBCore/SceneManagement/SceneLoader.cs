using UnityEngine.SceneManagement;

namespace Modules.SBCore.SceneManagement
{
    /// <summary>
    /// proceed scene switch via those class
    /// </summary>
    public static class SceneLoader
    {
        public static void LoadScene(Scenes scene) 
        {
            SceneManager.LoadScene((int) scene);
        }

        public static UnityEngine.AsyncOperation LoadSceneAsync(Scenes scene) 
        {
            return SceneManager.LoadSceneAsync((int) scene);
        }
    }
}
