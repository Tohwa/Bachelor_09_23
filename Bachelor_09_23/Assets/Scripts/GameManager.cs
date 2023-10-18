using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    public List<GameObject> fenceTargets = new();
    [SerializeField]
    public List<GameObject> sheepTargets = new();

    private Array foundFences;
    private Array foundSheep;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);

        foundFences = GameObject.FindGameObjectsWithTag("Fence");

        foreach (GameObject obj in foundFences)
        {
            fenceTargets.Add(obj);
        }

        foundSheep = GameObject.FindGameObjectsWithTag("Sheep");

        foreach (GameObject obj in foundSheep)
        {
            sheepTargets.Add(obj);
        }
    }
}
