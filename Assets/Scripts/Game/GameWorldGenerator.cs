using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using Networking.Data;
using UnityEngine;

namespace Match
{
    public class GameWorldGenerator : MonoBehaviour
    {
        // SO_WorldGeneratorConfig here
        
        public GameWorld GenerateGameWorldFromSnapshot(MatchDataState matchDataState)
        {
            GameWorld gameWorld = new GameWorld();
            
            for (int i = 0; i < matchDataState.Room.GameWorld.Size; i++)
            {
                var point = CreateWorldPoint(i, matchDataState.Room.GameWorld.Points[i.ToString()]);
                gameWorld.SetPoint(i, point);
            }

            return gameWorld;
        }

        private GameWorldPoint CreateWorldPoint(int pointId, MatchDataWorldPoint worldPoint)
        {
            var go = new GameObject($"Point_{pointId}");
            var component = go.AddComponent<GameWorldPoint>();
            component.PointData = worldPoint;
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(worldPoint.Position.X, 0, worldPoint.Position.Y);
            return component;
        }
    }
}