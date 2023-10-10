using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SML.Simulation
{
    public partial class SpawnRomanoSystem : SystemBase
    {
        private int2 _entitySpacing;
        
        protected override void OnStartRunning()
        {
            var romanoSpawnData = GetSingleton<SpawnRomanoData>();
            var gridSize = romanoSpawnData.SpawnGrid;
            _entitySpacing = romanoSpawnData.EntitySpacing;

            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    var newEntity = EntityManager.Instantiate(romanoSpawnData.EntityPrefab);
                    
                    var newPosition = new LocalToWorld {Value = CalculateTransform(x, y)};

                    EntityManager.SetComponentData(newEntity, newPosition);

                    
                }
            }
        }

        private float4x4 CalculateTransform(int x, int y)
        {
            return float4x4.Translate(new float3
            {
                x = x * _entitySpacing.x,
                y = 1f,
                z = y * _entitySpacing.y
            });
        }

        protected override void OnUpdate()
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                EntityManager.DestroyAndResetAllEntities();
            }
        }
    }
}