using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject ship;
   
  
    float dieTime = 0.3f;
  

    
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
        


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
                Destroy(gameObject, dieTime);
        }
        } 
         
    } 
}
