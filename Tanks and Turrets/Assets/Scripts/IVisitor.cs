using Player;
using Turrets;

public interface IVisitor
{ 
    public void Visit(Tank tank); 
    public void Visit(Turret turret);
}
