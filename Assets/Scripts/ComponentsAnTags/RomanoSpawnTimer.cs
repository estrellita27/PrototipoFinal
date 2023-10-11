using Unity.Entities;
using Unity.Mathematics; 

namespace SML.Simulation
{
    public struct RomanoSpawnTimer : IComponentData
    {
        public float Value;
        public float Interval;
    }
    public struct RomanoPrefab : IComponentData
    {
        public Entity Value;  
    }
    public struct EntityRandom : IComponentData
    {
        public Random Value;
    }
}
   
