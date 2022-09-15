using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class WatchAd : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button minsButton;
    [SerializeField] private Button goldButton;
    [SerializeField] private Button doubleButton;

    [Header("Canvas")]
    [SerializeField] private GameObject cheaterCanvas;

    [SerializeField] private GameObject podlojka;
    private void OnEnable()
    {
        YandexGame.CloseVideoEvent += RewardedAD;
        YandexGame.CheaterVideoEvent += CheaterAd;

        minsButton.onClick.AddListener(() => YandexGame.RewVideoShow(1));
        goldButton.onClick.AddListener(() => YandexGame.RewVideoShow(2));
        doubleButton.onClick.AddListener(() => YandexGame.RewVideoShow(3));
    }

    private void OnDisable()
    { 
        YandexGame.CloseVideoEvent -= RewardedAD;
        YandexGame.CheaterVideoEvent -= CheaterAd;

        minsButton.onClick?.RemoveAllListeners();
        goldButton.onClick?.RemoveAllListeners();
        doubleButton.onClick?.RemoveAllListeners();
    }

    private void DisableParentGameobject() => podlojka.SetActive(false);

    private void RewardedAD(int index)
    {
        if(index == 1)
        {
            GameLogic.instance.AddMoney(Bonus.TimeWarp(30));
            Invoke(nameof(DisableParentGameobject), 1f);
        }
        else if(index == 2)
        {
            GameLogic.instance.AddPremiumMoney(5);
            Invoke(nameof(DisableParentGameobject), 1f);
        }
        else if(index == 3)
        {
            Bonus.SetBonusMultiplayer(30, 2);
            Invoke(nameof(DisableParentGameobject), 1f);
        }
    }

    private void CheaterAd() => cheaterCanvas.SetActive(true);
}
