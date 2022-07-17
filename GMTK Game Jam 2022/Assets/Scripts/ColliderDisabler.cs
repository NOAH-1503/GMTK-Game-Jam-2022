using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisabler : MonoBehaviour
{
    public GameObject drop1;
    public GameObject drop2;
    public GameObject drop3;
    public GameObject drop4;
    public GameObject drop5;
    public GameObject drop6;
    public GameObject drop7;
    public GameObject drop8;
    public GameObject drop9;
    public GameObject drop10;

    private float dropNumber;

    public Transform dropSpawner;

    public GameObject ladder;

    private void Start()
    {
        dropNumber = Random.Range(0, 10);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ladder.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(dropNumber >= 9)
            {
                Instantiate(drop1, dropSpawner);
            }
            else if (dropNumber >= 8)
            {
                Instantiate(drop2, dropSpawner);
            }
            else if (dropNumber >= 7)
            {
                Instantiate(drop3, dropSpawner);
            }
            else if (dropNumber >= 6)
            {
                Instantiate(drop4, dropSpawner);
            }
            else if (dropNumber >= 5)
            {
                Instantiate(drop5, dropSpawner);
            }
            else if (dropNumber >= 4)
            {
                Instantiate(drop6, dropSpawner);
            }
            else if (dropNumber >= 3)
            {
                Instantiate(drop7, dropSpawner);
            }
            else if (dropNumber >= 2)
            {
                Instantiate(drop8, dropSpawner);
            }
            else if (dropNumber >= 1)
            {
                Instantiate(drop9, dropSpawner);
            }
            else
            {
                Instantiate(drop10, dropSpawner);
            }
            Destroy(gameObject);
        }
    }
}
