using System;

namespace KRPCCompatibility
{
  public class RemoteTech {
    private static IRemoteTechAPI api_;
    public static IRemoteTechAPI API {
      get {
        if (api_ == null) {
          try {
            api_ = new RemoteTechAvailable();
          } catch (System.IO.FileNotFoundException) {
            api_ = new RemoteTechNotInstalled();
          }
        }
        return api_;
      }
    }

    public interface IRemoteTechAPI {
      bool HasFlightComputer(Guid id);
      void AddSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot);
      void RemoveSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot);
      bool HasAnyConnection(Guid id);
      bool HasConnectionToKSC(Guid id);
      double GetShortestSignalDelay(Guid id);
      double GetSignalDelayToKSC(Guid id);
      double GetSignalDelayToSatellite(Guid a, Guid b);
    }
  }
}
