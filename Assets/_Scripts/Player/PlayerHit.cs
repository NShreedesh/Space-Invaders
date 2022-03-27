using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Hit
{
    public override void TakeDamage()
    {
        base.TakeDamage();
        HealthManager.Instance.UpdateHealth();
    }
}
