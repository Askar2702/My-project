using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameState GameState { get; private set; }
    [SerializeField] private RectTransform _panelStart;
    [SerializeField] private RectTransform _PanelFinish;
    private void Awake()
    {
        if (!instance) instance = this;
    }
    private void Start()
    {
        GameState = GameState.Stop;
    }
    public void StartGame()
    {
        GameState = GameState.Play;
        _panelStart.DOAnchorPos(new Vector2(0, 2000f), 1f);
    }

    public void FinishGame()
    {
        GameState = GameState.Stop;
        _PanelFinish.DOAnchorPos(new Vector2(0, 0f), 1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
   
}
public enum GameState { Play , Stop}
