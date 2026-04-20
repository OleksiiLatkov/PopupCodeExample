using System;
using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace PopupSystem
{
    public class TwoButtonsDialogArgs : BasePopupArgs
    {
        public readonly string Title;
        public readonly string Description;
        
        public readonly Action OnLeftButtonClick;
        public readonly Action OnRightButtonClick;

        public TwoButtonsDialogArgs(string title, string description, Action leftButtonClick, Action rightButtonClick)
        {
            Title = title;
            Description = description;
            OnLeftButtonClick = leftButtonClick;
            OnRightButtonClick = rightButtonClick;
        }
    }
    
    public class TwoButtonsDialog : BasePopup
    {
        [SerializeField, Required] private TextMeshProUGUI _title;
        [SerializeField, Required] private TextMeshProUGUI _description;
        
        [SerializeField, Required] private Button _leftButton;
        [SerializeField, Required] private Button _rightButton;
        
        protected override void OnInit()
        {
            base.OnInit();
            
            var args = Args<TwoButtonsDialogArgs>();

            _title.text = args.Title;
            _description.text = args.Description;
            
            _leftButton.onClick.AddListener(() =>
            {
                args.OnLeftButtonClick?.Invoke();
                Hide();
            });
            
            _rightButton.onClick.AddListener(() =>
            {
                args.OnRightButtonClick?.Invoke();
                Hide();
            });
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            _leftButton.onClick.RemoveAllListeners();
            _rightButton.onClick.RemoveAllListeners();
        }
        
        protected override void Reset()
        {
            base.Reset();
            
            _title ??= transform.Find("title")?.GetComponent<TextMeshProUGUI>();
            _description ??= transform.Find("description")?.GetComponent<TextMeshProUGUI>();
            
            _leftButton  ??= transform.Find("leftButton")?.GetComponent<Button>();
            _rightButton ??= transform.Find("rightButton")?.GetComponent<Button>();
        }
    }
}