using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    int divider;
    int xpp;

    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
    }

    public void GainXP(BattleResultEventData data)
    {
        if (data.outcome > 0)
        {
            divider = Mathf.RoundToInt(data.outcome);
            divider = Mathf.Clamp(divider, -1, 1);
            xpp = 100 * divider;
            data.player.xp += xpp;

            GameEvents.PlayerXPGain(xpp);

            if (data.player.xp >= 1000)
            {
                data.player.level++;
                GameEvents.PlayerLevelUp(data.player.level);
                data.player.xp = 0;
            }


        }
    }

}
