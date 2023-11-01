using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SML.Alien
{
    public partial class SpawnAlienSystem : SystemBase
    {
        private BeginInitializationEntityCommandBufferSystem _ecbSystem;
        private const int MAX_TRIES = 16;
        private float _camSizeSq;
        private Transform _cameraTransform;

        protected override void OnStartRunning()
        {
            _ecbSystem = World.GetExistingSystem<BeginInitializationEntityCommandBufferSystem>();

            var camCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            _cameraTransform = Camera.main.transform;
            _camSizeSq = math.distancesq(_cameraTransform.position, camCorner);


        }
        protected override void OnUpdate()
        {
            var cameraPosition = (float3)_cameraTransform.position;
            cameraPosition.y = 0f;

            new SpawnEnemiesJob
            {
                DeltaTime = Time.DeltaTime,
                ECB = _ecbSystem.CreateCommandBuffer(),
                MaxTries = MAX_TRIES,
                CamSizeSq = _camSizeSq,
                CameraPosition = cameraPosition
            }.Run();
        }
    }

#pragma warning disable CS0282
    [BurstCompile]
    public partial struct SpawnEnemiesJob : IJobEntity
    {
        public float DeltaTime;
        public EntityCommandBuffer ECB;
        public int MaxTries;
        public float CamSizeSq;
        public float3 CameraPosition;

        private void Execute(ref AlienSpawnTimer spawnTimer, ref EntityRandom random, in SpawnPointReference spawnPoints,
            in AlienPrefab alienPrefab)
        {
            spawnTimer.Value -= DeltaTime;
            if (spawnTimer.Value > 0f) return;
            spawnTimer.Value = spawnTimer.Interval;

            var newRomano = ECB.Instantiate(alienPrefab.Value);
            float3 spawnPoint;
            var numTries = 0;
            do
            {
                numTries++;
                var randomIndex = random.Value.NextInt(spawnPoints.Length);
                spawnPoint = spawnPoints[randomIndex];
            } while (math.distancesq(spawnPoint, CameraPosition) < CamSizeSq && numTries < MaxTries);
            ECB.SetComponent(newRomano, new Translation { Value = spawnPoint });
        }
    }
}

