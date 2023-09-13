using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject item;
    public float delay = 2f;
    public float speed = 3f;
    float nextTimeToSpawn;

    public Vector3 direction;
    public GameObject target;

    void Start()
    {
        nextTimeToSpawn = Time.time;
    }

    void Update()
    {
        direction = target.transform.position - transform.position;
        direction = direction.normalized;
        
        if (Time.time > nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + delay;
            GameObject go = Instantiate(item, transform.position, Quaternion.identity);
            go.AddComponent<Move>();
            go.GetComponent<Move>().speed = speed;
            go.GetComponent<Move>().newdirection = direction;

        }


        
    }

}

public class Move : MonoBehaviour
{
    public float speed;
    public Vector3 newdirection;

    void Update()
    {
        transform.Translate(newdirection * Time.deltaTime * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
