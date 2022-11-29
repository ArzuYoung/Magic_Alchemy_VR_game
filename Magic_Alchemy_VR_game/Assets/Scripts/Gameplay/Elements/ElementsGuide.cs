using UnityEngine;
using System;
using System.Collections.Generic;

namespace Gameplay.Elements
{
    public class ElementsGuide : MonoBehaviour
    {
        private readonly MergePoint[] _mergeList = new[]
        {
            new MergePoint(ElementType.Water, ElementType.Water, ElementType.Lake),
            new MergePoint(ElementType.Water, ElementType.Air, ElementType.Cloud),
            new MergePoint(ElementType.Water, ElementType.Fire, ElementType.Steam),
            new MergePoint(ElementType.Water, ElementType.Ground, ElementType.Grass),
            new MergePoint(ElementType.Air, ElementType.Air, ElementType.Wind),
            new MergePoint(ElementType.Air, ElementType.Fire, ElementType.Warm),
            new MergePoint(ElementType.Ground, ElementType.Ground, ElementType.Rock),
            new MergePoint(ElementType.Fire, ElementType.Ground, ElementType.Lava),
        };

        private readonly Dictionary<ElementType, int> _costs = new Dictionary<ElementType, int>
        {
            [ElementType.Ground] = 0,
            [ElementType.Air] = 0,
            [ElementType.Fire] = 0,
            [ElementType.Water] = 0,
            [ElementType.Lake] = 14,
            [ElementType.Air] = 8,
            [ElementType.Lava] = 16,
            [ElementType.Grass] = 6,
            [ElementType.Warm] = 9,
            [ElementType.Steam] = 7,
            [ElementType.Cloud] = 12,
            [ElementType.Rock] = 5,
            [ElementType.Wind] = 10,
        };

        public ElementType GetElementBy(ElementType first, ElementType second)
        {
            foreach (var mergePoint in _mergeList)
            {
                if ((mergePoint.FirstElement == first && mergePoint.SecondElement == second) ||
                    (mergePoint.SecondElement == first && mergePoint.FirstElement == second))
                    return mergePoint.NewElement;
            }
            return ElementType.None;
        }

        public int GetCost(ElementType type)
        {
            if (_costs.ContainsKey(type))
                return _costs[type];
            return 0;
        }
    }

    public class MergePoint
    {
        public ElementType FirstElement { get; }
        public ElementType SecondElement { get; }
        public ElementType NewElement { get; }

        public MergePoint(ElementType first, ElementType second, ElementType result)
        {
            FirstElement = first;
            SecondElement = second;
            NewElement = result;
        }
    }
}