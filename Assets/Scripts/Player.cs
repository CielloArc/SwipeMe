using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int comboStreak = 1;
    private int lastPrefabCollectedID = -1;
    private const int point = 1;

    void Update()
    {
        CanvasManager.instance.setComboStreakText(comboStreak);
        //Debug.Log("ComboStreak: " + comboStreak);
    }

    void OnCollect(int prefabID)
    {
        if (prefabID == lastPrefabCollectedID || prefabID == 0)
        {
            comboStreak++;
            CanvasManager.instance.InstantiateFloatingObject(1, transform);
        }
        else
        {
            comboStreak = 1;
            CanvasManager.instance.InstantiateFloatingObject(2, transform);
        }

        ScoreManager.instance.UpdateScore(point * comboStreak);
        lastPrefabCollectedID = prefabID;
    }

    void Die()
    {
        gameObject.SetActive(false);
        GameManager.instance.EndGame();
    }
}
