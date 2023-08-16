using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnersController : MonoBehaviour
{
    [SerializeField] private List<TargetSpawnerBehaviour> targetSpawners;

    public void SpawnTarget()
    {
        List<TargetSpawnerBehaviour> targetSpawnersNoActive = targetSpawners.FindAll(targetSpawner => !targetSpawner.HasTarget);
        if(targetSpawnersNoActive.Count > 0)
        {
            int index = Random.Range(0, targetSpawnersNoActive.Count);
            targetSpawnersNoActive[index].SpawnTarget();
        }
    }

    public void HideAllTargets()
    {
        foreach(TargetSpawnerBehaviour targetSpawner in targetSpawners)
        {
            targetSpawner.HideTarget();
        }
    }
}
