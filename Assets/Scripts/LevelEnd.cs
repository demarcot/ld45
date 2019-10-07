using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private int time;

    private const string timeMessage = "Time Remaining: ";
    [SerializeField]
    private Text timeText;

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad >= time)
        {
            loadScene(SceneManager.GetActiveScene().buildIndex);
        } else
        {
            int timeRemaining = (int)(time - Time.timeSinceLevelLoad);
            timeText.text = timeMessage + timeRemaining.ToString();
        }
          
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            loadScene(currentScene + 1);
        }
    }

    void loadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
