using System.Collections.Generic;

namespace Game
{
    public class GameWorld
    {
        private Dictionary<int, GameWorldPoint> _worldPoints;

        public GameWorld()
        {
            _worldPoints = new Dictionary<int, GameWorldPoint>();
        }

        public GameWorldPoint GetPoint(int pointId)
        {
            GameWorldPoint point;
            return _worldPoints.TryGetValue(pointId, out point) ? point : null;
        }

        public void SetPoint(int pointId, GameWorldPoint gameWorldPoint)
        {
            _worldPoints.Add(pointId, gameWorldPoint);
        }
    }
}