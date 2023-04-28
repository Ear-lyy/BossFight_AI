using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    public Transform player;
    public float duration = 10.0f;
    public float speed = 4.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Destroy(gameObject);
            Debug.Log(duration);
        }
    }
}