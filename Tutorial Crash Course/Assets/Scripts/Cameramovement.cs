using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        if (Gamecontroler.instance.currentScore > 2 )
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(0f, 0f , -10f);
        }
    }
}
