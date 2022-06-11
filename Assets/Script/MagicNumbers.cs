using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    public int Min = 1;
    public int Max = 2000;
    private int _guess;
    private int steps;

    public TextMeshProUGUI InfoLabel;
    public TextMeshProUGUI GuessLabel;
    public Button MoreButton;
    public Button LessButton;
    public Button FinishButton;
    public Button RestartButton;

    private void Start()
    {
        MoreButton.onClick.AddListener(MoreButtonClicked);
        LessButton.onClick.AddListener(LessButtonClicked);
        FinishButton.onClick.AddListener(FinishButtonClicked);
        RestartButton.onClick.AddListener(RestartButtonClicked);
        SetInfoText($"Загадай число от {Min} до {Max}.");
        CalculateGuess();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Победа");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Число меньше");
            Max = _guess;
            CalculateGuess();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Число больше");
            Min = _guess;
            CalculateGuess();
        }
    }

    private void CalculateGuess()
    {
        _guess = (Min + Max) / 2;
        steps++;
        SetGuessText($"Твое число {_guess}?");
    }

    private void SetInfoText(string text)
    {
        Debug.Log(text);
        InfoLabel.text = text;
    }

    private void SetGuessText(string text)
    {
        Debug.Log(text);
        GuessLabel.text = text;
    }

    private void MoreButtonClicked()
    {
        Min = _guess;
        CalculateGuess();
        SetGuessText($"Твое число {_guess}?");
    }

    private void LessButtonClicked()
    {
        Max = _guess;
        CalculateGuess();
        SetGuessText($"Твое число {_guess}?");
    }

    private void FinishButtonClicked()
    {
        SetGuessText($"Победа! Твое число: {_guess}");
        SetInfoText($"Число шагов: {steps - 1}");
        MoreButton.gameObject.SetActive(false);
        LessButton.gameObject.SetActive(false);
        FinishButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(true);
    }

    private void RestartButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}