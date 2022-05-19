using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneLoader : MonoBehaviour
{
    [SerializeField] public string sceneToLoad;
    [SerializeField] public float timeout;
    [SerializeField] public bool loadFromStart;

    public void Start()
    {
        if(loadFromStart)
            LoadScene();
    }

    public void LoadScene()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    public IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(timeout);
        SceneManager.LoadScene(sceneToLoad);
    }
}
