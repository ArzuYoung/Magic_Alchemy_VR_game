using System.Collections.Generic;

namespace Servive
{
    public static class Translation
    {
        private static Dictionary<ElementType, string> _elementNames = new Dictionary<ElementType, string>
        {
            [ElementType.Warm] = "����",
            [ElementType.Steam] = "���",
            [ElementType.Lava] = "����",
            [ElementType.Lake] = "�����",
            [ElementType.Air] = "������",
            [ElementType.Cloud] = "������",
            [ElementType.Fire] = "�����",
            [ElementType.Grass] = "�����",
            [ElementType.Ground] = "�����",
            [ElementType.Rock] = "������",
            [ElementType.Water] = "����",
            [ElementType.Wind] = "�����",
        };

        public static string GetElementName(ElementType type)
        {
            if (_elementNames.ContainsKey(type)) 
                return _elementNames[type];
            return type.ToString();
        }
    }
}