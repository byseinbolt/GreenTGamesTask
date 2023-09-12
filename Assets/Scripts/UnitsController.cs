using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

public class UnitsController : IInitializable, IDisposable
{
    private readonly UnitsCreator _unitsCreator;
    private readonly CompositeDisposable _subscriptions;
    private IEnumerable<GameUnit> _units;

    public UnitsController(UnitsCreator unitsCreator)
    {
        _unitsCreator = unitsCreator;
        _subscriptions = new CompositeDisposable();
    }

    public void Initialize()
    {
        _units = _unitsCreator.GetUnits();

        Debug.Log("<color=red><b>Task 4</b></color>");

        var streams = _units.Select(unit => unit.Health);
        streams
            .Merge()
            .Subscribe(value => Debug.Log(value))
            .AddTo(_subscriptions);

        Debug.Log("<color=red><b>Task 5</b></color>");

        var stream = Observable.Return(_units);

        stream
            .Select(collection => collection.Select(unit => unit.Health).Merge())
            .Switch()
            .Subscribe(value => Debug.Log(value))
            .AddTo(_subscriptions);

        Debug.Log("<color=red><b>Task 6</b></color>");

        var observable = stream
            .Select(collection => collection.Where(unit => unit.Health.Value > 2))
            .Where(collection => collection.Any());

        observable
            .Select(collection => collection.Select(unit => unit.Health).Merge())
            .Switch()
            .Subscribe(hp => Debug.Log($" HP: {hp}"))
            .AddTo(_subscriptions);
    }

    public void Dispose()
    {
        Debug.Log("Dispose");
        _subscriptions?.Dispose();

    }
}
