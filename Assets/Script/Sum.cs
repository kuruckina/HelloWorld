using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sum : MonoBehaviour
{
    public TextMeshProUGUI StepsLabel;
    public TextMeshProUGUI SumLabel;
    public TextMeshProUGUI WinOrLoseLabel;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;
    public Button Button9;
    public Button RestartButton;

    private int _userNumber;
    private int _userSum;
    private int _steps;
    private int _sum = 50;

    void Start()
    {
        Button1.onClick.AddListener(() => GetButtonValue(1));
        Button2.onClick.AddListener(() => GetButtonValue(2));
        Button3.onClick.AddListener(() => GetButtonValue(3));
        Button4.onClick.AddListener(() => GetButtonValue(4));
        Button5.onClick.AddListener(() => GetButtonValue(5));
        Button6.onClick.AddListener(() => GetButtonValue(6));
        Button7.onClick.AddListener(() => GetButtonValue(7));
        Button8.onClick.AddListener(() => GetButtonValue(8));
        Button9.onClick.AddListener(() => GetButtonValue(9));
        RestartButton.onClick.AddListener(RestartGame);

        _userSum = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _userSum = 0;
            _steps = 0;
            SetSum($"Сумма: {_userSum}");
            SetSteps($"Количество шагов: {_steps}");
        }

        if (_userSum == _sum)
        {
            BlockButtons();
            SetWinOrLose("Победа");
        }
        else if (_userSum > _sum)
        {
            BlockButtons();
            SetWinOrLose($"Число больше {_sum}. Вы проиграли.");
        }
    }

    private void CalculateSum()
    {
        _userSum += _userNumber;
        SetSum($"Сумма: {_userSum}");
        _steps++;
        SetSteps($"Количество шагов: {_steps}");
    }

    private void GetButtonValue(int value)
    {
        _userNumber = value;
        CalculateSum();
    }

    private void SetSteps(string text)
    {
        StepsLabel.text = text;
    }

    private void SetSum(string text)
    {
        SumLabel.text = text;
    }

    private void SetWinOrLose(string text)
    {
        WinOrLoseLabel.gameObject.SetActive(true);
        WinOrLoseLabel.text = text;
    }

    private void BlockButtons()
    {
        Button1.gameObject.SetActive(false);
        Button2.gameObject.SetActive(false);
        Button3.gameObject.SetActive(false);
        Button4.gameObject.SetActive(false);
        Button5.gameObject.SetActive(false);
        Button6.gameObject.SetActive(false);
        Button7.gameObject.SetActive(false);
        Button8.gameObject.SetActive(false);
        Button9.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}