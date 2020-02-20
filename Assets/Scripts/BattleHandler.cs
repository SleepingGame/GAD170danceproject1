using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data /* IN HERE YOU ADDED SHIT THAT YOU SHOULD NOT HAVE ADDED THAT IS WHY THE ERROR KEPT ON COMING UP i am sorry ( its ok XDDD */)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player




        float outcome = Random.Range(-1.0f, (data.player.luck * Random.Range(-1, data.player.luck)) + (1 / (data.player.rhythm * data.player.style + 1)) + 1);

        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);
        Debug.Log(outcome);
    }
}

