using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public Transform player; // Reference na transformaci hráče
    public TextMeshProUGUI scoreText; // Reference na textové pole pro zobrazení skóre

    private float maxHeight; // Maximální dosažená výška hráče
    private int score; // Skóre

    void Start()
    {
        // Inicializace proměnných
        maxHeight = player.position.y;
        score = 0;
        UpdateScoreText();
    }

    void Update()
    {
        // Aktualizace skóre na základě dosažené výšky hráče
        float currentHeight = player.position.y;
        if (currentHeight > maxHeight)
        {
            int scoreIncrease = Mathf.RoundToInt((currentHeight - maxHeight) * 10); // Výpočet přírůstku skóre
            score += scoreIncrease;
            maxHeight = currentHeight;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        // Aktualizace zobrazení skóre
        scoreText.text = "Score: " + score.ToString();
    }
}
