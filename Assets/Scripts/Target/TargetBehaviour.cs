using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [field: SerializeField] public int Score { get; private set; } = 10;
    [SerializeField] private Collider2D targetCollider;

    [HideInInspector] public TargetSpawnerBehaviour TargetSpawnerBehaviour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the pointer has entered the target
        collision.gameObject.TryGetComponent<ShotBehaviour>(out ShotBehaviour shotBehaviour);
        if (shotBehaviour != null)
        {
            shotBehaviour.onTarget = true;
            shotBehaviour.InitShot();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the pointer has entered the target
        collision.gameObject.TryGetComponent<ShotBehaviour>(out ShotBehaviour shotBehaviour);
        if (shotBehaviour != null)
        {
            shotBehaviour.onTarget = false;
        }
    }

    public int OnHit(Vector3 pointerPosition)
    {
        // Calculate the percentage according to the distance to the center of the target and the pointer
        var distance = Vector3.Distance(pointerPosition, targetCollider.bounds.center);
        var size = targetCollider.bounds.extents.x;
        var percentage = (size - distance) / size;

        // Multiply the score according to the percentage
        var score = Score;
        if (percentage >= 0.66)
        {
            score *= 3;
        }
        else if (percentage >= 0.33)
        {
            score *= 2;
        }
        TargetSpawnerBehaviour.ResetTargetSpawner();
        Destroy(gameObject);
        return score;
    }
}
