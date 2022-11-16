namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using Cinemachine;
	using System.Collections.Generic;
	using UnityEngine;

	public class CameraSwitcher : IComponent
	{
		private List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
		private CinemachineVirtualCamera _activeCamera = null;		

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>CameraSwitcher initialized!</color>");
		}		

		public bool IsActiveCamera(CinemachineVirtualCamera cam)
		{
			return _activeCamera == cam;
		}

		public void SwitchCamera(CinemachineVirtualCamera cam)
		{
			cam.Priority = 10;
			_activeCamera = cam;

			foreach (CinemachineVirtualCamera c in cameras)
			{
				if (c != cam && c.Priority != 0)
				{
					c.Priority = 0;
				}
			}
		}

		public void Register(CinemachineVirtualCamera cam)
		{
			cameras.Add(cam);
			Debug.Log("Camera registered: " + cam);
		}

		public void Unregister(CinemachineVirtualCamera cam)
		{
			cameras.Remove(cam);
			Debug.Log("Camera unregistered: " + cam);
		}

		public CinemachineVirtualCamera ActiveCamera
		{
			get => _activeCamera;
			set => _activeCamera = value;
		}

	}
}
