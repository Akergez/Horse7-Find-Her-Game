using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Pause : MonoBehaviour
{
    public float timer;
    public bool isPause;
    public bool guiPause;
    public float[] position;
    public static GameObject player;
    
    
    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            isPause = false;
        }

        if (isPause == true)
        {
            timer = 0;
            guiPause = true;

        }
        else if (isPause == false)
        {
            timer = 1f;
            guiPause = false;

        }
    }
    public void OnGUI()
    {
        if (guiPause == true)
        {
            GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
            myButtonStyle.fontSize = 50;

            Cursor.visible = true;

            if (GUI.Button(new Rect((float)(Screen.width / 2) - 200f, 100, 500, 150), "Продолжить", myButtonStyle))
            {
                isPause = false;
                timer = 0;
                Cursor.visible = false;
            }
            if (GUI.Button(new Rect((float)(Screen.width / 2) - 200f, 400, 500, 150), "Сохранить", myButtonStyle))
            {
                SaveGame();
            }
            if (GUI.Button(new Rect((float)(Screen.width / 2) - 200f, 700, 500, 150), "Загрузить", myButtonStyle))
            {
                isPause = false;
                timer = 0;
                LoadGame();
            }
            if (GUI.Button(new Rect((float)(Screen.width / 2) - 200f, 1000, 500, 150), "В Меню", myButtonStyle))
            {
                isPause = false;
                timer = 0;
                SceneManager.LoadScene("Menu"); 
            }
        }
    }
    
    public static void SaveGame()
    {
        player = GameObject.Find("player");
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat"); 
        SaveData data = new SaveData(player);
        data.position[0] = player.transform.position.x;
        data.position[1] = player.transform.position.y;
        data.position[2] = player.transform.position.z;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            GameObject.Find("player").transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[Serializable]
public class SaveData
{
  public float[] position;
  
  public SaveData(GameObject player)
  {
      position = new float[3];
      position[0] = player.transform.position.x;
      position[1] = player.transform.position.y;
      position[2] = player.transform.position.z;
  }
}
