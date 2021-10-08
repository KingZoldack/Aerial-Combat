using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    int _score;

    [SerializeField] Text _scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncreaseScore(int amountToIncrease)
    {
        _score += amountToIncrease;
        _scoreText.text = "Score: " + _score.ToString();
    }
}
