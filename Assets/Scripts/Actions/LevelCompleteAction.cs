using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCompleteAction : MonoBehaviour
{
    [SerializeField]
    private int difficultyLevel = 1;

    [SerializeField]
    private bool triggerAllLevels = false;

    [SerializeField]
    private MapController mapController;

    public UnityEvent OnLevelCompleteActions = new UnityEvent();

    private void Awake()
    {
        if (mapController == null)
        {
            mapController = FindObjectOfType<MapController>();
        }

        mapController.OnLevelFinished.AddListener(OnLevelComplete);
    }

    private void OnLevelComplete(int newLevel)
    {
        if (newLevel == difficultyLevel || triggerAllLevels)
            OnLevelCompleteActions?.Invoke();
    }
}
