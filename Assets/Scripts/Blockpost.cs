using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blockpost : MonoBehaviour
{
    public GameObject StartPopup;
    public List<GameObject> Dialogues;
    public GameObject Object;
    private int _visitCount;

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player") && _visitCount == 0)
        {
            Debug.Log("Popup Dialog");
            if (BigData.Player.playerMovementBehaviour.IsPlayerFreezed) Resume();
            else
            {
                _visitCount += 1;
                ShowPopupStart();
            }
        }
    }

    private void Resume()
    {
        StartPopup.SetActive(false);
        Dialogues.FirstOrDefault(x => x.activeSelf)?.SetActive(false);
    }

    private void ResumeSummary()
    {
        BigData.Player.playerMovementBehaviour.SetPlayerFreezed(false);
        Dialogues.Last().SetActive(false);
    }

    private void ShowPopupStart()
    {
        BigData.Player.playerMovementBehaviour.SetPlayerFreezed(true);
        StartPopup.SetActive(BigData.Player.playerMovementBehaviour.IsPlayerFreezed);
    }

    public void PressNext(int index)
    {
        Resume();
        Dialogues[index].SetActive(true);
    }

    public void Cancel()
    {
        ResumeSummary();
        Destroy(Object);
    }
}