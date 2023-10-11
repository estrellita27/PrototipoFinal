using SML.Simulation;
using Unity.Entities;
using UnityEngine;

namespace SML.Alien
{
    public class AlienAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;


        public void Convert(Entity newAlienEntity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {

            dstManager.AddComponentData(newAlienEntity, new MoveSpeed { Value = _moveSpeed });
            dstManager.AddComponentData(newAlienEntity, new RotationSpeed { Value = _rotationSpeed });

        }
    }
}