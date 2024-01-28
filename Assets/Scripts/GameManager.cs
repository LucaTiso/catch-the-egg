using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;

    [SerializeField]
    private float _leftBound;

    [SerializeField]
    private float _rightBound;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI currentScoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private Canvas endGameCanvas;

    [SerializeField]
    private Canvas scoreCanvas;

    [SerializeField]
    private CestinoController cestinoController;

    [SerializeField]
    private Rigidbody2D eggRigidbody;

    [SerializeField]
    private float eggSpawnHeight;

    [SerializeField]
    private float eggLowerLimit;

    void Start()
    {
        this.score = 0;
        ResetEggPosition();
    }

    void Update()
    {
        if (eggRigidbody.transform.position.y <= eggLowerLimit)
        {
            HandleLose();
        }
    }

    private void HandleLose()
    {

        eggRigidbody.gameObject.SetActive(false);
        cestinoController.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(true);

        int currentHighScore=PlayerPrefs.GetInt("Highscore");

        if (currentHighScore < score)
        {
            currentHighScore = score;
            PlayerPrefs.SetInt("Highscore", this.score);
        }

        currentScoreText.text = "Current Score: " + score;
        highScoreText.text = "High Score: " + currentHighScore;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetEggPosition()
    {
        eggRigidbody.angularVelocity = 0f;
        eggRigidbody.velocity = Vector3.zero;
        eggRigidbody.transform.eulerAngles = Vector3.zero;
        eggRigidbody.transform.position = new Vector3(GenerateSpawnPoint(), eggSpawnHeight, 0);
        eggRigidbody.gravityScale += 0.1f;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        ResetEggPosition();
    }

    private float GenerateSpawnPoint()
    {
        System.Random random = new();

        return _leftBound + (float)random.NextDouble() * (_rightBound - _leftBound);
    }


    public float RightBound
    {
        get{return _rightBound;}
    }

    public float LeftBound
    {
        get{ return _leftBound; }
    }

}
