using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class menu : MonoBehaviour
{
    [SerializeField] private Toggle audioToggle;

    private void OnEnable()
    {
        audioToggle.isOn = YandexGame.savesData.isSoundActive;
        audioToggle.onValueChanged.AddListener(muteAudio);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            changeLanguage();
            GameLogic.instance.InvokeTranslate();
        });
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void muteAudio(bool value)
    {
        AudioListener.volume = value ? 1 : 0;
        YandexGame.savesData.isSoundActive = value;
    }
    private void changeLanguage()
    {
        if(YandexGame.savesData.language != "ru")
            YandexGame.savesData.language = "ru";
        else
            YandexGame.savesData.language = "en";

    }
}
