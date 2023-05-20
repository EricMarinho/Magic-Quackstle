using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData3D", menuName = "Data/Player/3D", order = 0)]
public class PlayerData3D : ScriptableObject
{
    public float _speed;
    public float _rotateSpeed;
    public float _mouseSensibility;
    public float _jumpForce;
}