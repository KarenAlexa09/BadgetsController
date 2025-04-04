using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text PlayerNameTxt;
    [SerializeField] private TMP_Text PlayerScoreTxt;
    [SerializeField] private TMP_Text PlayerEnemiesEliminatedTxt;
    [SerializeField] private BadgetImagePair[] Badgets;

    public void Initialize(PlayerResult playerResult)
    {
        PlayerNameTxt.text = playerResult.PlayerEntity.PlayerType.ToString();

        PlayerScoreTxt.text = playerResult.PlayerEntity.Score.ToString();

        PlayerEnemiesEliminatedTxt.text = playerResult.PlayerEntity.EnemiesEliminated.ToString();

        SetBadgets(playerResult.Badgets);
    }

    private void SetBadgets(List<Badget> badgets)
    {
        foreach (var pair in Badgets)
        {
            if (pair.image != null)
                pair.image.gameObject.SetActive(false);
        }

        foreach (var badge in badgets)
        {
            var found = false;
            foreach (var pair in Badgets)
            {
                if (pair.badgetType == badge.badgetType && pair.image != null)
                {
                    pair.image.sprite = badge.badgeImage;
                    pair.image.gameObject.SetActive(true);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Debug.LogWarning($"[TestUIView] No image found for badge type: {badge.badgetType} in '{name}'");
            }
        }
    }

    [Serializable]
    private class BadgetImagePair
    {
        public BadgetType badgetType;
        public Image image;
    }
}
