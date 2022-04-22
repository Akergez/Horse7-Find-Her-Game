using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpRenderer : MonoBehaviour
{
    private Image ProgressBar;

    [SerializeField] private MonsterBehaviour _monsterBehaviour;
    
    private void Start()
    {
        ProgressBar = GetComponent<Image>();
    }
      

    void Update()
    {
        ProgressBar.fillAmount = (float)(BigData.MonstersMap[_monsterBehaviour].HealtPoints/5 * 0.05);
    }
}