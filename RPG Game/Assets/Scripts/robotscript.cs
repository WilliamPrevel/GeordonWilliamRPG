using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotscript : RoamingEnemyScript {
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();
        transform.LookAt(player.transform);
    }
}
//slow it down and make it always approach the player. autokill on hit.
//https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html