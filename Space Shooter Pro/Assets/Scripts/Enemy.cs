using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;


   private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.Log("The player is null");
        }
        m_Animator = gameObject.GetComponent<Animator>();

        if(m_Animator == null)
        {
            Debug.Log("Animator is null");
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(UnityEngine.Vector3.down * _speed * Time.deltaTime);

       

         if(transform.position.y < -5.53 )
         {
            float randomX = Random.Range(-8f, 8f);
            float randomY = Random.Range(-8f, 8f);
             transform.position = new UnityEngine.Vector3(randomX, 0, 0);
         }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {

            //damage player
            Player player = other.transform.GetComponent<Player>();


          

            if (player != null)
            {
                player.Damage();
                
               
            }
            m_Animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.5f);

        }
       

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            
                   if(_player != null)
            {
                _player.AddScore(10);
              

            }

            m_Animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.5f);

        }

       


    }

   

}
