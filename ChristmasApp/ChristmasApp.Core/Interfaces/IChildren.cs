using Rzucidlo.ChristmasApp.Core.Enums;

namespace Rzucidlo.ChristmasApp.Core.Interfaces;

public interface IChildren
{
    string Name { get; init; }

    int Age { get; init; }

    string Address { get; init; }

    ChildrenBehaviourType ChildrenBehaviourType { get; init; }
}