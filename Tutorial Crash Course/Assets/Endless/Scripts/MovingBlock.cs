using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer imgBlock;
    [SerializeField] private GameObject objWarning;

    public bool isMoving = true;
    public  Transform startPos;

    public void OnEnable()
    {
        this.gameObject.transform.position = startPos.transform.position;
       StartCoroutine(CheckWarning());
    }

    public void Update()
    {
        if (isMoving == true)
        {
            IsMoving();
        }
    }
    public void IsMoving()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, this.transform.position.y, 0), speed * Time.deltaTime);
    }
    IEnumerator CheckWarning()
    {
        objWarning.SetActive(true);
        imgBlock.sprite = Datamanager.Instance.spriteManager.GetRandomSprite();
        isMoving = false;
        yield return new WaitForSeconds(2f);
        isMoving = true;
        objWarning.SetActive(false);

    }
  
}
