using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TMP_Text scoreTxt;

    int score;
    public DificuldadeType dificuldade;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        scoreTxt.text = "Score: " + score;
        dificuldade = DificuldadeType.Easy;
    }

    public void UpdateScore (int value)
    {
        score += value;
        scoreTxt.text = "Score: " + score;
        if(score > 100)
        {
            dificuldade = DificuldadeType.Medium;
        }
        if (score > 500)
        {
            dificuldade = DificuldadeType.Hard;
        }
    }

}
