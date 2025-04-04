using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BadgetsController : MonoBehaviour
{
    [SerializeField] private BadgetsModel badgets;

    private ResultsModel resultsModel;
    private List<PlayerResult> players;

    public void Initialize(ResultsModel _resultsModel)
    {
        players = _resultsModel.GetResults();
        resultsModel = _resultsModel;
    }

    public void AssignBadges()
    {
        if (players.Count <= 1)
            return;

        var topPlayers = new List<(BadgetType badgeType, PlayerEntity player)>();

        foreach (var badget in badgets.BadgetList)
        {
            PlayerEntity bestPlayer = GetTopPlayerByStat(badget.badgetType);

            if (bestPlayer != null)
            {
                topPlayers.Add((badget.badgetType, bestPlayer));
            }
        }

        foreach (var (badgeType, player) in topPlayers)
        {
            AssignBadgeToPlayer(player, badgeType);
        }
    }

    private PlayerEntity GetTopPlayerByStat(BadgetType badgetType)
    {
        PlayerEntity topPlayer = null;

        int highestValue = -1;

        int statValue;

        foreach (var player in players)
        {
            statValue = GetStatValue(badgetType, player.PlayerEntity);

            if (statValue > highestValue)
            {
                highestValue = statValue;
                topPlayer = player.PlayerEntity;
            }
        }

        return highestValue > 0 ? topPlayer : null;
    }

    private int GetStatValue(BadgetType badgetType, PlayerEntity player)
    {
        int statValue = 0;

        switch (badgetType)
        {
            case BadgetType.BestScore:
                statValue = player.Score;
                break;
            case BadgetType.MoreEnemysDeleted:
                statValue = player.EnemiesEliminated;
                break;
            default:
                break;
        }

        return statValue;
    }

    private void AssignBadgeToPlayer(PlayerEntity player, BadgetType badgeType)
    {
        Badget badget = badgets.BadgetList.Find(b => b.badgetType == badgeType);

        if (badget != null)
        {
            Debug.Log($"{player.PlayerType} has received the badge {badget.badgetType}");

            resultsModel.GetResults()
                .FirstOrDefault(p => p.PlayerEntity.PlayerType == player.PlayerType)?
                .Badgets.Add(badget);
        }
    }
}
