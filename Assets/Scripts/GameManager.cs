using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public Player player = null;
    public LineRenderComponent lineRenderer;
    public MessageGameOverComponent gameOverMessage = null;
    public MessageQuitComponent quitMessage = null; 
    [SerializeField]
    private TimeComponent time = null;
    
    private bool playerIsMoving = false;
    public bool PlayerIsMoving
    {
        get => playerIsMoving;
        set => playerIsMoving = value;
    }

    private bool gameIsOver = false;
    public bool GameIsOver
    {
        get => gameIsOver;
        set => gameIsOver = value;
    }
    
    private bool lineIsDrew = false;
    public bool LineIsDrew
    {
        get => lineIsDrew;
        set => lineIsDrew = value;
    }
    
    private bool drawingIsStarted = false;
    public bool DrawingIsStarted
    {
        get => drawingIsStarted;
        set => drawingIsStarted = value;
    }
    
    private void Awake()
    {
        instance = this;
    }

    public void ResetGame()
    {
        
        drawingIsStarted = false;
        playerIsMoving = false;
        lineIsDrew = false;
        gameIsOver = false;
        
        player.ResetPlayer();
        time.ResetTimeCounter();
        StartCouting();
    }

    public void SetResult()
    {
        gameOverMessage.SetResultInMessage(time.GetText());
    }

    public void StartCouting()
    {
        time.StartCounting();
    }

    public void StopCouting()
    {
        time.StopCouting();
    }

    public void GameOver()
    {
        SetResult();
        gameOverMessage.Show();
        GameIsOver = true;
        StopCouting();
    }

    public void ShowExitMessage()
    {
        quitMessage.Show();
    }
    
}
