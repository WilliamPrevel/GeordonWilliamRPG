using System;

public class HealthSystemScript {


    public event EventHandler OnHealthChanged;
    private int health;
    private int healthMax;
    
    public HealthSystemScript(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }
    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return health / healthMax;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

}
