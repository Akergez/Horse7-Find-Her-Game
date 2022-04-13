using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

public class MainMenu : MonoBehaviour
{
    public void OnLoading(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByPath("Assets/Scenes/SampleScene.unity")));
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }

    public IEnumerator WaitForSceneLoad(Scene scene)
    {
        while(!scene.isLoaded)
        {
            yield return null;
        }
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        SceneManager.SetActiveScene (scene);
        
    }
    
    IEnumerator LoadSceneCoroutine(string pSceneName)
    {
        yield return SceneManager.LoadSceneAsync(pSceneName,LoadSceneMode.Additive);
        Scene chapterScene = SceneManager.GetSceneByName(pSceneName);
        SceneManager.SetActiveScene(chapterScene);
    }
    public void NewGameButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ContinueButton()
    {
        
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            SceneManager.LoadScene("SampleScene");
            

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            GameObject.Find("Isometric Diamond").transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
