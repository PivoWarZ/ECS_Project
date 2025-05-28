using UnityEngine;
using System;

namespace ECSEngine.Components
{
    [Serializable]
    public struct Position
    {
        public Vector3 Value;
    }
    
    [Serializable]
    public struct Rotation
    {
        public Quaternion Value;
    }
    
    [Serializable]
    public struct MoveSpeed
    {
        public float Value;
    }
    
    [Serializable]
    public struct MoveDirection
    {
        public Vector2 Value;
    }
}