using System;

namespace AttackSystem
{
    public interface IReload
    {
        public float CurrentTime { get; }
        
        public float MaxTime { get;  }
        
        public bool IsReload { get;  }
        
        public event Action Started;

        public event Action Tick;
        
        public event Action Ended;

        public void StartReload();
    }
}