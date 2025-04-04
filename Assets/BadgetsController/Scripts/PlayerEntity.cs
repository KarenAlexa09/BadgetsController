using System;
using UnityEngine;

[Serializable]
public class PlayerEntity
{
    [SerializeField] private PlayerType playerType;
    [SerializeField] private int score;
    [SerializeField] private int enemiesEliminated;

    public PlayerType PlayerType => playerType;
    public int Score => score;
    public int EnemiesEliminated => enemiesEliminated;
}
