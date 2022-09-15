using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PictureChanger : MonoBehaviour
{
    [SerializeField] private Sprite engPicture;
    private Sprite rusPicture;
    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        rusPicture = renderer.sprite;
    }

    private void OnEnable()
    {
        languagePictureChange();
        GameLogic.instance.translateUI += languagePictureChange;
    }

    private void OnDisable()
    {
        GameLogic.instance.translateUI -= languagePictureChange;
    }

    private void languagePictureChange()
    {
        if(YandexGame.savesData.language == "ru")
            renderer.sprite = rusPicture;
        else
            renderer.sprite = engPicture;
    }

}
