using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroupBlock : MonoBehaviour
{
    /* public List<GameObject> children;
     public List<Vector3> childrenStartTransform;
     public float speed;
     public bool isMoving = false;
     int childrenIndex ;
     public void Update()
     {


     }

     public void OnEnable()
     {
         childrenIndex= Random.Range(0, children.Count);
         SetupChildren();
     }

     public void Start()
     {
         StartCoroutine(IeSetFalse());

     }

     public void SetupChildren()
     {
         ResetTransform();

         for (int i = 0; i < children.Count; i++)
         {
             Debug.Log(childrenIndex);
             if (children[i] != null)
             {
                 if (i == childrenIndex)
                 {
                     children[i].gameObject.SetActive(true);
                 }
                 else if (i != childrenIndex)
                 {
                     children[i].gameObject.SetActive(false);
                 }
             }

         }
         isMoving = true;
     }

     public void ResetTransform()
     {
         for (int i = 0; i < children.Count; i++)
         {
             children[i].transform.position = childrenStartTransform[i];
         }
     }
 */
    public List<MovingBlock> blocks;
    private Camera mainCamera;
    private bool isCheckCam;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void Update()
    {
        CheckCam();
    }
    public void OnEnable()
    {
        startInit();
        //StartCoroutine(IeSetFalse());
    }
    public void startInit()
    {
        var index = Random.Range(0, blocks.Count);
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].gameObject.SetActive(false);
            if (i == index)
            {
                blocks[i].gameObject.SetActive(true);
            }
        }
    }
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ZoneFale"))
        {
            this.gameObject.SetActive(false);
        }
    }*/
    /*  IEnumerator IeSetFalse()
      {
          yield return new WaitForSeconds(15f);
          this.gameObject.SetActive(false);
      }*/


    public void CheckCam()
    {
        Vector3 viewpos = mainCamera.WorldToViewportPoint(transform.position);

        isCheckCam = viewpos.x >= -2 && viewpos.x <=2 &&
                    viewpos.y >= -2 && viewpos.y <= 2 &&
                    viewpos.z > 0;
        if (!isCheckCam)
        {
            Debug.Log("Ra Khoi Cam");
            this.gameObject.SetActive(false);
        }
    }
}
