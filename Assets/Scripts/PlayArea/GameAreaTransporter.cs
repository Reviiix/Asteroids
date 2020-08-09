﻿using UnityEngine;

namespace PlayArea
{
    public class GameAreaTransporter 
    {
        public static void MoveToScreenEdge(Transform player, ScreenEdge edge)
        {
            var position = player.position;
            switch (edge)
            {
                case ScreenEdge.Top:
                case ScreenEdge.Bottom:
                    position  = new UnityEngine.Vector3(position.x, -position.y, position.z);
                    player.position = position;
                    break;
                case ScreenEdge.Left:
                case ScreenEdge.Right:
                    position  = new UnityEngine.Vector3(-position.x, position.y, position.z);
                    player.position = position;
                    break;
                default:
                    Debug.LogError("There is no screen edge associated with: " + edge + ". Player has been deposited at the bottom of the screen.");
                    MoveToScreenEdge(player, ScreenEdge.Bottom);
                    break;
            }
        }
        
    }
}