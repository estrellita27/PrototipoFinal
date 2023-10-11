using SML.Simulation;
using Unity.Entities;
using UnityEngine;

namespace SML.Simulation
{
    public class RomanoAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;


        public void Convert(Entity newRomanoEntity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {

            dstManager.AddComponentData(newRomanoEntity, new MoveSpeed { Value = _moveSpeed });
            dstManager.AddComponentData(newRomanoEntity, new RotationSpeed { Value = _rotationSpeed });

        }
    }
}