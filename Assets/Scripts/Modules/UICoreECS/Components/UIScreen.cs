using Leopotam.Ecs;

namespace UICoreECS
{
    public struct UIScreen
    {
        public int Layer;
        public int ID;
        public bool Active;
        public ECSUIScreen Screen;

        public static void CustomReset(ref UIScreen c)
        {
            if(c.Screen != null) 
            {
                UnityEngine.GameObject.Destroy(c.Screen.gameObject);
            }
            c.ID = 0;
            c.Layer = 0;
            c.Active = false;
        }
    }
}