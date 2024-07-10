using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBergSpawner : MonoBehaviour
{
    [SerializeField] private IceBerg iceBergPrefab;
    [SerializeField] private float trajectoryVariance = 15.0f;
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private float spawnDistance = 15.0f;
    [SerializeField] private int spawnAmount = 1;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            IceBerg iceBerg = Instantiate(this.iceBergPrefab, spawnPoint, rotation);
            iceBerg.size = Random.Range(iceBerg.minSize, iceBerg.maxSize);
            iceBerg.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
