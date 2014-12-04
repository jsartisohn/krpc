using System;
using ExternalRemoteTech = RemoteTech;

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

    private class RemoteTechAvailable : IRemoteTechAPI {
      public bool HasFlightComputer(Guid id) {
        return ExternalRemoteTech.API.HasFlightComputer(id);
      }
      public void AddSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {
        ExternalRemoteTech.API.AddSanctionedPilot(id, autopilot);
      }
      public void RemoveSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {
        ExternalRemoteTech.API.RemoveSanctionedPilot(id, autopilot);
      }
      public bool HasAnyConnection(Guid id) {
        return ExternalRemoteTech.API.HasAnyConnection(id);
      }
      public bool HasConnectionToKSC(Guid id) {
        return ExternalRemoteTech.API.HasConnectionToKSC(id);
      }
      public double GetShortestSignalDelay(Guid id) {
        return ExternalRemoteTech.API.GetShortestSignalDelay(id);
      }
      public double GetSignalDelayToKSC(Guid id) {
        return ExternalRemoteTech.API.GetSignalDelayToKSC(id);
      }
      public double GetSignalDelayToSatellite(Guid a, Guid b) {
        return ExternalRemoteTech.API.GetSignalDelayToSatellite(a, b);
      }
    }

    private class RemoteTechNotInstalled : IRemoteTechAPI {
      public bool HasFlightComputer(Guid id) {
        return false;
      }
      public void AddSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {}
      public void RemoveSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {}
      public bool HasAnyConnection(Guid id) {
        return false;
      }
      public bool HasConnectionToKSC(Guid id) {
        return false;
      }
      public double GetShortestSignalDelay(Guid id) {
        return 0d;
      }
      public double GetSignalDelayToKSC(Guid id) {
        return 0d;
      }
      public double GetSignalDelayToSatellite(Guid a, Guid b) {
        return 0d;
      }
    }
  }
}