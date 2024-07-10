using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float Time_for_Destroy = 4f;
    void Start()
    {
        Destroy(gameObject, Time_for_Destroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
          Destroy (this.gameObject);
    }
}
