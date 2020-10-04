using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelResetAction : MonoBehaviour
{
    [SerializeField]
    private int difficultyLevel = 1;

    [SerializeField]
    private bool triggerAllLevels = false;

    [SerializeField]
    private MapController mapController;

    public UnityEvent OnLevelResetActions = new UnityEvent();

    private void Awake()
    {
        if (mapController == null)
        {
            mapController = FindObjectOfType<MapController>();
        }

        mapController.OnLevelReset.AddListener(OnLevelReset);
    }

    private void OnLevelReset(int newLevel)
    {
        if (newLevel == difficultyLevel || triggerAllLevels)
            OnLevelResetActions?.Invoke();
    }
}
