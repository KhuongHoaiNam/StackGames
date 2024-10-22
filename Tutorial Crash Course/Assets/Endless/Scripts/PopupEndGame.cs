using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEndGame : MonoBehaviour
{
    [SerializeField] private Text toprScore;
    [SerializeField] private Text score;
    //back 
    [SerializeField] private Button btnReload;
    public void OnEnable()
    {
        Setup();
    }
    private void Setup()
    {
        score.text = Gamecontroler.instance.currentScore.ToString();
        toprScore.text = $"Top Score: {Datamanager.Instance.Score}";
    }
}
