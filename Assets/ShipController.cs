using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Animator anim; 
    AudioSource sound;
    public bool onMoon;
    public bool hit;
    [SerializeField] float dieTime = 0.2f;
    [SerializeField] float speed = 3f;
    [SerializeField] AudioClip landed;
    [SerializeField] AudioClip launch;
    [SerializeField] AudioClip explosion;
     GameObject moon;
     Rigidbody2D rbizzy;

    // Start is called before the first frame update
    void Start()
    {
        rbizzy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        //have to set this clip name every time you want to play the new sound
    }

    // Update is called once per frame
    void Update()
    { 
        float moveX; 
        float moveY; 
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        moon = GameObject.FindWithTag("moon");
        if (onMoon == false){
            // transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, transform.position.z);
            rbizzy.velocity = new Vector3(moveX * speed , moveY * speed, 0f);
   //         rbizzy.angularVelocity = moveX;
            
             anim.SetBool("onMoon", false);
        } 
        else {
             
             anim.SetBool("onMoon", true);
             
           } 
        
        if (Input.GetKeyDown(KeyCode.Space)){
            onMoon = false;
             sound.clip = launch; 
             sound.Play();
             transform.position = new Vector3(moon.transform.position.x + 0.1f, moon.transform.position.y +0.1f, 0f);
        }
         
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject asteroid; 
        asteroid = GameObject.FindWithTag("asteroid");

        if(collision.tag == "moon"){
            if (onMoon == false){
                transform.position = collision.transform.position;//new Vector3(moon.transform.position.x,moon.transform.position.y, 0f);
                 sound.clip = landed; 
                  sound.Play(); 
                  onMoon = true;
                Debug.Log("On Moon!");
            }
            
        }
        if(collision.tag == "asteroid"){

            if(onMoon == false){
                sound.clip = explosion; 
                speed = 0f;
                sound.Play();
                Destroy(gameObject, dieTime);
                anim.SetBool("hit", true);  
            } else {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), asteroid.GetComponent<Collider2D>());
            }
            
        }
    }
  
}
