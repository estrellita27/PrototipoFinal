using SML.Simulation; // (o el espacio de nombres correcto)
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace SML.Simulation
{
    public class SpawnerRomanoAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        [SerializeField] private float _spawnInterval;
        [SerializeField] private GameObject _romanoPrefab;

       
        public void Convert(Entity spawnerEntity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var spawnTransforms = transform.GetComponentsInChildren<Transform>();

            using var blobBuilder = new BlobBuilder(Allocator.Temp);
            ref var spawnPointArray = ref blobBuilder.ConstructRoot<SpawnPointArray>();
            var blobArray = blobBuilder.Allocate(ref spawnPointArray.Value, spawnTransforms.Length);

            for (var i = 0; i < spawnTransforms.Length; i++)
            {
                blobArray[i] = new SpawnPoint { Value = spawnTransforms[i].position };
            }

            var spawnPointReference = blobBuilder.CreateBlobAssetReference<SpawnPointArray>(Allocator.Persistent);
            dstManager.AddComponentData(spawnerEntity, new SpawnPointReference { Value = spawnPointReference });

            dstManager.AddComponentData(spawnerEntity, new SpawnTimer
            {
                Value = 0f,
                Interval = _spawnInterval

            });
            var romanoEntityPrefab = conversionSystem.GetPrimaryEntity(_romanoPrefab);
            dstManager.AddComponentData(spawnerEntity, new RomanoPrefab { Value = romanoEntityPrefab });

            var randomSeed = (uint)System.DateTime.Now.Millisecond;
            dstManager.AddComponentData(spawnerEntity, new EntityRandom { Value = Random.CreateFromIndex(randomSeed) });



        }
        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            
            referencedPrefabs.Add(_romanoPrefab);
        }

    }


    public struct SpawnPoint
    {
        public float3 Value;
    }

    public struct SpawnPointArray
    {
        public BlobArray<SpawnPoint> Value;
    }

    public struct SpawnPointReference : IComponentData
    {
        public BlobAssetReference<SpawnPointArray> Value;

        public int Length => Value.Value.Value.Length;

        public float3 this[int i] => Value.Value.Value[i].Value;
    }

}

