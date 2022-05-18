using UnityEngine;

public class Learning : MonoBehaviour
{
    [SerializeField] public GameObject GameObject;
    void Start()
    {
        Time.timeScale = 0f;
        GameObject.SetActive(true);
    }
    public void MoveToScene()
    {
        Time.timeScale = 1f;
        GameObject.SetActive(false);
    }

}
