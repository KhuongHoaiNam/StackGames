using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private GameObject mennuView;
    [SerializeField] private Button btnTaptoPlay;
    [SerializeField] private GameObject objTaptoPlay;
    [SerializeField] private GameObject objTxtScore;
    //popup Lose
    [SerializeField] private GameObject objBgGameOv;
    [SerializeField] private GameObject objPopupLose;
    [SerializeField] private GameObject objLose;
    [SerializeField] private Button btnOnReload;
    [SerializeField] private Button btnClickMennu;
    public static UIControler Instance;

    public void Awake()
    {
        Instance = this;
    }
    public void OnEnable()
    {
        btnPlay.onClick.RemoveListener(OnClickPlay);
        btnPlay.onClick.AddListener(OnClickPlay);

        btnTaptoPlay.onClick.RemoveListener(OnClickStartGame);
        btnTaptoPlay.onClick.AddListener(OnClickStartGame);

        btnOnReload.onClick.RemoveListener(OnClickReload);
        btnOnReload.onClick.AddListener(OnClickReload);

        btnClickMennu.onClick.RemoveListener(OnClickMennuView);
        btnClickMennu.onClick.AddListener(OnClickMennuView);
    }
    public void OnClickPlay()
    {
        mennuView.SetActive(false);
        objTaptoPlay.SetActive(true);
        Gamecontroler.instance.currentGameState = GameState.TapToPlay;
    }
    public void OnClickStartGame()
    {
        Gamecontroler.instance.currentGameState = GameState.StartGame;
        objTxtScore.SetActive(true);
        objTaptoPlay.SetActive(false);
        Gamecontroler.instance.CheckStartGame();
    }


    //Popup Lose
    public void SetupLose()
    {
        StartCoroutine(IeLose());
    }

    IEnumerator IeLose()
    {
        objLose.SetActive(true);
        objBgGameOv.SetActive(true);
        objPopupLose.SetActive(false);

        yield return new WaitForSeconds(3f);
        objBgGameOv.SetActive(false);
        objPopupLose.SetActive(true);
    }

    public void OnClickReload()
    {
        objBgGameOv.SetActive(true);
        objPopupLose.SetActive(false);
        objTaptoPlay.SetActive(true);
        objLose.SetActive(false);
        Gamecontroler.instance.ResetGamePlay();
    }

    public void OnClickMennuView()
    {
        Gamecontroler.instance.ResetGamePlay();
        objBgGameOv.SetActive(true);
        objPopupLose.SetActive(false);
        mennuView.gameObject.SetActive(true);
        objLose.gameObject.SetActive(false);
    }
}
