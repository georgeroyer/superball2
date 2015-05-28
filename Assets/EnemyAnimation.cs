using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {
	public float deadZone = 5f;

	private Transform player;
	private EnemySight enemySight;
	private NavMeshAgent nav;
}
