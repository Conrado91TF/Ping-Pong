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
    
    [SerializeField]
    AudioClip scoreSound;
    

    public static ScoreManager instance;
    [SerializeField]
    float animationDuration = 0.5f;
    public LeanTweenType easeType = LeanTweenType.easeOutBounce;

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
    public void PlayScoreSound()
    {
        AudioSource.PlayClipAtPoint(scoreSound, Camera.main.transform.position);
    }

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

        LeanTween.scale(GoalText.rectTransform, Vector3.one * 1.5f, animationDuration).setEase(easeType).setOnComplete(() =>
        {
            LeanTween.scale(GoalText.rectTransform, Vector3.one, animationDuration).setEase(easeType);
        });
    }

}

