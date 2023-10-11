using Unity.Entities;
using Unity.Mathematics; 

namespace SML.Alien
{
    public struct AlienSpawnTimer : IComponentData
    {
        public float Value;
        public float Interval;
    }
    public struct AlienPrefab : IComponentData
    {
        public Entity Value;  
    }
    public struct EntityRandom : IComponentData
    {
        public Random Value;
    }
}
   
