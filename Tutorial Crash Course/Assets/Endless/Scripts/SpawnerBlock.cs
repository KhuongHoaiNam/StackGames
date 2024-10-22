using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{
    public GameObject objBlock;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(objBlock, this.transform);
        }
    }
}
