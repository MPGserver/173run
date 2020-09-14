using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using MapEvents = Exiled.Events.Handlers.Map;
using Warhead = Exiled.Events.Handlers.Warhead;
using Exiled.API.Features;
using Exiled.API.Enums;
using System;
using Exiled.Loader;
using System.Collections.Generic;
using MEC;

namespace scp173run
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        private Handlers.PlayerEvents player;
        private Handlers.ServerEvents server;
        private Handlers.WarheadEvents warhead;
        
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();
        
        public IEnumerable<Door> doors = Map.Doors;

        private Plugin()
        {
        }
        
        public override void OnEnabled()
        {
            base.OnEnabled();
            
            RegisterEvents();
            Log.Info("SCP-173 Run plugin On");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            
            UnregisterEvents();
            Log.Info("SCP-173 Run plugin Off");
        }

        public void RegisterEvents()
        {
            player = new Handlers.PlayerEvents();
            server = new Handlers.ServerEvents();
            warhead = new Handlers.WarheadEvents();

            Server.RoundStarted += server.OnRoundStart;
            Warhead.Stopping += warhead.OnStopping;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= server.OnRoundStart;
            Warhead.Stopping -= warhead.OnStopping;
            
            player = null;
            server = null;
            warhead = null;
        }
    }
}