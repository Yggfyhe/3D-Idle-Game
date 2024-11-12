using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{
    [field:SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; set; } = 5f;
    [field: SerializeField][field: Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f;

    [field:Header("���Ļ���")]

    [field: Header("�ȴ»���")]
    [field: SerializeField][field: Range(0f,2f)] public float WalkSpeedModifier { get; private set; } = 0.225f;
    

    [field: Header("�ٴ»���")]
    [field: SerializeField][field: Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f;

}

[Serializable]
public class PlayerAirData
{
    [field: Header("��������")]
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; private set; } = 5f;



}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
}
