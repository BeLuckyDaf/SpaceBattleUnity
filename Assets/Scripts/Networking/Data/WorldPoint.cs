namespace Networking.Data
{
    public struct WorldPoint
    {
        public int LocType;
        public string OwnerUID;
        public WorldPointPosition Position;
        public int[] Adjacent;
    }
}