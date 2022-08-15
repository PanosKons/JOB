public struct Unit
{
    public Unit(int Health,int MaxHealth,int Attack)
    {
        this.Health = Health;
        this.MaxHealth = MaxHealth;
        this.Attack = Attack;
    }
    public int Health;
    public int MaxHealth;
    public int Attack;
}
public struct Character
{
    public Character(Unit unit, DataManager.EntityId Id)
    {
        this.Id = Id;
        this.unit = unit;
    }
    public DataManager.EntityId Id;
    public Unit unit;
}