using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
      Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
   void Start()
{
    _rigidbody2D = GetComponent<Rigidbody2D>();
    if (!Application.isPlaying)
    {
        // Disable destruction in Play Mode
        Destroy(this.gameObject, Mathf.Infinity);
    }
    else
    {
        // Destroy the bullet after 1.5 seconds in the game
        Destroy(this.gameObject, 1.5f);
    }
}

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.AddRelativeForce(new Vector2(0,5f));
        //Destroy(this.gameObject, 1f);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(this.gameObject, 0.5f);  
        // if(other.gameObject.tag == "Sandbag")
        // {
        //     Destroy(other.gameObject, 0.2f);
        // } 
    }
    
}
