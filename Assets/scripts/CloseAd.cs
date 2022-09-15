using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAd : MonoBehaviour
{
    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(showAd);
    }

    private void showAd() => YG.YandexGame.FullscreenShow();
}
