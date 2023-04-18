using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject canvasPause;
    [SerializeField] GameObject canvasGameOver;

    private void Start()
    {
        ResetTimeScale();
    }

    public void StartGame()
    {
        SoundManager.instance.PlayMenuSound();        
        Time.timeScale = 1f;
        SceneController.instance.StartGame();
    }

    public void PauseGame()
    {
        SoundManager.instance.PlayMenuSound();
        canvasPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        canvasGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SoundManager.instance.PlayMenuSound();        
        Time.timeScale = 1f;
        SceneController.instance.LoadTitleScreen();
    }

    public void ResumeGame()
    {
        SoundManager.instance.PlayMenuSound();
        canvasPause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResetTimeScale()
    {        
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        SoundManager.instance.PlayMenuSound();
        SceneController.instance.QuitGame();
    }

}
