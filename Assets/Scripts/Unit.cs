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
    public Character(int Health, int MaxHealth, int Attack, DataManager.EntityId Id)
    {
        this.Id = Id;
        unit = new Unit(Health, MaxHealth, Attack);
    }
    public DataManager.EntityId Id;
    public Unit unit;
}