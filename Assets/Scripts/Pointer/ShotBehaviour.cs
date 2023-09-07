using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotBehaviour : MonoBehaviour
{
    [SerializeField] private Collider2D pointerCollider;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject plus10;
    [SerializeField] private GameObject plus20;
    [SerializeField] private GameObject plus30;

    private bool canShoot = true;
    public bool onTarget { get; set; } = false;

    public void InitShot()
    {
        if(canShoot && onTarget) {
            canShoot = false;
            animator.Play("Shoot");
        }
    }

    public void Shot()
    {
        // Raycast to check if a target is behind the pointer and the exact position
        var hit = Physics2D.Raycast(transform.position, Vector2.zero, 1, LayerMask.GetMask("Target"));
        if (hit.collider != null && hit.collider.TryGetComponent<TargetBehaviour>(out TargetBehaviour targetBehaviour))
        {
            onTarget = false;
            int points = targetBehaviour.OnHit(transform.position);
            scoreController.UpdateScore(points);
            ShowPoints(points);
        }
        animator.Play("Reload");
    }

    public void FinishReloading()
    {
        canShoot = true;
        InitShot();
    }

    private void ShowPoints(int points)
    {
        // Instantiate the according sprite above the pointer
        Vector3 position = transform.position + new Vector3(0f, 0.75f, 0f);
        if (points == 10) Instantiate(plus10, position, plus10.transform.rotation);
        if (points == 20) Instantiate(plus20, position, plus10.transform.rotation);
        if (points == 30) Instantiate(plus30, position, plus10.transform.rotation);
    }
}
