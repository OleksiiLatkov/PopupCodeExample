using UnityEngine;

namespace Core
{
    public class MonoBehaviourWrapped : MonoBehaviour
    {
        private Transform _cachedTransform;
        private GameObject _cachedGameObject;

        public new Transform transform
        {
            get
            {
                if (_cachedTransform == null)
                {
                    _cachedTransform = base.transform;
                }

                return _cachedTransform;
            }
        }

        public new GameObject gameObject
        {
            get
            {
                if (_cachedGameObject == null)
                {
                    _cachedGameObject = base.gameObject;
                }

                return _cachedGameObject;
            }
        }
    }
}