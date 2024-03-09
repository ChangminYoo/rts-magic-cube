using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase
{
	protected Transform propLeftTransform;    // 왼손 장착 위치
	protected Transform propRightTransform;   // 오른손 장착 위치
	protected Transform propHeadTransform;   // 모자 장착 위치

	protected readonly string LEFT_DUMMPY_POSITION = "RigPelvis/RigSpine1/RigSpine2/RigRibcage/RigLArm1/RigLArm2/RigLArmPalm/Dummy Prop Left";
	protected readonly string RIGHT_DUMMPY_POSITION = "RigPelvis/RigSpine1/RigSpine2/RigRibcage/RigRArm1/RigRArm2/RigRArmPalm/Dummy Prop Right";

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
