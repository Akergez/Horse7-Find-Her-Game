using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public static class SceneLoader
    {
        public static void LoadScene(string scene, PlayerDataSaver data)
        {
            PlayerParameters.Data = data;
            SceneManager.LoadScene(scene);
        }
    }
}