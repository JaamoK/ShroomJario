using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject PauseScreen;

    enum gameState
    {
        playing,
        win,
        pause
    }

    gameState currentstate = gameState.playing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StateControl(gameState.playing);
    }

    // Update is called once per frame

    public void WinState()
    {
        StateControl(gameState.win);
    }

    public void PauseState()
    {
        StateControl(gameState.pause);
    }

    void StateControl(gameState _newState)
    {
        currentstate = _newState;
        switch (currentstate)
        {
            case gameState.playing:
                WinScreen.SetActive(false);
                PauseScreen.SetActive(false);
                break;

            case gameState.win:
                WinScreen.SetActive(true);
                break;
            case gameState.pause:
                PauseScreen.SetActive(true);
                break;
        }
    }
}
