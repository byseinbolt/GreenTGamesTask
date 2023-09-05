using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

public class UnitsController : IInitializable
{
    [Inject]
    private List<GameUnit> _gameUnits = new();
    
    public void Initialize()
    {
        //4.1
        var streams = _gameUnits.Select(gameUnit => Observable.Range(1,gameUnit.Health)).ToList();
        
        //4.2
        streams.Merge().Subscribe(value => Debug.Log(value));

        // 5.1
        var stream = GetUnitsStream();

        //5.2
        var gameUnitsStreams = stream.SelectMany(gameUnits => gameUnits.ToObservable());

        // 5.3,5.4
        gameUnitsStreams.Subscribe(gameUnit =>
        {
            Observable.Return(gameUnit.Health)
                .Subscribe(value => Debug.Log($"{gameUnit.Name} - {value}"))
                .Dispose();
        });

        //6.1
        var filteredStream = stream
            .Select(models => models
                .Where(model => model.Health > 2));
        
        //6.2,6.3
        filteredStream.Where(models => models.Count() >= 2)
            .Subscribe(models =>
            {
                foreach (var model in models)
                {
                    Debug.Log($"{model.Name} - {model.Health}");
                }
            });
    }

    private IObservable<IEnumerable<GameUnit>> GetUnitsStream()
    {
        return Observable.Return(_gameUnits);
    }
}