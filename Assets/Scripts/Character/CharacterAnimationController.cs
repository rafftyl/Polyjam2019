﻿using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
	[SerializeField] private float animationSpeedMultiplier = 0.1f;
	[SerializeField] private float minAnimationSpeed = 0.0f;
	[SerializeField] private float maxAnimationSpeed = 2.0f;
	
	[SerializeField] private string walkSpeedKey = "speed";
	//[SerializeField] private string meleeModeKey = "isMelee";
	[SerializeField] private string meleeAttackTriggerKey = "meleeTrigger";
	[SerializeField] private string gunAttackTriggerKey = "gunTrigger";
	
	
	private new Rigidbody2D rigidbody2D = null;
	private Animator animator = null;
	
	private int walkSpeedHash;
	//private int meleeModeHash;
	private int meleeAttackTriggerHash;
	private int gunAttackTriggerHash;

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		walkSpeedHash = Animator.StringToHash(walkSpeedKey);
		//meleeModeHash = Animator.StringToHash(meleeModeKey);
		meleeAttackTriggerHash = Animator.StringToHash(meleeAttackTriggerKey);
		gunAttackTriggerHash = Animator.StringToHash(gunAttackTriggerKey);
		
		var combat = GetComponent<CombatComponent>();
		combat.OnShot += OnShot;
		combat.OnMeleeAttack += OnMeleeAttack;
	}

	private void OnMeleeAttack()
	{
		animator.SetTrigger(meleeAttackTriggerHash);
	}

	private void OnShot()
	{
		animator.SetTrigger(gunAttackTriggerHash);
	}
	
	void Update()
	{
		animator.SetFloat(walkSpeedHash, Mathf.Clamp(rigidbody2D.velocity.magnitude * animationSpeedMultiplier, minAnimationSpeed, maxAnimationSpeed));
	}
}
