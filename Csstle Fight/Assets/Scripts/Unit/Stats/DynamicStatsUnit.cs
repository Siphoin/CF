using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public   class DynamicStatsUnit
    {
     public ulong currentDamage;
    public long currentHitPoints;
    public long currentManaPoints;
    public float currentSpeedAttack;
    public float currentSpeedMovement;

    public DynamicStatsUnit ()
    {

    }

    public DynamicStatsUnit (StatsUnit statsUnit)
    {
        if (statsUnit == null)
        {
            throw new DynamicStatsUnitException("stats unit argument is null");
        }

        currentDamage = statsUnit.Damage;
        currentHitPoints = (long)statsUnit.StartHitPoints;
        currentManaPoints = (long)statsUnit.StartManaPoints;
        currentSpeedAttack = statsUnit.SpeedAttack;
        currentSpeedMovement = statsUnit.SpeedMovement;
    }
}