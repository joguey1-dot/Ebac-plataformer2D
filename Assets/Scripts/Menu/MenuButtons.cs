using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtons : MonoBehaviour
{
    [Header("AnimationSetup")]
    public float duration = .2f;
    public float delay = .05f;
    public List<GameObject> buttons;
    public Ease ease = Ease.OutBack;


    private void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach (var button in buttons)
        {
            button.transform.localScale = Vector3.zero;
            button.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        
        for(int i = 0; i < buttons.Count; i++)
        {
            var button = buttons[i];
            button.SetActive(true);
            button.transform.DOScale(1, duration).SetDelay(i*delay);
        }
    }

   
}
