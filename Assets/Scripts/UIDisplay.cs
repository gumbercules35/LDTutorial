using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    private ScoreHandler scoreHandler;
    [SerializeField] private EntityHealth playerHealth;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] Slider healthSlider;
    
    void Start()
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
        healthSlider.maxValue = playerHealth.GetEntityHealthValue();
        HealthFill();
        UpdateScoreText();
        
    }

    
    void Update()
    {
        HealthFill();
        UpdateScoreText();
    }

    private void HealthFill(){
        healthSlider.value =  playerHealth.GetEntityHealthValue();
        
    }
    
    private void UpdateScoreText(){
        scoreText.text = "Score:" + scoreHandler.GetCurrentScore();
    }

    public void SetWaveCounterText(int count){
        waveText.text = "Wave: " + count;
    }
}
