using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameFinishedAction : MonoBehaviour
{
    [SerializeField]
    private MapController mapController;

    public UnityEvent OnGameFinishedActions = new UnityEvent();

    private void Awake()
    {
        if (mapController == null)
        {
            mapController = FindObjectOfType<MapController>();
        }

        mapController.OnGameFinished.AddListener(OnGameFinished);
    }

    private void OnGameFinished()
    {
        OnGameFinishedActions?.Invoke();
    }
}
