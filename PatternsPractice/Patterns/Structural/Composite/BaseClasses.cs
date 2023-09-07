using System.Collections;

namespace PatternsPractice.Patterns.Structural.Composite;

public abstract class Component
{
    public abstract string GetInfo();
    public virtual bool GetAsComposite(out Composite? composite)
        => (composite = null) != null;
    public abstract void Visit(IBuildingVisitor visiter);
}

public abstract class Composite : Component
{
    public abstract void Add(Component component);
    public abstract void Remove(Component component);
    public abstract Component GetChild(int index);

    public override bool GetAsComposite(out Composite? composite)
        => (composite = this) != null;
}
