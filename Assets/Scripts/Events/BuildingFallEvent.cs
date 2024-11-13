using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFallEvent : MonoBehaviour
{
    [Header("ÆÄÆ¼Å¬")]
    public GameObject ParticlePrefab;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, 10f, transform.position.z); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ParticlePrefab != null && collision.gameObject.CompareTag("Ground"))
        {
            GameObject particleInstance = Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particleInstance, 2f);
        }

    }
}
