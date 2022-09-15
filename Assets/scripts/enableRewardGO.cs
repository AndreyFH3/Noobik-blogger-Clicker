using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableRewardGO : MonoBehaviour
{
    [SerializeField] private GameObject enableObject;
    [SerializeField] private int time;

    private void OnEnable()
    {
        StartCoroutine(nameof(Reseter));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Reseter));
    }

    private IEnumerator Reseter()
    {
        while (true)
        {
            enableObject.SetActive(enableObject.activeSelf ? false: true);
            yield return new WaitForSeconds(time);
        }
    }


}