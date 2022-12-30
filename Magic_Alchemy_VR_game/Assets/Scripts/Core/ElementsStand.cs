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
        [SerializeField] private float SecondBeforeSpawn = 2f;
        
        private bool isStartSpawn = false;

        private float timer;

        private void Update()
        {
            if (timer <= 0)
            {
                if (!IsContainMyElement() && !isStartSpawn)
                    StartCoroutine(SpawnElement());
                
                timer = SecondBeforeSpawn;
            }
            else
                timer -= Time.deltaTime;
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
            yield return new WaitForSeconds(1f);
            
            var prefabElement = ElementsStorage.Instance.GetPrefab(elementType);
            Instantiate(prefabElement,
                new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z + 0.07f),
                Quaternion.identity);
            isStartSpawn = false;
        }
    }
}
