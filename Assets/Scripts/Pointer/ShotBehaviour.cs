using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotBehaviour : MonoBehaviour
{
    [SerializeField] private Collider2D pointerCollider;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private Animator animator;

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
        }
        animator.Play("Reload");
    }

    public void FinishReloading()
    {
        canShoot = true;
        InitShot();
    }
}
