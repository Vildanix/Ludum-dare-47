using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private int mapDifficulty = 1;

    public UnityEvent<int> OnChangeMapDifficulty;
    public UnityEvent<int> OnLevelReset;
    public UnityEvent OnGameReset;
    public UnityEvent<int> OnLevelActivate;
    public UnityEvent<int> OnLevelFinished;
    public UnityEvent OnGameFinished;

    [SerializeField]
    private bool debugMapChage = false;

    [SerializeField]
    private bool debugMapRestart = false;

    [SerializeField]
    private bool debugGameRestart = false;

    [SerializeField]
    private bool debugGameLevelFinished = false;

    [SerializeField]
    private bool debugGameFinished = false;

    public void TriggerMapChange()
    {
        mapDifficulty++;
        OnChangeMapDifficulty?.Invoke(mapDifficulty);

        TriggerLevelReady();
    }

    public void TriggerLevelReset() {
        OnLevelReset?.Invoke(mapDifficulty);

        TriggerLevelReady();
    }

    public void TriggerGameReset()
    {
        mapDifficulty = 1;
        OnGameReset?.Invoke();

        TriggerLevelReady();
    }

    public void TriggerLevelReady()
    {
        OnLevelActivate?.Invoke(mapDifficulty);
    }

    public void TriggerLevelFinished()
    {
        OnLevelFinished?.Invoke(mapDifficulty);

        TriggerMapChange();
    }

    public void TriggerGameFinished()
    {
        OnGameFinished?.Invoke();
    }

    // debugging code - delete before publishing
    private void Update()
    {
        if (debugMapChage)
        {
            debugMapChage = false;
            TriggerMapChange();
        }

        if (debugMapRestart)
        {
            debugMapRestart = false;
            TriggerLevelReset();
        }

        if (debugGameRestart)
        {
            debugGameRestart = false;
            TriggerGameReset();
        }

        if (debugGameLevelFinished)
        {
            debugGameLevelFinished = false;
            TriggerLevelFinished();
        }

        if (debugGameFinished)
        {
            debugGameFinished = false;
            TriggerGameFinished();
        }
    }

    // initial start of the game oafter all elements are hooked into events
    private void Start()
    {
        TriggerGameReset();
    }
}
