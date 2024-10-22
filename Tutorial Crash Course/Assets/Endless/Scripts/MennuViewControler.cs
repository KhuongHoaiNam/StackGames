using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MennuViewControler : MonoBehaviour
{
    public List<Sprite> lstSprPlayer;
    public Image imgPlayer;

    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnPrev;

    public Toggle btnMusic;
    public Toggle btnSound;

    public Player player;

    private void OnEnable()
    {
        btnNext.onClick.RemoveListener(OnClickNext);
        btnNext.onClick.AddListener(OnClickNext);

        btnPrev.onClick.RemoveListener(OnClickPrev);
        btnPrev.onClick.AddListener(OnClickPrev);

    }
    public void Start()
    {
        imgPlayer.sprite = lstSprPlayer[Datamanager.Instance.idPlayer];
        
    }

    public void OnClickNext()
    {
        if (Datamanager.Instance.idPlayer < lstSprPlayer.Count - 1)
        {
            Datamanager.Instance.idPlayer++;
            Gamecontroler.instance.sprStartGroup.sprite = Datamanager.Instance.spriteManager.spriteClasses[Datamanager.Instance.idPlayer].sprite[0];
            imgPlayer.sprite = lstSprPlayer[Datamanager.Instance.idPlayer];
            player.SetupAnimator();
        }
    }

    public void OnClickPrev()
    {
        if (Datamanager.Instance.idPlayer > 0)
        {
            Datamanager.Instance.idPlayer--;
            Gamecontroler.instance.sprStartGroup.sprite = Datamanager.Instance.spriteManager.spriteClasses[Datamanager.Instance.idPlayer].sprite[0];
            imgPlayer.sprite = lstSprPlayer[Datamanager.Instance.idPlayer];
            player.SetupAnimator();

        }

    }
}
