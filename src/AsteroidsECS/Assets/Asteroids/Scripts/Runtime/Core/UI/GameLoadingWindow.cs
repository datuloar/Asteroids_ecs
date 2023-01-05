using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    public class GameLoadingWindow : MonoBehaviour, IGameLoadingWindow
    {
        [SerializeField] private Image _progressBar;
        [SerializeField] private TMP_Text _description;
        [SerializeField, Range(0f, 1f)] private float _progressBarSpeed;

        private Tweener _tweener;

        public void SetOperationInfo(string description)
        {
            _description.text = description;
        }

        public void FillProgress(float value)
        {
            //_tweener?.Kill();
            //_tweener = _progressBar.DOFillAmount(value, _progressBarSpeed);
        }

        public void ResetFill()
        {
            //_tweener?.Kill();
            //_progressBar.fillAmount = 0f;
        }
    }

    public interface IGameLoadingWindow
    {
        void SetOperationInfo(string description);
        void FillProgress(float progress);
        void ResetFill();
    }
}