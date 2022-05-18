using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    public IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
