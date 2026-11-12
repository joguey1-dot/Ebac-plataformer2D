using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> SpriteRenderers;
    public Color color = Color.red;
    public float duration = .3f;

    private Tween _currentTween;

    private void OnValidate()
    {
        SpriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            SpriteRenderers.Add(child);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Flash();
        }
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            SpriteRenderers.ForEach(i => i.color = Color.white);
        }
         
        foreach (var s in SpriteRenderers)
        {
            _currentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
