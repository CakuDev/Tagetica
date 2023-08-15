using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private Animator targetContainer;
    [SerializeField] private float timeToHide = 15f;
    [SerializeField] private int orderInLayer = 45;

    public bool HasTarget { get; private set; } = false;

    public void SpawnTarget()
    {
        GameObject target = Instantiate(targetPrefab, targetContainer.transform.position, targetContainer.transform.rotation, targetContainer.transform);
        // Set the order in layer to render correctly
        target.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
        target.GetComponent<TargetBehaviour>().TargetSpawnerBehaviour = this;
        targetContainer.SetTrigger("spawn");
        HasTarget = true;
        Invoke(nameof(HideTarget), timeToHide);
    }

    private void HideTarget()
    {
        if(HasTarget)
        {
            ResetTargetSpawner();
        }
    }

    public void ResetTargetSpawner()
    {
        HasTarget = false;
        targetContainer.SetTrigger("hide");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + (transform.up * 3.5f), 1.07f);
    }
}
