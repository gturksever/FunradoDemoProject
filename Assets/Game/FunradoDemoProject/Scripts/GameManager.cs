using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BlueDoorBlocker;
    public GameObject BlueKey;


    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }

    }

    private bool _doesMove = false;
    public bool DoesMove
    {
        get { return _doesMove; }
        set { _doesMove = value; }
    }

    private bool _interactionEnemy = false;
    public bool InteractionEnemy
    {
        get { return _interactionEnemy; }
        set { _interactionEnemy = value; }
    }

    private bool _canKill = false;
    public bool CanKill
    {
        get { return _canKill; }
        set { _canKill = value; }
    }

    private bool _gameOver = false;
    public bool GameOver
    {
        get { return _gameOver; }
        set { _gameOver = value; }
    }

    private bool _hasUpgraded = false;
    public bool HasUpgraded
    {
        get { return _hasUpgraded; }
        set { _hasUpgraded = value; }
    }

    private bool _levelDone = false;
    public bool LevelDone
    {
        get { return _levelDone; }
        set { _levelDone = value; }
    }

    
}

   
