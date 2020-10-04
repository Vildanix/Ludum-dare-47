using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelActivateAction : MonoBehaviour
{
    [SerializeField]
    private int difficultyLevel = 1;

    [SerializeField]
    private bool triggerAllLevels = false;

    [SerializeField]
    private MapController mapController;

    public UnityEvent OnLevelActivateActions = new UnityEvent();

    private void Awake()
    {
        if (mapController == null)
        {
            mapController = FindObjectOfType<MapController>();
        }

        mapController.OnLevelActivate.AddListener(OnLevelActivate);
    }

    private void OnLevelActivate(int newLevel)
    {
        if (newLevel == difficultyLevel || triggerAllLevels)
            OnLevelActivateActions?.Invoke();
    }
}
