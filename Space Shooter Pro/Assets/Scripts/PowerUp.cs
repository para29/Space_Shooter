﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField] // 0 = Triple Shot; 1 = Speed; 2 = Shields;
    private int powerupID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            float randomY = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomY, 0, 0);

            Destroy(this.gameObject);

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
          

            //Comunica com o script de Player
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                    player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.shieldPowerUpActive();
                        break;
                    default:
                        Debug.Log("Fuck you");
                        break;

            }
                   
                
             
            }
           
            Destroy(this.gameObject);
        }


    }



}

