﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBarScript : MonoBehaviour
{

    private ManaSystemScript manaSystem;

    public void SetUp(ManaSystemScript manaSystem)
    {
        this.manaSystem = manaSystem;

        manaSystem.OnManaChanged += ManaSystem_OnManaChanged;
    }

    private void ManaSystem_OnManaChanged(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(manaSystem.GetManaPercent(), 1);
    }
    private void Update()
    {

    }
}
