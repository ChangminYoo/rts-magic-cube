using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase
{
	[SerializeField] private Transform propLeftPosition;    // 왼손 장착 위치
	[SerializeField] private Transform propRightPosition;   // 오른손 장착 위치
	[SerializeField] private Transform propHeadPosition;	// 모자 장착 위치

    /// <summary>
    /// 생성 시 캐릭터 초기화
    /// </summary>
    public abstract void Initialize();
    
    /// <summary>
    /// 장비 장착
    /// </summary>
    public abstract void Equip();
    
    /// <summary>
    /// 장비 해제
    /// </summary>
    public abstract void UnEquip();

}
