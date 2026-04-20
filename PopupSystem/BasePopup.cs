using Core;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace PopupSystem
{
    public abstract class BasePopupArgs
    {
    }
    
    public abstract class BasePopup : MonoBehaviourWrapped
    {
        [SerializeField, Required] protected Button _hideButton;
     
        public bool IsVisible { get; private set; }

        private BasePopupArgs _popupArgs;
        
        private void Reset()
        {
            _hideButton ??= GameObject.Find("hide")?.GetComponent<Button>();
        }
        
        protected virtual void Init(BasePopupArgs args)
        {
            _popupArgs = args;
            
            _hideButton?.onClick.AddListener(Hide);
            
            OnInit();
        }
        
        public virtual void Show()
        {
            if (IsVisible) 
                return;

            IsVisible = true;
            gameObject.SetActive(true);

            OnShow();
        }

        public virtual void Hide()
        {
            if (!IsVisible) 
                return;

            IsVisible = false;

            OnHide();
            gameObject.SetActive(false);
        }

        protected virtual void OnInit() { }
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
       
        protected virtual void OnDestroy()
        {
            _hideButton?.onClick.RemoveAllListeners();
        }
        
        protected T Args<T>() where T : BasePopupArgs
        {
            return _popupArgs as T;
        }
    }
}