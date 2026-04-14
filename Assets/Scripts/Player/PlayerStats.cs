using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public List<StatData> stats;
    [SerializeField] int BaseStatsValue;
    UIManager uIManager;

    void Awake()
    {
        ResetStats();
        uIManager = FindFirstObjectByType<UIManager>();
        uIManager.UpdateStats(stats);
    }

    void ResetStats()
    {
        foreach (StatData stat in stats)
        {
            stat.value = BaseStatsValue;
        }
    }

    public void AddStats(int amount, StatData.StatsType type)
    {
        for (int i = 0; i < stats.Count; i++)
        {
            if (stats[i].type == type)
            {
                stats[i].value += amount;
                break;
            }
        }
        uIManager.UpdateStats(stats);
    }

    public void ReduceStats(int amount, StatData.StatsType type)
    {
        for (int i = 0; i < stats.Count; i++)
        {
            if (stats[i].type == type)
            {
                stats[i].value -= amount;
                break;
            }
        }
        uIManager.UpdateStats(stats);
    }

    public StatData GetStatData(StatData.StatsType type)
    {
        foreach (StatData stat in stats)
        {
            if (stat.type == type)
            {
                return stat;
            }
        }
        return null;
    }
}
