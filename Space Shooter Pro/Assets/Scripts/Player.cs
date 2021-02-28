using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultiplier = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private Spawnmanager _spawnManager;

    [SerializeField]
    private bool _speedBoost = false;
   

    [SerializeField]
    private bool _isTripleShotActive = false;

    [SerializeField]
    private bool _ShieldBoost = false;

   [SerializeField]
    private GameObject _shieldVisualizer;

    [SerializeField]
    private int _score;

    private UImanager _uiManager;

    [SerializeField]
    private AudioClip _laserSoundClip;
    private AudioSource _audioSource;
    


    void Start()
    {
        //Take the current position and assign it a current position = new position (0, 0, 0)

        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawnmanager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
        _audioSource = GetComponent<AudioSource>();
;        

        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is null");
        }

       if(_uiManager == null)
        {
            Debug.Log("the UI Manager is NULL");
        }
       if(_audioSource == null)
        {
            Debug.LogError("AudioSource is null");
        }
        else
        {
            _audioSource.clip = _laserSoundClip;
        }

       
       

    }



    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }


          /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, transform.position + (_laserPrefab.transform.up * 0.8f), Quaternion.identity);

           
            
        }*/

       

    }

    void FireLaser()
    {
        
            _canFire = Time.time + _fireRate;
           // Instantiate(_tripleShotPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);

        

            if(_isTripleShotActive == true)
            {
                Instantiate(_tripleShotPrefab, transform.position , Quaternion.identity);
               // _canFire = Time.time + 3;
            }else 
            {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);

            // _canFire = Time.time + 1;
             }

        _audioSource.Play();

        
        

    }

    public void Damage()
    {

        if (_ShieldBoost == true)
        {
           
           
           _ShieldBoost = false;
            _shieldVisualizer.SetActive(false);
            return;
            
        }
        else
        {
            //_shieldVisualizer.SetActive(false);
            _lives--;
            _uiManager.Updatelives(_lives);
            if(_lives < 1)
            {
                _uiManager.GameOver();
                
                


            }
            
        }

       





        //_lives--;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();  
            Destroy(this.gameObject);
                
            }
        }
    

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

       
        
        
        
            transform.Translate(direction * _speed * Time.deltaTime);
        
        

        /* if (transform.position.y >= 0)
         {
             transform.position = new Vector3(transform.position.x, 0, 0);
         }
         else if (transform.position.y <= -3.8f)
         {
             transform.position = new Vector3(transform.position.x, -3.8f, 0);
         }*/

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
      }
    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
      
            yield return new WaitForSeconds(5.0f);
            
            _isTripleShotActive = false;
        
        
    }

    public void SpeedBoostActive()
    {
        _speedBoost = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

   

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speedBoost = false;
        _speed /= _speedMultiplier;
    }

    public void shieldPowerUpActive()
    {
        _ShieldBoost = true;
        _shieldVisualizer.SetActive(true); 
       
        StartCoroutine(ShieldpowerUpRoutine());
    }

    IEnumerator ShieldpowerUpRoutine()
    {
        yield return new WaitForSeconds(8.0f);
       
        _ShieldBoost = false;
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

}



    

