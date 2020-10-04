using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameResetAction : MonoBehaviour
{
    [SerializeField]
    private MapController mapController;

    public UnityEvent OnGameResetActions = new UnityEvent();

    private void Awake()
    {
        if (mapController == null)
        {
            mapController = FindObjectOfType<MapController>();
        }

        mapController.OnGameReset.AddListener(OnGameReset);

    }

    private void OnGameReset()
    {
        OnGameResetActions?.Invoke();
    }
}
