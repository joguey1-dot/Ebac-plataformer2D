using DG.Tweening;
using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemis")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("AnimationSetup")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private GameObject _currentPlayer;
        
    private void Start()
    {
        init();
    }

    private void init()
    {
        spawnPlayer(); 
    }

    private void spawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }
}
