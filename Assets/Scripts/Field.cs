using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public static Field instance;
    [SerializeField] Cell[] _cells;
    [SerializeField] Text _text;
    [SerializeField] GameObject _gameObjectBlock;
    private void Awake()
    {
        instance = this;
    }
    public bool CheackCels()
    {
        var hasEmpty = false;
        foreach (var cell in _cells)
        {
            if (cell.state == cellState.empty)
            {
                hasEmpty = true;
                break;
            }
        }
        if (!hasEmpty)
        {
            GameOver(GameOverState.Draw);
            return hasEmpty;
        }
        if (_cells[0].state == _cells[1].state&& _cells[1].state == _cells[2].state)
        {
            switch (_cells[0].state)
            { 
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        if (_cells[3].state == _cells[4].state && _cells[4].state == _cells[5].state)
        {
            switch (_cells[3].state)
            {
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        if (_cells[6].state == _cells[7].state && _cells[7].state == _cells[8].state)
        {
            switch (_cells[6].state)
            {
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        if (_cells[0].state == _cells[3].state && _cells[3].state == _cells[6].state)
        {
            switch (_cells[0].state)
            {
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        if (_cells[1].state == _cells[4].state && _cells[4].state == _cells[7].state)
        {
            switch (_cells[1].state)
            {
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        if (_cells[2].state == _cells[5].state && _cells[5].state == _cells[8].state)
        {
            switch (_cells[2].state)
            {
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        if (_cells[0].state == _cells[4].state && _cells[4].state == _cells[8].state)
        {
            switch (_cells[0].state)
            {
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        if (_cells[6].state == _cells[4].state && _cells[4].state == _cells[2].state)
        {
            switch (_cells[6].state)
            {
                case cellState.cros:
                    GameOver(GameOverState.YouWin);
                    return false;
                case cellState.nught:
                    GameOver(GameOverState.YouLose);
                    return false;
            }
        }
        return hasEmpty;
    }
    public void EnemyTurn()
    {
        if (!CheackCels())
        {
            return;
        }
        var isTurned = false;
        do
        {
            var random = Random.Range(0, _cells.Length);
            if (_cells[random].state == cellState.empty)
            {
                _cells[random].SetCell(cellState.nught);
                break;
            }
        }
        while (true);
        CheackCels();
    }
    private void GameOver(GameOverState state)
    {
        switch (state)
        { 
            case GameOverState.Draw:
                _text.text = "Draw";
                break;
            case GameOverState.YouWin:
                _text.text = "You Win";
                break;
            case GameOverState.YouLose:
                _text.text = "You Lose";
                break;
        }
        _gameObjectBlock.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
public enum GameOverState 
{
    Draw,
    YouWin,
    YouLose
}
