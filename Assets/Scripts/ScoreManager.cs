using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    int player1goals = 0;
    [SerializeField]
    int player2goals = 0;
    [SerializeField]
    TextMeshProUGUI GoalText;
    [SerializeField]
    private int maxGoals = 3;


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


    private void Start()
    {
        UpdateGoalText();
    }

    public void Player1Scored()
    {
        player1goals++;
        UpdateGoalText();
        CheckWinner();
        CheckWinner2();
    }


    public void Player2Scored()
    {
        player2goals++;
        UpdateGoalText();
        CheckWinner();
        CheckWinner2();
    }

    // tostring convierte un numero en texto
    // el signo + concatena textos
    // + " - " + agrega un guion entre los numeros
    void UpdateGoalText()
    {
        GoalText.text = player1goals.ToString() + " - " + player2goals.ToString();


        LeanTween.scale(GoalText.rectTransform, Vector3.one * 1.5f, animationDuration).setEase(easeType).setOnComplete(() =>
        {
            LeanTween.scale(GoalText.rectTransform, Vector3.one, animationDuration).setEase(easeType);
        });
    }
    //>= significa mayor o igual que
    //() significa que es una funcion
    public void CheckWinner()
    {
        if (player1goals >= maxGoals)
        {

            Time.timeScale = 0;
            FindAnyObjectByType<PanelVictoria>().MostrarPanelVictoria();
        }
        else
        {
            Debug.Log("Player 1 Wins!");
        }
    }
    public void CheckWinner2()
    {
        if (player2goals >= maxGoals)
        {

            Time.timeScale = 0;
            FindAnyObjectByType<PanelVictoria2>().MostrarPanelVictoria2();
        }
        else
        {
            Debug.Log("Player 2 Wins!");
        }

    }
}




