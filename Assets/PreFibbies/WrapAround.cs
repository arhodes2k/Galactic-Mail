using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    float top = 5.7f;
    float bottom = -5.7f;
    float right = 8.6f;
    float left = -8.6f;
    Rigidbody2D rb; 
    float MaxRotate = 4f;

    float MaxVelocity = 5f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        float spawnX = Random.Range(left, right);
        float spawnY = Random.Range(bottom, top);
        transform.position = new Vector3(spawnX, spawnY, 0f);
        rb.angularVelocity = Random.Range(-MaxRotate, MaxRotate);
        float Xvel = Random.Range(-MaxVelocity, MaxVelocity);
        float Yvel = Random.Range(-MaxVelocity, MaxVelocity);
        rb.velocity = new Vector3(Xvel, Yvel, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < left){
            transform.position = new Vector3(right, transform.position.y, transform.position.z);
        }
        if (transform.position.x > right){
            transform.position = new Vector3(left, transform.position.y, transform.position.z);
        }
        if (transform.position.y < bottom){
            transform.position = new Vector3(transform.position.x, top, transform.position.z);
        }
        if (transform.position.y > top){
            transform.position = new Vector3(transform.position.x, bottom, transform.position.z);
        }

    }
}
