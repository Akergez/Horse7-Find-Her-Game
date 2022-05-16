using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoadScene : MonoBehaviour
{
    public GameObject popCenter;
    private Collision2D _collision;
    [FormerlySerializedAs("SceneToLoad")] [SerializeField]
    public string sceneToLoad;



    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player"))
        {
            _collision = newCollision;
            Debug.Log("!");
            ShowPopupCenter();
        }
        
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        popCenter.SetActive(false);
    }

    private void ShowPopupCenter()
    {
        popCenter.SetActive(true);
    }
    public void PressYes()
    {
        SceneManager.LoadScene(sceneToLoad);
        Resume();
    }

    public void PressNo()
    {
        Resume();
    }

    private void FixedUpdate()
    {
        if (_collision != null && _collision.contactCount == 0)
        {
            _collision = null;
            Resume();
        }
    }
}
