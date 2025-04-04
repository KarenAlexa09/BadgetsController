using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResultsModel
{
    [SerializeField] private List<PlayerResult> playersResults = new List<PlayerResult>();

    public ResultsModel()
    {
        CleanResults();
    }

    public void CleanResults()
    {
        playersResults.Clear();
    }

    public void AddResult(PlayerResult result)
    {
        playersResults.Add(result);
    }

    public List<PlayerResult> GetResults()
    {
        return playersResults;
    }
}

[Serializable]
public class PlayerResult
{
    [SerializeField] private PlayerEntity playerEntity;
    [SerializeField] private List<Badget> badges = new List<Badget>();

    public PlayerEntity PlayerEntity { get { return playerEntity; } }

    public List<Badget> Badgets
    {
        get => badges;
        set => badges = value;
    }
}