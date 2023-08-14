using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _failedScreen;
    [SerializeField] private GameObject _finishScreen;
    
    [SerializeField] private GameObject _playerLevelUI;
    private TextMeshProUGUI _playerLevelText;
    public static int playerLevel;
    
    [SerializeField] private GameObject _enemyLevelUI;
    private TextMeshProUGUI _enemyLevelText;
    public static int enemyLevel;

    private string _previousPlayerLevel;


    private void Start()
    {
        _playerLevelText = _playerLevelUI.GetComponent<TextMeshProUGUI>();
        _enemyLevelText = _enemyLevelUI.GetComponent<TextMeshProUGUI>();
        int.TryParse(_playerLevelText.text, out playerLevel);
        int.TryParse(_enemyLevelText.text, out enemyLevel);

        _previousPlayerLevel = _playerLevelText.text;
    }

    private void Update()
    {
        CheckPlayerLevelChange();

        if(GameManager.Instance.InteractionEnemy == true && GameManager.Instance.CanKill == true)
            _enemyLevelUI.SetActive(false);

        else if (GameManager.Instance.InteractionEnemy == true && GameManager.Instance.CanKill == false)
        {
            _playerLevelUI.SetActive(false);
            Invoke("GameOverInvoke", 1.5f);
            
        }

        if (GameManager.Instance.LevelDone)
        {
            _finishScreen.SetActive(true);
        }

            
        
    }

    private void CheckPlayerLevelChange() 
    {
        if (GameManager.Instance.HasUpgraded)
        {
            playerLevel= int.Parse(_playerLevelText.text)+3;
            _playerLevelText.text=playerLevel.ToString();
            GameManager.Instance.HasUpgraded = false;
        }
        
        
        
        if (_playerLevelText.text != _previousPlayerLevel)
        {
            int.TryParse(_playerLevelText.text, out playerLevel);
            _previousPlayerLevel = _playerLevelText.text;
        }
    }

    private void GameOverInvoke()
    {
        GameManager.Instance.GameOver = true;
        _failedScreen.SetActive(true);
    }


}
