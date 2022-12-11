using System;
using System.Collections;
using Gameplay.Elements;
using UnityEngine;

namespace Core
{
    public class ElementsStand : MonoBehaviour
    {
        [SerializeField] private ElementType elementType;
        [SerializeField] private Transform spawnPoint;

        private bool isStartSpawn = false;

        private void OnCollisionExit(Collision other)
        {
            if (!IsContainMyElement() && !isStartSpawn)
                StartCoroutine(SpawnElement());
        }

        private bool IsContainMyElement()
        {
            var hitColliders = Physics.OverlapBox(spawnPoint.position,
                spawnPoint.localScale / 12,
                Quaternion.identity);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                var hitElementType = hitColliders[i].gameObject.GetComponent<ElementsMerging>()?.Type;
                
                if (hitElementType == elementType)
                    return true;
            }

            return false;
        }

        private IEnumerator SpawnElement()
        {
            isStartSpawn = true;
            yield return new WaitForSeconds(3f);
            
            var prefabElement = ElementsStorage.Instance.GetPrefab(elementType);
            Instantiate(prefabElement,
                new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z + 0.07f),
                Quaternion.identity);
            isStartSpawn = false;
        }
    }
}
