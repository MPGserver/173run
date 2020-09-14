using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace scp173run.Handlers
{
    public class WarheadEvents
    {
        public void OnStopping(StoppingEventArgs ev)
        {
            Warhead.Start();
        }
    }
}