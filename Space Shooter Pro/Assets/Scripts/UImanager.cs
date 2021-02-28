using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOvertext;
    [SerializeField]
    private Text _restartGame;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Sprite[] _livesSprites;



    // Start is called before the first frame update
    void Start()
    {
       
        _scoreText.text = "Score: " + 0;
        _gameOvertext.text = " ";
        _restartGame.text = " ";


       // _restartGame.gameObject.SetActive(false);
        //ou _gameOverText.GameObject.SetActive(false);
    }

   public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }
   
    public void Updatelives( int currentLives)
    {
        _LivesImg.sprite = _livesSprites[currentLives];
    }

    public void GameOver()
    {
        _gameOvertext.text = "GAME OVER";
        _restartGame.text = "Press R to restart Game";
        StartCoroutine(gameOverFlickerRoutine());
       
    }

   

   IEnumerator gameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOvertext.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
            _gameOvertext.text = "";
            yield return new WaitForSeconds(0.5f);
            _restartGame.text = "Press R to restart game";
            yield return new WaitForSeconds(0.5f);
            _restartGame.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

}
