using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject levelClearScreen;
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu"
            || SceneManager.GetActiveScene().name == "Credits"){
            Time.timeScale = 1;
        }else{
            Time.timeScale = 0;
        }

        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("audio", 0)==0) {
            audioSource.mute = true;
        }else{
            audioSource.mute = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void LevelClear()
    {
        Time.timeScale = 0;
        levelClearScreen.SetActive(true);
    }

    public void StartScene(string sceneName = "MainMenu")
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
   

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartLevel()
    {
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void toogleAudio()
    {
        audioSource.mute = !audioSource.mute;
        if (audioSource.mute) {
            PlayerPrefs.SetInt("audio", 0);
        }else{
            PlayerPrefs.SetInt("audio", 1);
        }
    }

    public void SetSelectedCharacter(int characterNum)
    {
        PlayerPrefs.SetInt("character", characterNum);
    }
}
