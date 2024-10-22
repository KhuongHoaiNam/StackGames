using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroler : MonoBehaviour
{
    [SerializeField] private GameObject Lose;
    public static Gamecontroler instance;
    //public List<GameObject> gameControllers = new List<GameObject>();
    public int cout;
    public Transform pos;
    public int currentScore;
    public Text txtCurentScore;
    public GameState currentGameState;
    public Player Player;
    public SpriteRenderer sprStartGroup;
    public void Awake()
    {
        instance = this;
    }
    public void OnEnable()
    {
        ResetScore();
        sprStartGroup.sprite = Datamanager.Instance.spriteManager.spriteClasses[Datamanager.Instance.idPlayer].sprite[0];
    }
    public void Start()
    {
        // Spawenr();

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            PoolingManager.Instance.SpawnerBlock("AAA", pos.position, Quaternion.identity);
        }
    }

    /*    public void Spawenr()
        {
            for (int i = 0; i < gameControllers.Count; i++)
            {
                if (i == cout)
                {
                    gameControllers[i].gameObject.SetActive(true);
                }
            }
        }*/

    public void OnLose()
    {
        UIControler.Instance.SetupLose();
        currentGameState = GameState.EndGame;
    }

    public void UpdateScore()
    {
        currentScore++;
        txtCurentScore.text = $"{currentScore.ToString()}";
    }

    public void ResetScore()
    {
        currentScore = 0;
        txtCurentScore.text = $"{currentScore.ToString()}";
    }

    public void CheckStartGame()
    {
        PoolingManager.Instance.SpawnerBlock("AAA", pos.position, Quaternion.identity);
    }

    public void ResetGamePlay()
    {
        Player.transform.position = Vector3.zero;
        Player.boxCollider.enabled = true;
        Player.SetState(statePlayer.Idle);
        currentScore = 0;
        txtCurentScore.text = currentScore.ToString();
        PoolingManager.Instance.ResetPooling("AAA");
        currentGameState = GameState.TapToPlay;
    }
    
}
public enum GameState
{
    TapToPlay,
    StartGame,
    EndGame,
}
