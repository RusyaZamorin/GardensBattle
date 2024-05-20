using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using GardensBattle.Runtime.Extensions.Unity;
using UnityEngine;
using Zenject;

namespace GardensBattle.Runtime.Services
{
    public class DragAndDropService : IInitializable, IDisposable
    {
        private Transform attachedObject;
        private Action dropCallback;
        private CancellationTokenSource cancellation = new();

        private bool TouchUp
        {
            get
            {
#if UNITY_EDITOR
                return Input.GetMouseButtonUp(0);
#else
                return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
#endif
            }
        }

        private Vector3 TouchPosition
        {
            get
            {
#if UNITY_EDITOR
                return Input.mousePosition;
#else
                return Input.touchCount > 0 ?  Input.GetTouch(0).position : Vector3.zero;
#endif
            }
        }

        public event Action<Transform> OnDragStarted;
        public event Action<Transform> OnDropped;

        public void Attach(Transform target, Action dropCallback = null)
        {
            this.dropCallback = dropCallback;

            attachedObject = target;
            OnDragStarted?.Invoke(target);
        }

        public void Detach(Transform target)
        {
            if (attachedObject == target)
            {
                attachedObject = null;
                dropCallback = null;    
            }
        }
        
        public async void Initialize()
        {
            await foreach (var _ in UniTaskAsyncEnumerable.EveryUpdate().WithCancellation(cancellation.Token))
                Update();
        }

        public void Dispose()
        {
            cancellation.Cancel();
            cancellation?.Dispose();
        }

        private void Update()
        {
            if (attachedObject == null)
                return;

            Move();
            CheckDrop();
        }

        private void CheckDrop()
        {
            if (TouchUp)
            {
                dropCallback?.Invoke();
                OnDropped?.Invoke(attachedObject);

                Detach(attachedObject);
            }
        }

        private void Move()
        {
            if (Camera.main == null)
                return;

            var worldPoint = Camera.main.ScreenToWorldPoint(TouchPosition);
            attachedObject.position = worldPoint.SetZ(attachedObject.position.z);
        }
    }
}