using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner4 : MonoBehaviour
{
    public GameObject item;
    public float delay = 2f;
    public float speed = 3f;
    float nextTimeToSpawn;

    void Start()
    {
        nextTimeToSpawn = Time.time;

    }

    void Update()
    {
        if (Time.time > nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + delay;
            GameObject go = Instantiate(item, transform.position, Quaternion.identity);
            go.AddComponent<Move4>();
            go.GetComponent<Move4>().speed = speed;

        }

    }
}

public class Move4 : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
