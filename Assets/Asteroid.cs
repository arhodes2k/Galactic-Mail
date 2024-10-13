using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    Vector3 spawn;

    float moveX;
    float moveY;
    float spawnX;
    float spawnY;
    float boundY = 5.7f;
    float boundX = 10.7f;
    void Start()
    {
        moveX = Random.Range(-2f, 3f);
        moveY = Random.Range(-2, 3f);
        spawnY = Random.Range(-5.7f, 5.7f);
        spawnX = Random.Range(-10.7f, 10.7f);
        speed = Random.Range(0.2f, 0.4f);
        
        spawn = new Vector3(spawnX, spawnY, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > boundY){ 
            transform.position = new Vector3(spawnX, -boundY, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        }
        if(transform.position.x > boundX){
            transform.position = new Vector3(-boundX, spawnY, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        } 
        if(transform.position.y < -boundY){ 
            transform.position = new Vector3(spawnX, boundY, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        }
        if(transform.position.x < -boundX){
            transform.position = new Vector3(boundX, spawnY, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        } 
    }
}
