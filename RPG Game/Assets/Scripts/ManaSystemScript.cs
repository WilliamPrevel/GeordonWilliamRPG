using System;

public class ManaSystemScript
{


    public event EventHandler OnManaChanged;
    private int mana;
    private int manaMax;

    public ManaSystemScript(int manaMax)
    {
        this.manaMax = manaMax;
        mana = manaMax;
    }
    public int GetMana()
    {
        return mana;
    }

    public float GetManaPercent()
    {
        return mana / manaMax;
    }

    public void Drain(int drainAmount)
    {
        mana -= drainAmount;
        if (mana < 0) mana = 0;
        if (OnManaChanged != null) OnManaChanged(this, EventArgs.Empty);
    }

    public void HealMana(int healAmount)
    {
        mana += healAmount;
        if (mana > manaMax) mana = manaMax;
        if (OnManaChanged != null) OnManaChanged(this, EventArgs.Empty);
    }

}
