using System.Collections.Generic;
using UnityEngine;

public class UnitsCreator
{
    private readonly GameUnit.UnitsFactory _unitsFactory;

    public UnitsCreator(GameUnit.UnitsFactory unitsFactory)
    {
        _unitsFactory = unitsFactory;
    }

    // Для упрощения использую "Magic numbers"
    // В боевой задаче их быть не должно; Передавать либо через конструктор, либо через какой-либо конфиг
    public List<GameUnit> GetUnits()
    {
        var amount = 5;
        var units = new List<GameUnit>();
        for (var i = 0; i < amount; i++)
        {
            var randomHealth = Random.Range(1, 4);
            units.Add(_unitsFactory.Create(randomHealth));
        }

        return units;
    }
}