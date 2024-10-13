using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Vector3 spawn;
    GameObject ship;
    float moveX;
    float moveY;
    float spawnX;
    float spawnY;
    float dieTime = 0.3f;
    float boundY = 5.7f;
    float boundX = 8.6f;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        moveX = Random.Range(-2f, 3f);
        moveY = Random.Range(-2, 3f);
        spawnY = Random.Range(-5.7f, 5.7f);
        spawnX = Random.Range(-8.6f, 8.6f);
        speed = Random.Range(0.3f, 0.4f);
        spawn = new Vector3(spawnX, spawnY, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > boundY){ 
            transform.position = new Vector3(spawnX, -boundY + 0.2f, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        }
        if(transform.position.x > boundX){
            transform.position = new Vector3(-boundX + 0.2f, spawnY, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        } 
        if(transform.position.y < -boundY){ 
            transform.position = new Vector3(spawnX, boundY - 0.2f, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        }
        if(transform.position.x < -boundX){
            transform.position = new Vector3(boundX - 0.2f, spawnY, transform.position.z);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f); 
        } 
        

    }
    void OnTriggerEnter2D(Collider2D collision) { 
        bool onAnotherMoon = ship.GetComponent<ShipController>().onMoon;
        if(collision.tag == "Player"){
            if(onAnotherMoon == true ){
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ship.GetComponent<Collider2D>());
             
            } else {
               onAnotherMoon = false;
        }
        } 
    }
    void OnTriggerExit2D(Collider2D collision) {
        bool onAnotherMoon = ship.GetComponent<ShipController>().onMoon;

        if(collision.tag == "Player"){
            if(onAnotherMoon == true ){
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ship.GetComponent<Collider2D>());
             
            } else {
                onAnotherMoon = false;
                Destroy(gameObject);
        }
        } 
         
    }
}
