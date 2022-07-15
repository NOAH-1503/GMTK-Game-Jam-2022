using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletLifetime;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("DestroyBullet", bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(bulletSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            DestroyBullet();
        }
    }

    void DestroyBullet ()
    {
        Destroy(gameObject);
    }
}
