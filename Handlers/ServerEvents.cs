using System;
using System.Linq;
using Exiled.API.Features;
using MEC;

namespace scp173run.Handlers
{
    public class ServerEvents
    {
        public void OnRoundStart()
        {
            Map.Broadcast(Plugin.Instance.Config.StartEvnet, $"");
            foreach(Door door in Map.Doors)
            {
                door.locked = true;
            }
            Timing.WaitForSeconds(Plugin.Instance.Config.StartEvnet);
            Warhead.Start();
            Map.Broadcast(5, Plugin.Instance.Config.eventstart);
            if (Plugin.Instance.Config.Warheadlock == true)
            {
                Warhead.IsLocked = true;
            }
            else
            {
                Warhead.IsLocked = false;
            }

            foreach (Door door in Map.Doors)
            {
                door.locked = false;
            }

            for (;;)
            {
                if (Warhead.IsDetonated == true)
                {
                    Map.Broadcast(5, Plugin.Instance.Config.eventend);
                    Timing.WaitForSeconds(10f);
                    RoundSummary.RoundLock = false;
                    RoundSummary.singleton.ForceEnd();
                }
            }
        }
    }
}