using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }

    public const string HIGHSCORE_KEY = "HighScore";

    [SerializeField]
    private int _playerScore = 0;
    public int PlayerScore
    {
        get => _playerScore;
        private set => _playerScore = value;
    }

    public UnityEvent OnScoreChanged;

    [SerializeField] private TextMeshProUGUI _currentScoreTxt;
    [SerializeField] private TextMeshProUGUI _bestScoreTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _bestScoreTxt.text = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0).ToString();
        TryUpdateHighScore();
    }

    public void UpdateScore()
    {
        PlayerScore++;
        _currentScoreTxt.text = PlayerScore.ToString();
        OnScoreChanged?.Invoke();
        TryUpdateHighScore();
    }

    public void TryUpdateHighScore()
    {
        if(PlayerScore > PlayerPrefs.GetInt(HIGHSCORE_KEY))
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, PlayerScore);
            _bestScoreTxt.text = PlayerScore.ToString();
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Reset Player Prefs"))
        {
            PlayerPrefs.DeleteAll();
        }

        GUILayout.EndHorizontal();
    }


}
