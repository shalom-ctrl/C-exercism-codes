using System;

abstract class Character
{
    private readonly string _characterType;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    // Task 5 & 6: Must be implemented by specific classes
    public abstract int DamagePoints(Character target);

    // Task 2: Default behavior is not vulnerable
    public virtual bool Vulnerable() => false;

    // Task 1: Custom description
    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior : Character
{
    // Pass "Warrior" to the base constructor
    public Warrior() : base("Warrior") { }

    // Task 6: Damage logic for Warrior
    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _spellPrepared = false;

    // Pass "Wizard" to the base constructor
    public Wizard() : base("Wizard") { }

    // Task 3: Prepare the spell
    public void PrepareSpell() => _spellPrepared = true;

    // Task 4: Override vulnerability (Wizards are weak without a spell)
    public override bool Vulnerable() => !_spellPrepared;

    // Task 5: Damage logic for Wizard
    public override int DamagePoints(Character target)
    {
        return _spellPrepared ? 12 : 3;
    }
}