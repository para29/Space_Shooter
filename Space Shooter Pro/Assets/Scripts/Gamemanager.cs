using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private bool _isgameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isgameOver == true)
        {
            SceneManager.LoadScene(1);
        }
        
     }


    public void GameOver()
    {
        _isgameOver = true;
    }
}
