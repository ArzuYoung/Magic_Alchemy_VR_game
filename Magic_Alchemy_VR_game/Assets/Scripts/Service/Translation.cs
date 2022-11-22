using System.Collections.Generic;

namespace Servive
{
    public static class Translation
    {
        private static Dictionary<ElementType, string> _elementNames = new Dictionary<ElementType, string>
        {
            [ElementType.Warm] = "фюпю",
            [ElementType.Steam] = "оюп",
            [ElementType.Lava] = "кюбю",
            [ElementType.Lake] = "нгепн",
            [ElementType.Air] = "бнгдсу",
            [ElementType.Cloud] = "накюйн",
            [ElementType.Fire] = "нцнмэ",
            [ElementType.Grass] = "рпюбю",
            [ElementType.Ground] = "гелкъ",
            [ElementType.Rock] = "йюлемэ",
            [ElementType.Water] = "бндю",
            [ElementType.Wind] = "береп",
        };

        public static string GetElementName(ElementType type)
        {
            if (_elementNames.ContainsKey(type)) 
                return _elementNames[type];
            return type.ToString();
        }
    }
}