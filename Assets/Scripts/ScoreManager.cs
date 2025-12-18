using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{ 
    [SerializeField]
    int player1goals = 0;
    [SerializeField]
    int player2goals = 0;
    [SerializeField]
    TextMeshProUGUI GoalText;

    public static ScoreManager instance;

    private void Awake()
    {
        if (ScoreManager.instance == null)
        {
            ScoreManager.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        UpdateGoalText();
    }

    public void Player1Scored()
    {
        player1goals++;
        UpdateGoalText();
    }
    
    public void Player2Scored()
    {
        player2goals++;
        UpdateGoalText();
    }

    void UpdateGoalText()
    {
        GoalText.text = player1goals.ToString() + " - " + player2goals.ToString();
    }
}
