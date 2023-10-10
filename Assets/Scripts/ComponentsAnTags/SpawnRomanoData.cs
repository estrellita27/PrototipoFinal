using Unity.Entities;
using Unity.Mathematics;

namespace SML.Simulation
{
    [GenerateAuthoringComponent]
    public class SpawnRomanoData : IComponentData
    {
        public Entity EntityPrefab;
        public int2 SpawnGrid;
        public int2 EntitySpacing;
    }
}

