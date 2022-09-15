using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Click : MonoBehaviour
{
    [SerializeField] private Button _clickButton;
    [SerializeField] private Animator noobAnim;
    [SerializeField] private GameObject parentEarning;
    [SerializeField] private TextMeshProUGUI clone;
    [SerializeField] private AudioSource audio;

    private GameLogic _logic;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        _logic = GameLogic.instance;
        _clickButton.onClick.AddListener(() => { 
            AddMoney(); 
            anim(); 
            spawnText();
            PlayAudio();
        });
    }

    private void spawnText()
    {

            float x = parentEarning.GetComponent<CanvasScaler>().referenceResolution.x/5;
            float y = parentEarning.GetComponent<CanvasScaler>().referenceResolution.y/5;
            Vector3 ClickPosition = new Vector3(UnityEngine.Random.Range(-x, x), UnityEngine.Random.Range(-y, y), 0);

            TextMeshProUGUI go = Instantiate(clone);

            go.transform.SetParent(parentEarning.transform, false);
            go.transform.GetComponent<RectTransform>().localPosition = ClickPosition;
            go.text = $"+{_logic.oneClickCost * _logic.bonus}"; // показать на экране сколько денег за соломанный блок
            Destroy(go.gameObject, .75f);
        
    }

    private void AddMoney() => _logic.AddMoney((ulong)(_logic.oneClickCost * _logic.bonus));

    private void anim() => noobAnim.SetTrigger("arms");

    private void PlayAudio() => audio.Play();
    
}