using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UpdateHealth(int newHp)
    {
        healthText.text = "Health: " + newHp;
    }
    public void Score()
    {
        score++;
        scoreText.text = "Score: " + score; 
    }
}
