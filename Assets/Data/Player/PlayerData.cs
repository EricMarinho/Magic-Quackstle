using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player", order = 0)]
public class PlayerData : ScriptableObject
{
    [Header("General")]
    public float _walkSpeed;
    public float _runSpeed;
    public float _jumpForce;
    public MinMax _blinkTime;
    public float _blinkDuration;

    [Header("3D")]
    public float _rotateSpeed;
    public float _mouseSensibility;
   
}