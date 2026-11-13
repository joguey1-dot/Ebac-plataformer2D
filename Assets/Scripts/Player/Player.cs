using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("AnimationSetup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = 1.5f;
    public Ease Ease = Ease.OutBack;

    [Header("Animation player")]
    public string boolRun = "Run";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    [Header("Projectile Setup")]
    public GameObject projectilePrefab; 
    public Transform shootPoint;        
    public KeyCode shootKey = KeyCode.F; 

    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        handleMoviments();
        HandleShoot();
    }

    private void handleMoviments()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
            animator.speed = 2f;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1f;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }


        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }

    }


    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forceJump;

            
            Vector3 currentScale = myRigidbody.transform.localScale;
            currentScale.y = 1f;
            myRigidbody.transform.localScale = currentScale;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(Ease);
        myRigidbody.transform.DOScaleX(jumpScaleX * Mathf.Sign(myRigidbody.transform.localScale.x), animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(Ease);
    }

    private void HandleShoot()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            ProjectileBase projectileComponent = projectileInstance.GetComponent<ProjectileBase>();

            if (projectileComponent != null)
            {
               
                float direction = transform.localScale.x > 0 ? 1f : -1f;

             
                projectileComponent.SetDirection(direction);
            }
        }
    }
}