using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelDeactivateAction : MonoBehaviour
{
    [SerializeField]
    private int difficultyLevel = 1;

    [SerializeField]
    private MapController mapController;

    public UnityEvent OnLevelDeactivateActions = new UnityEvent();

    private void Awake()
    {
        if (mapController == null)
        {
            mapController = FindObjectOfType<MapController>();
        }

        mapController.OnChangeMapDifficulty.AddListener(OnLevelDeactivate);
    }

    private void OnLevelDeactivate(int newLevel)
    {
        if (newLevel == difficultyLevel + 1)
            OnLevelDeactivateActions?.Invoke();
    }
}
