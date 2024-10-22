using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoker : MonoBehaviour
{
    public void OnEnable()
    {
        StartCoroutine(SetFale());
    }
    IEnumerator SetFale()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
