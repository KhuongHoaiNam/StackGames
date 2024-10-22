using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public void OnEnable()
    {
        UIControler.Instance.SetupLose();
    }
}
