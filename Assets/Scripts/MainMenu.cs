using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGameButton()
    {
        SceneManager.LoadScene("DreamPrologue");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
