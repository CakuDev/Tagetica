using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour
{
    [SerializeField]
    private float shotDelay = 1.5f;
    [SerializeField]
    private Collider2D pointerCollider;
    [SerializeField]
    private ScoreController scoreController;

    public void InitShot()
    {
        pointerCollider.enabled = false;
        Invoke(nameof(Shot), shotDelay);
    }

    private void Shot()
    {
        // Raycast to check if a target is behind the pointer and the exact position
        var hit = Physics2D.Raycast(transform.position, Vector2.zero, 1, LayerMask.GetMask("Target"));
        if (hit.collider != null && hit.collider.TryGetComponent<TargetBehaviour>(out TargetBehaviour targetBehaviour))
        {
            int points = targetBehaviour.OnHit(transform.position);
            scoreController.UpdateScore(points);
        }
        pointerCollider.enabled = true;
    }
}
