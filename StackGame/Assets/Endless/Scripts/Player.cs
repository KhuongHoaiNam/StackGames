using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float Jumping;
    private Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    public Animator ani;
    public statePlayer currentState;
    public List<RuntimeAnimatorController> newController;
    public bool isJumping;
    public bool movingDie;
    public Transform posSmoker;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        SetupAnimator();
        SetState(statePlayer.Idle);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Gamecontroler.instance.currentGameState == GameState.StartGame)
        {
            if (isJumping == false)
            {
                SetState(statePlayer.Jump);
                rb.AddForce(new Vector2(rb.velocity.x, Jumping));
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            MovingBlock gourd = collision.gameObject.GetComponent<MovingBlock>();
            if (gourd != null && gourd.isMoving == true)
            {
                // Gamecontroler.instance.Spawenr();
                gourd.isMoving = false;
                Datamanager.Instance.Score ++;
                PoolingManager.Instance.SpawnerObj("Somoker", posSmoker.position, Quaternion.identity);
                Gamecontroler.instance.UpdateScore();
                PoolingManager.Instance.SpawnerBlock("AAA", Gamecontroler.instance.pos.position, Quaternion.identity);
                //gourd.isMoving = false;
            }
            SetState(statePlayer.Idle);
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            SetState(statePlayer.Die);
            Gamecontroler.instance.OnLose();
        }
    }

    public void SetState(statePlayer state)
    {
        if (currentState == state) return; // Tránh cài đặt lại cùng một trạng thái
        currentState = state;

        switch (state)
        {
            case statePlayer.Idle:
                ani.SetBool("Death", false);
                ani.SetBool("Jump", false);
                isJumping = false;
                break;
            case statePlayer.Jump:
                isJumping = true;
                ani.SetBool("Death", false);
                ani.SetBool("Jump", true);
                break;
            case statePlayer.Die:
                ani.SetBool("Death", true);
                boxCollider.enabled = false;
                break;
        }
    }
    public void SetupAnimator()
    {
        ani.runtimeAnimatorController = newController[Datamanager.Instance.idPlayer];
    }
}
public enum statePlayer
{
    Idle,
    Jump,
    Die,
}