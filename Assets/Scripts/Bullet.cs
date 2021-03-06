﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rbody;
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BulletMove(Vector2 moveDirection,float moveForce)
    {
        rbody.AddForce(moveDirection * moveForce);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "animal")
        {
            print("Hit animal!!!");
            EnemyControler Ec = collision.gameObject.GetComponent<EnemyControler>();
            if (Ec != null)
            {
                Ec.animalChangeHealth(-1);
            }
        
        }else if(collision.gameObject.tag == "slime")
        {
            slime sl = collision.gameObject.GetComponent<slime>();
            sl.slimeChangeHealth(-1);
            Debug.Log("Hit Slime");
        }
        Destroy(this.gameObject);


    }
}
