using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour
{
     public Transform playerPos;
    private Rigidbody rb;
    public float speed = 6.0f;
    public float D = 1.0f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 diff = this.transform.position - playerPos.transform.position;
        if (diff.magnitude > D)
        {
            Quaternion sphereQuate = Quaternion.LookRotation(
                playerPos.transform.position - this.transform.position, Vector3.up);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, sphereQuate, 0.1f);
            rb.velocity = this.transform.forward * speed;
        }
    }
}

